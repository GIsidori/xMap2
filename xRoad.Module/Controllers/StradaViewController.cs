using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using NetTopologySuite.Geometries;
using NetTopologySuite.LinearReferencing;
using xMap.Persistent.Base;
using xRoad.Module.BusinessObjects.RoadDataModel;

namespace xRoad.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class LinearReferencingViewController : ViewController
    {
        public LinearReferencingViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.

            if (View.CurrentObject is IXPGeometry geom)
            {
                this.actionGetLocation.Active["IsLinear"] = (geom.Shape.GeometryType == Geometry.TypeNameLineString || geom.Shape.GeometryType == Geometry.TypeNameMultiLineString);
            }

        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void actionGetLocation_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            double distance = (double)e.ParameterCurrentValue;
            var road = e.CurrentObject as Strada;
            {
                //var loc = LengthLocationMap.GetLocation(road.Shape, distance);
                //var coord = loc.GetCoordinate(road.Shape);

                var lnr = new LengthIndexedLine(road.Shape);
                var coord = lnr.ExtractPoint(distance);

                var p = this.ObjectSpace.CreateObject<Tombino>();
                p.Strada = road;
                p.TipoLocalizzazione = BusinessObjects.TipoLocalizzazione.Coordinate;
                p.XPos = coord.X;
                p.YPos = coord.Y;
                p.ZPos = coord.Z;
                p.MPos = distance;
                p.TipoCoordinata = BusinessObjects.TipoCoordinata.Proiettata;
                p.GeometriaEventoPuntuale = ObjectSpace.CreateObject<GeometriaEventoPuntuale>();
                p.GeometriaEventoPuntuale.EventoPuntuale = p;
                p.GeometriaEventoPuntuale.Shape = new Point(coord);
            }

        }
    }
}
