namespace CortanaSlide
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.groupSerial = this.Factory.CreateRibbonGroup();
            this.comboBoxIp = this.Factory.CreateRibbonComboBox();
            this.buttonUpdate = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.labelStatus = this.Factory.CreateRibbonLabel();
            this.buttonConnect = this.Factory.CreateRibbonButton();
            this.buttonClose = this.Factory.CreateRibbonButton();
            this.buttonReflesh = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.groupSerial.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.groupSerial);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Cortana";
            this.tab1.Name = "tab1";
            // 
            // groupSerial
            // 
            this.groupSerial.Items.Add(this.comboBoxIp);
            this.groupSerial.Items.Add(this.buttonReflesh);
            this.groupSerial.Items.Add(this.buttonUpdate);
            this.groupSerial.Label = "シリアルポート";
            this.groupSerial.Name = "groupSerial";
            // 
            // comboBoxIp
            // 
            this.comboBoxIp.Label = "Ip";
            this.comboBoxIp.Name = "comboBoxIp";
            this.comboBoxIp.Text = null;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Label = "";
            this.buttonUpdate.Name = "buttonUpdate";
            // 
            // group1
            // 
            this.group1.Items.Add(this.labelStatus);
            this.group1.Items.Add(this.buttonConnect);
            this.group1.Items.Add(this.buttonClose);
            this.group1.Label = "接続";
            this.group1.Name = "group1";
            // 
            // labelStatus
            // 
            this.labelStatus.Label = "label";
            this.labelStatus.Name = "labelStatus";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Label = "接続";
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonConnect_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Label = "切断";
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonClose_Click);
            // 
            // buttonReflesh
            // 
            this.buttonReflesh.Label = "更新";
            this.buttonReflesh.Name = "buttonReflesh";
            this.buttonReflesh.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonReflesh_Click);
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.groupSerial.ResumeLayout(false);
            this.groupSerial.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSerial;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonUpdate;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonConnect;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel labelStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonClose;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBoxIp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonReflesh;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
