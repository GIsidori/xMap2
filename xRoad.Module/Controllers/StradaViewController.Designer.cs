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
            this.simpleAction1 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
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
            // simpleAction1
            // 
            this.simpleAction1.Caption = "Aggiorna eventi su mappa";
            this.simpleAction1.Category = "Edit";
            this.simpleAction1.ConfirmationMessage = "Confermi?";
            this.simpleAction1.Id = "706cc6e8-0f85-4d65-a324-d940c5543efa";
            this.simpleAction1.TargetObjectType = typeof(xRoad.Module.BusinessObjects.RoadDataModel.Strada);
            this.simpleAction1.ToolTip = null;
            this.simpleAction1.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleAction1_Execute);
            // 
            // LinearReferencingViewController
            // 
            this.Actions.Add(this.actionGetLocation);
            this.Actions.Add(this.simpleAction1);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.ParametrizedAction actionGetLocation;
        private DevExpress.ExpressApp.Actions.SimpleAction simpleAction1;
    }
}
