namespace xRoad.Module.Controllers
{
    partial class LinearReferencingViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.actionGetLocation = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // actionGetLocation
            // 
            this.actionGetLocation.Caption = "Aggiunge evento";
            this.actionGetLocation.Category = "Edit";
            this.actionGetLocation.ConfirmationMessage = null;
            this.actionGetLocation.Id = "AddEventOnRoad";
            this.actionGetLocation.NullValuePrompt = null;
            this.actionGetLocation.ShortCaption = null;
            this.actionGetLocation.TargetObjectType = typeof(xRoad.Module.BusinessObjects.RoadDataModel.Strada);
            this.actionGetLocation.ToolTip = null;
            this.actionGetLocation.ValueType = typeof(double);
            this.actionGetLocation.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.actionGetLocation_Execute);
            // 
            // LinearReferencingViewController
            // 
            this.Actions.Add(this.actionGetLocation);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.ParametrizedAction actionGetLocation;
    }
}
