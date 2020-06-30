using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMap.Persistent.Base
{

    public enum GeometryType
    {
        Point,
        Polyline,
        Polygon
    }

    public interface IGeometry
    {
        int SRID { get; set; }
        SqlGeometry Shape { get; set; }
        GeometryType GeometryType { get; }
    }


    public interface IPoint:IGeometry
    {

    }

    public interface IPolyline:IGeometry
    {

    }

    public interface IPolygon:IGeometry
    {

    }

    public abstract class Geometry : SqlGeometry, IGeometry
    {
        private int srid;
        public int SRID { get => srid; set => srid = value; }

        private SqlGeometry shape;
        public SqlGeometry Shape { get => shape; set => shape = value; }

        protected GeometryType geometryType;
        public GeometryType GeometryType => geometryType;

    }

    public class Point:Geometry,IPoint
    {
        public Point()
        {
            this.geometryType = GeometryType.Point;
        }
    }

    public class Polyline : Geometry,IPolyline
    {
        public Polyline()
        {
            this.geometryType = GeometryType.Polyline;
        }
    }

    public class Polygon : Geometry, IPolygon
    {
        public Polygon()
        {
            this.geometryType = GeometryType.Polygon;
        }
    }

}
