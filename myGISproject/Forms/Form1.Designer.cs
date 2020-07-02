using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;


namespace myGISproject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAttributeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MessageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScaleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CoordinateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.MapDecoration = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OpenLyrBtn = new System.Windows.Forms.Button();
            this.OpenShpBtn = new System.Windows.Forms.Button();
            this.OpenMxdBtn = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.GotoBtn = new System.Windows.Forms.Button();
            this.AttributeQueryBtn = new System.Windows.Forms.Button();
            this.MeasureBtn = new System.Windows.Forms.Button();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.BufferOutput = new System.Windows.Forms.Label();
            this.BufferBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LayerBox = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.IntersectOutput = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.IntersectBox2 = new System.Windows.Forms.ComboBox();
            this.IntersectBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RecoverBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.FixedZoomoutBtn = new System.Windows.Forms.Button();
            this.FixedZoominBtn = new System.Windows.Forms.Button();
            this.EditLayerBox = new System.Windows.Forms.ComboBox();
            this.ZoominBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.StopEditBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ZoomoutBtn = new System.Windows.Forms.Button();
            this.StartEditBtn = new System.Windows.Forms.Button();
            this.EditBox = new System.Windows.Forms.ComboBox();
            this.GlobalViewBtn = new System.Windows.Forms.Button();
            this.RoamBtn = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.legend = new System.Windows.Forms.Button();
            this.squareRid = new System.Windows.Forms.Button();
            this.outerBorder = new System.Windows.Forms.Button();
            this.compass = new System.Windows.Forms.Button();
            this.scare = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Button();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.Button();
            this.classification = new System.Windows.Forms.Button();
            this.radar = new System.Windows.Forms.Button();
            this.indexAnalysis = new System.Windows.Forms.Button();
            this.pieChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.MapDecoration.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(593, 46);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAttributeTableToolStripMenuItem,
            this.删除图层ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // openAttributeTableToolStripMenuItem
            // 
            this.openAttributeTableToolStripMenuItem.Name = "openAttributeTableToolStripMenuItem";
            this.openAttributeTableToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openAttributeTableToolStripMenuItem.Text = "打开属性表";
            this.openAttributeTableToolStripMenuItem.Click += new System.EventHandler(this.openAttributeTableToolStripMenuItem_Click_1);
            // 
            // 删除图层ToolStripMenuItem
            // 
            this.删除图层ToolStripMenuItem.Name = "删除图层ToolStripMenuItem";
            this.删除图层ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除图层ToolStripMenuItem.Text = "删除图层";
            this.删除图层ToolStripMenuItem.Click += new System.EventHandler(this.删除图层ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(265, 133);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 545);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Controls.Add(this.axLicenseControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(701, 513);
            this.axMapControl1.TabIndex = 1;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.axMapControl1_OnDoubleClick);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(701, 513);
            this.axPageLayoutControl1.TabIndex = 0;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MessageLabel,
            this.Blank,
            this.ScaleLabel,
            this.CoordinateLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 681);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MessageLabel
            // 
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(32, 17);
            this.MessageLabel.Text = "就绪";
            // 
            // Blank
            // 
            this.Blank.Name = "Blank";
            this.Blank.Size = new System.Drawing.Size(845, 17);
            this.Blank.Spring = true;
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(44, 17);
            this.ScaleLabel.Text = "比例尺";
            // 
            // CoordinateLabel
            // 
            this.CoordinateLabel.Name = "CoordinateLabel";
            this.CoordinateLabel.Size = new System.Drawing.Size(56, 17);
            this.CoordinateLabel.Text = "当前坐标";
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axMapControl2.Location = new System.Drawing.Point(12, 384);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(235, 287);
            this.axMapControl2.TabIndex = 6;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(12, 133);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(235, 228);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // MapDecoration
            // 
            this.MapDecoration.Controls.Add(this.tabPage3);
            this.MapDecoration.Controls.Add(this.tabPage5);
            this.MapDecoration.Controls.Add(this.tabPage6);
            this.MapDecoration.Controls.Add(this.tabPage4);
            this.MapDecoration.Controls.Add(this.tabPage7);
            this.MapDecoration.Controls.Add(this.tabPage8);
            this.MapDecoration.Controls.Add(this.tabPage9);
            this.MapDecoration.Dock = System.Windows.Forms.DockStyle.Top;
            this.MapDecoration.Location = new System.Drawing.Point(0, 0);
            this.MapDecoration.Multiline = true;
            this.MapDecoration.Name = "MapDecoration";
            this.MapDecoration.SelectedIndex = 0;
            this.MapDecoration.Size = new System.Drawing.Size(992, 127);
            this.MapDecoration.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.axToolbarControl1);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.OpenLyrBtn);
            this.tabPage3.Controls.Add(this.OpenShpBtn);
            this.tabPage3.Controls.Add(this.OpenMxdBtn);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(984, 101);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(347, 34);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(265, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(244, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "打开Lyr";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(43, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "打开Mxd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 9.75F);
            this.label4.Location = new System.Drawing.Point(143, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "打开Shp";
            // 
            // OpenLyrBtn
            // 
            this.OpenLyrBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenLyrBtn.BackgroundImage")));
            this.OpenLyrBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenLyrBtn.Location = new System.Drawing.Point(240, 15);
            this.OpenLyrBtn.Name = "OpenLyrBtn";
            this.OpenLyrBtn.Size = new System.Drawing.Size(60, 60);
            this.OpenLyrBtn.TabIndex = 0;
            this.OpenLyrBtn.UseVisualStyleBackColor = true;
            this.OpenLyrBtn.Click += new System.EventHandler(this.OpenLyrBtn_Click);
            // 
            // OpenShpBtn
            // 
            this.OpenShpBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenShpBtn.BackgroundImage")));
            this.OpenShpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenShpBtn.Location = new System.Drawing.Point(140, 15);
            this.OpenShpBtn.Name = "OpenShpBtn";
            this.OpenShpBtn.Size = new System.Drawing.Size(60, 60);
            this.OpenShpBtn.TabIndex = 0;
            this.OpenShpBtn.UseVisualStyleBackColor = true;
            this.OpenShpBtn.Click += new System.EventHandler(this.OpenShpBtn_Click);
            // 
            // OpenMxdBtn
            // 
            this.OpenMxdBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenMxdBtn.BackgroundImage")));
            this.OpenMxdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenMxdBtn.Location = new System.Drawing.Point(40, 15);
            this.OpenMxdBtn.Name = "OpenMxdBtn";
            this.OpenMxdBtn.Size = new System.Drawing.Size(60, 60);
            this.OpenMxdBtn.TabIndex = 0;
            this.OpenMxdBtn.UseVisualStyleBackColor = true;
            this.OpenMxdBtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.SelectBtn);
            this.tabPage5.Controls.Add(this.GotoBtn);
            this.tabPage5.Controls.Add(this.AttributeQueryBtn);
            this.tabPage5.Controls.Add(this.MeasureBtn);
            this.tabPage5.Controls.Add(this.QueryBtn);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(984, 101);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "功能";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(440, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "属性查询";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(351, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "转到";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(254, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "量测";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(152, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "查询";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(51, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "选取";
            // 
            // SelectBtn
            // 
            this.SelectBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectBtn.BackgroundImage")));
            this.SelectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SelectBtn.Location = new System.Drawing.Point(40, 15);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(60, 60);
            this.SelectBtn.TabIndex = 3;
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // GotoBtn
            // 
            this.GotoBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GotoBtn.BackgroundImage")));
            this.GotoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GotoBtn.Location = new System.Drawing.Point(340, 15);
            this.GotoBtn.Name = "GotoBtn";
            this.GotoBtn.Size = new System.Drawing.Size(60, 60);
            this.GotoBtn.TabIndex = 2;
            this.GotoBtn.UseVisualStyleBackColor = true;
            this.GotoBtn.Click += new System.EventHandler(this.GotoBtn_Click);
            // 
            // AttributeQueryBtn
            // 
            this.AttributeQueryBtn.BackColor = System.Drawing.Color.Transparent;
            this.AttributeQueryBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AttributeQueryBtn.BackgroundImage")));
            this.AttributeQueryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AttributeQueryBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AttributeQueryBtn.Location = new System.Drawing.Point(440, 15);
            this.AttributeQueryBtn.Name = "AttributeQueryBtn";
            this.AttributeQueryBtn.Size = new System.Drawing.Size(60, 60);
            this.AttributeQueryBtn.TabIndex = 0;
            this.AttributeQueryBtn.UseVisualStyleBackColor = false;
            this.AttributeQueryBtn.Click += new System.EventHandler(this.AttributeQueryBtn_Click);
            // 
            // MeasureBtn
            // 
            this.MeasureBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MeasureBtn.BackgroundImage")));
            this.MeasureBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MeasureBtn.Location = new System.Drawing.Point(240, 15);
            this.MeasureBtn.Name = "MeasureBtn";
            this.MeasureBtn.Size = new System.Drawing.Size(60, 60);
            this.MeasureBtn.TabIndex = 1;
            this.MeasureBtn.UseVisualStyleBackColor = true;
            this.MeasureBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // QueryBtn
            // 
            this.QueryBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("QueryBtn.BackgroundImage")));
            this.QueryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QueryBtn.Location = new System.Drawing.Point(140, 15);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(60, 60);
            this.QueryBtn.TabIndex = 0;
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.BufferOutput);
            this.tabPage6.Controls.Add(this.BufferBtn);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.textBox1);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Controls.Add(this.LayerBox);
            this.tabPage6.Controls.Add(this.button6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(984, 101);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "缓冲区分析";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(43, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 18);
            this.label13.TabIndex = 9;
            this.label13.Text = "输出路径：";
            // 
            // BufferOutput
            // 
            this.BufferOutput.AutoSize = true;
            this.BufferOutput.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BufferOutput.Location = new System.Drawing.Point(156, 79);
            this.BufferOutput.Name = "BufferOutput";
            this.BufferOutput.Size = new System.Drawing.Size(0, 13);
            this.BufferOutput.TabIndex = 8;
            // 
            // BufferBtn
            // 
            this.BufferBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BufferBtn.BackgroundImage")));
            this.BufferBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BufferBtn.Location = new System.Drawing.Point(360, 5);
            this.BufferBtn.Name = "BufferBtn";
            this.BufferBtn.Size = new System.Drawing.Size(67, 67);
            this.BufferBtn.TabIndex = 7;
            this.BufferBtn.UseVisualStyleBackColor = true;
            this.BufferBtn.Click += new System.EventHandler(this.BufferBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(24, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 18);
            this.label12.TabIndex = 6;
            this.label12.Text = "缓冲区半径：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(81, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "图层：";
            // 
            // LayerBox
            // 
            this.LayerBox.FormattingEnabled = true;
            this.LayerBox.Location = new System.Drawing.Point(152, 10);
            this.LayerBox.Name = "LayerBox";
            this.LayerBox.Size = new System.Drawing.Size(160, 20);
            this.LayerBox.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(447, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 67);
            this.button6.TabIndex = 2;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.IntersectOutput);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.IntersectBox2);
            this.tabPage4.Controls.Add(this.IntersectBox1);
            this.tabPage4.Font = new System.Drawing.Font("幼圆", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(984, 101);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "叠置分析";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("幼圆", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(22, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "输出路径：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("幼圆", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(50, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "图层2：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("幼圆", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(50, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "图层1：";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(412, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 67);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // IntersectOutput
            // 
            this.IntersectOutput.AutoSize = true;
            this.IntersectOutput.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IntersectOutput.Location = new System.Drawing.Point(136, 78);
            this.IntersectOutput.Name = "IntersectOutput";
            this.IntersectOutput.Size = new System.Drawing.Size(0, 13);
            this.IntersectOutput.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(327, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 67);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // IntersectBox2
            // 
            this.IntersectBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IntersectBox2.FormattingEnabled = true;
            this.IntersectBox2.Location = new System.Drawing.Point(134, 46);
            this.IntersectBox2.Name = "IntersectBox2";
            this.IntersectBox2.Size = new System.Drawing.Size(160, 20);
            this.IntersectBox2.TabIndex = 2;
            // 
            // IntersectBox1
            // 
            this.IntersectBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IntersectBox1.FormattingEnabled = true;
            this.IntersectBox1.Location = new System.Drawing.Point(134, 11);
            this.IntersectBox1.Name = "IntersectBox1";
            this.IntersectBox1.Size = new System.Drawing.Size(160, 20);
            this.IntersectBox1.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.RecoverBtn);
            this.tabPage7.Controls.Add(this.DeleteBtn);
            this.tabPage7.Controls.Add(this.UndoBtn);
            this.tabPage7.Controls.Add(this.FixedZoomoutBtn);
            this.tabPage7.Controls.Add(this.FixedZoominBtn);
            this.tabPage7.Controls.Add(this.EditLayerBox);
            this.tabPage7.Controls.Add(this.ZoominBtn);
            this.tabPage7.Controls.Add(this.UpdateBtn);
            this.tabPage7.Controls.Add(this.StopEditBtn);
            this.tabPage7.Controls.Add(this.SaveBtn);
            this.tabPage7.Controls.Add(this.ZoomoutBtn);
            this.tabPage7.Controls.Add(this.StartEditBtn);
            this.tabPage7.Controls.Add(this.EditBox);
            this.tabPage7.Controls.Add(this.GlobalViewBtn);
            this.tabPage7.Controls.Add(this.RoamBtn);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(984, 101);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "编辑";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "操作图层：";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "操作类型：";
            // 
            // RecoverBtn
            // 
            this.RecoverBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RecoverBtn.Location = new System.Drawing.Point(861, 19);
            this.RecoverBtn.Name = "RecoverBtn";
            this.RecoverBtn.Size = new System.Drawing.Size(80, 26);
            this.RecoverBtn.TabIndex = 8;
            this.RecoverBtn.Text = "恢复鼠标";
            this.RecoverBtn.UseVisualStyleBackColor = true;
            this.RecoverBtn.Click += new System.EventHandler(this.RecoverBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteBtn.Location = new System.Drawing.Point(763, 58);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(80, 26);
            this.DeleteBtn.TabIndex = 7;
            this.DeleteBtn.Text = "删除";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UndoBtn
            // 
            this.UndoBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UndoBtn.Location = new System.Drawing.Point(661, 57);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(80, 26);
            this.UndoBtn.TabIndex = 6;
            this.UndoBtn.Text = "撤销";
            this.UndoBtn.UseVisualStyleBackColor = true;
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // FixedZoomoutBtn
            // 
            this.FixedZoomoutBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FixedZoomoutBtn.Location = new System.Drawing.Point(763, 19);
            this.FixedZoomoutBtn.Name = "FixedZoomoutBtn";
            this.FixedZoomoutBtn.Size = new System.Drawing.Size(80, 26);
            this.FixedZoomoutBtn.TabIndex = 0;
            this.FixedZoomoutBtn.Text = "中心缩小";
            this.FixedZoomoutBtn.UseVisualStyleBackColor = true;
            this.FixedZoomoutBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // FixedZoominBtn
            // 
            this.FixedZoominBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FixedZoominBtn.Location = new System.Drawing.Point(660, 19);
            this.FixedZoominBtn.Name = "FixedZoominBtn";
            this.FixedZoominBtn.Size = new System.Drawing.Size(80, 26);
            this.FixedZoominBtn.TabIndex = 0;
            this.FixedZoominBtn.Text = "中心放大";
            this.FixedZoominBtn.UseVisualStyleBackColor = true;
            this.FixedZoominBtn.Click += new System.EventHandler(this.FixedZoominBtn_Click);
            // 
            // EditLayerBox
            // 
            this.EditLayerBox.FormattingEnabled = true;
            this.EditLayerBox.Location = new System.Drawing.Point(101, 62);
            this.EditLayerBox.Name = "EditLayerBox";
            this.EditLayerBox.Size = new System.Drawing.Size(121, 20);
            this.EditLayerBox.TabIndex = 5;
            this.EditLayerBox.SelectedIndexChanged += new System.EventHandler(this.EditLayerBox_SelectedIndexChanged);
            // 
            // ZoominBtn
            // 
            this.ZoominBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZoominBtn.Location = new System.Drawing.Point(462, 19);
            this.ZoominBtn.Name = "ZoominBtn";
            this.ZoominBtn.Size = new System.Drawing.Size(80, 26);
            this.ZoominBtn.TabIndex = 0;
            this.ZoominBtn.Text = "放大";
            this.ZoominBtn.UseVisualStyleBackColor = true;
            this.ZoominBtn.Click += new System.EventHandler(this.ZoominBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateBtn.Location = new System.Drawing.Point(268, 57);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(80, 26);
            this.UpdateBtn.TabIndex = 4;
            this.UpdateBtn.Text = "更新图层";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // StopEditBtn
            // 
            this.StopEditBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopEditBtn.Location = new System.Drawing.Point(561, 57);
            this.StopEditBtn.Name = "StopEditBtn";
            this.StopEditBtn.Size = new System.Drawing.Size(80, 26);
            this.StopEditBtn.TabIndex = 3;
            this.StopEditBtn.Text = "停止编辑";
            this.StopEditBtn.UseVisualStyleBackColor = true;
            this.StopEditBtn.Click += new System.EventHandler(this.StopEditBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Location = new System.Drawing.Point(462, 57);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(80, 26);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ZoomoutBtn
            // 
            this.ZoomoutBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZoomoutBtn.Location = new System.Drawing.Point(561, 19);
            this.ZoomoutBtn.Name = "ZoomoutBtn";
            this.ZoomoutBtn.Size = new System.Drawing.Size(80, 26);
            this.ZoomoutBtn.TabIndex = 0;
            this.ZoomoutBtn.Text = "缩小";
            this.ZoomoutBtn.UseVisualStyleBackColor = true;
            this.ZoomoutBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // StartEditBtn
            // 
            this.StartEditBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartEditBtn.Location = new System.Drawing.Point(364, 57);
            this.StartEditBtn.Name = "StartEditBtn";
            this.StartEditBtn.Size = new System.Drawing.Size(80, 26);
            this.StartEditBtn.TabIndex = 1;
            this.StartEditBtn.Text = "开始编辑";
            this.StartEditBtn.UseVisualStyleBackColor = true;
            this.StartEditBtn.Click += new System.EventHandler(this.StartEditBtn_Click);
            // 
            // EditBox
            // 
            this.EditBox.FormattingEnabled = true;
            this.EditBox.Location = new System.Drawing.Point(100, 25);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(121, 20);
            this.EditBox.TabIndex = 0;
            this.EditBox.SelectedIndexChanged += new System.EventHandler(this.EditBox_SelectedIndexChanged);
            // 
            // GlobalViewBtn
            // 
            this.GlobalViewBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GlobalViewBtn.Location = new System.Drawing.Point(364, 19);
            this.GlobalViewBtn.Name = "GlobalViewBtn";
            this.GlobalViewBtn.Size = new System.Drawing.Size(80, 26);
            this.GlobalViewBtn.TabIndex = 0;
            this.GlobalViewBtn.Text = "全图显示";
            this.GlobalViewBtn.UseVisualStyleBackColor = true;
            this.GlobalViewBtn.Click += new System.EventHandler(this.GlobalViewBtn_Click);
            // 
            // RoamBtn
            // 
            this.RoamBtn.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoamBtn.Location = new System.Drawing.Point(268, 19);
            this.RoamBtn.Name = "RoamBtn";
            this.RoamBtn.Size = new System.Drawing.Size(80, 26);
            this.RoamBtn.TabIndex = 0;
            this.RoamBtn.Text = "漫游";
            this.RoamBtn.UseVisualStyleBackColor = true;
            this.RoamBtn.Click += new System.EventHandler(this.RoamBtn_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.legend);
            this.tabPage8.Controls.Add(this.squareRid);
            this.tabPage8.Controls.Add(this.outerBorder);
            this.tabPage8.Controls.Add(this.compass);
            this.tabPage8.Controls.Add(this.scare);
            this.tabPage8.Controls.Add(this.name);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(984, 101);
            this.tabPage8.TabIndex = 6;
            this.tabPage8.Text = "地图整饰";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // legend
            // 
            this.legend.Location = new System.Drawing.Point(493, 35);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(75, 23);
            this.legend.TabIndex = 1;
            this.legend.Text = "图例";
            this.legend.UseVisualStyleBackColor = true;
            this.legend.Click += new System.EventHandler(this.legend_Click);
            // 
            // squareRid
            // 
            this.squareRid.Location = new System.Drawing.Point(396, 35);
            this.squareRid.Name = "squareRid";
            this.squareRid.Size = new System.Drawing.Size(75, 23);
            this.squareRid.TabIndex = 1;
            this.squareRid.Text = "方里网";
            this.squareRid.UseVisualStyleBackColor = true;
            this.squareRid.Click += new System.EventHandler(this.squareRid_Click);
            // 
            // outerBorder
            // 
            this.outerBorder.Location = new System.Drawing.Point(301, 35);
            this.outerBorder.Name = "outerBorder";
            this.outerBorder.Size = new System.Drawing.Size(75, 23);
            this.outerBorder.TabIndex = 1;
            this.outerBorder.Text = "外图廓";
            this.outerBorder.UseVisualStyleBackColor = true;
            this.outerBorder.Click += new System.EventHandler(this.outerBorder_Click);
            // 
            // compass
            // 
            this.compass.Location = new System.Drawing.Point(208, 35);
            this.compass.Name = "compass";
            this.compass.Size = new System.Drawing.Size(75, 23);
            this.compass.TabIndex = 1;
            this.compass.Text = "指北针";
            this.compass.UseVisualStyleBackColor = true;
            this.compass.Click += new System.EventHandler(this.compass_Click);
            // 
            // scare
            // 
            this.scare.Location = new System.Drawing.Point(117, 35);
            this.scare.Name = "scare";
            this.scare.Size = new System.Drawing.Size(75, 23);
            this.scare.TabIndex = 1;
            this.scare.Text = "比例尺";
            this.scare.UseVisualStyleBackColor = true;
            this.scare.Click += new System.EventHandler(this.scare_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(24, 35);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(75, 23);
            this.name.TabIndex = 0;
            this.name.Text = "图名";
            this.name.UseVisualStyleBackColor = true;
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label18);
            this.tabPage9.Controls.Add(this.label17);
            this.tabPage9.Controls.Add(this.population);
            this.tabPage9.Controls.Add(this.classification);
            this.tabPage9.Controls.Add(this.radar);
            this.tabPage9.Controls.Add(this.indexAnalysis);
            this.tabPage9.Controls.Add(this.pieChart);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(984, 101);
            this.tabPage9.TabIndex = 7;
            this.tabPage9.Text = "统计分析";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(596, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 21);
            this.label18.TabIndex = 1;
            this.label18.Text = "数据统计";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(131, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 21);
            this.label17.TabIndex = 1;
            this.label17.Text = "可视化";
            // 
            // population
            // 
            this.population.Location = new System.Drawing.Point(674, 54);
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(75, 23);
            this.population.TabIndex = 0;
            this.population.Text = "人口";
            this.population.UseVisualStyleBackColor = true;
            this.population.Click += new System.EventHandler(this.population_Click);
            // 
            // classification
            // 
            this.classification.Location = new System.Drawing.Point(552, 54);
            this.classification.Name = "classification";
            this.classification.Size = new System.Drawing.Size(75, 23);
            this.classification.TabIndex = 0;
            this.classification.Text = "地类";
            this.classification.UseVisualStyleBackColor = true;
            this.classification.Click += new System.EventHandler(this.classification_Click);
            // 
            // radar
            // 
            this.radar.Location = new System.Drawing.Point(251, 54);
            this.radar.Name = "radar";
            this.radar.Size = new System.Drawing.Size(75, 23);
            this.radar.TabIndex = 0;
            this.radar.Text = "雷达图";
            this.radar.UseVisualStyleBackColor = true;
            this.radar.Click += new System.EventHandler(this.radar_Click);
            // 
            // indexAnalysis
            // 
            this.indexAnalysis.Location = new System.Drawing.Point(135, 54);
            this.indexAnalysis.Name = "indexAnalysis";
            this.indexAnalysis.Size = new System.Drawing.Size(75, 23);
            this.indexAnalysis.TabIndex = 0;
            this.indexAnalysis.Text = "拆旧潜力";
            this.indexAnalysis.UseVisualStyleBackColor = true;
            this.indexAnalysis.Click += new System.EventHandler(this.indexAnalysis_Click);
            // 
            // pieChart
            // 
            this.pieChart.Location = new System.Drawing.Point(23, 54);
            this.pieChart.Name = "pieChart";
            this.pieChart.Size = new System.Drawing.Size(75, 23);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "地类饼状图";
            this.pieChart.UseVisualStyleBackColor = true;
            this.pieChart.Click += new System.EventHandler(this.pieChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 703);
            this.Controls.Add(this.MapDecoration);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axTOCControl1);
            this.Name = "Form1";
            this.Text = "地表覆盖查询统计与编图系统——MrFrost";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.MapDecoration.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openAttributeTableToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MessageLabel;
        private System.Windows.Forms.ToolStripStatusLabel Blank;
        private System.Windows.Forms.ToolStripStatusLabel ScaleLabel;
        private System.Windows.Forms.ToolStripStatusLabel CoordinateLabel;
        private System.Windows.Forms.TabControl MapDecoration;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button OpenLyrBtn;
        private System.Windows.Forms.Button OpenShpBtn;
        private System.Windows.Forms.Button OpenMxdBtn;
        private System.Windows.Forms.Button FixedZoomoutBtn;
        private System.Windows.Forms.Button FixedZoominBtn;
        private System.Windows.Forms.Button ZoominBtn;
        private System.Windows.Forms.Button ZoomoutBtn;
        private System.Windows.Forms.Button GlobalViewBtn;
        private System.Windows.Forms.Button RoamBtn;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.Button MeasureBtn;
        private System.Windows.Forms.Button GotoBtn;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox LayerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectBtn;
        private TabPage tabPage7;
        private ComboBox EditBox;
        private Button SaveBtn;
        private Button StartEditBtn;
        private Button StopEditBtn;
        private Button UpdateBtn;
        private ComboBox EditLayerBox;
        private Button DeleteBtn;
        private Button UndoBtn;
        private Button RecoverBtn;
        private Label label3;
        private Label label2;
        private Button AttributeQueryBtn;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ToolStripMenuItem 删除图层ToolStripMenuItem;
        private Label label12;
        private TextBox textBox1;
        private TabPage tabPage4;
        private Button button2;
        private ComboBox IntersectBox2;
        private ComboBox IntersectBox1;
        private Label IntersectOutput;
        private Button BufferBtn;
        private Label BufferOutput;
        private Button button1;
        private Label label13;
        private Label label16;
        private Label label15;
        private Label label14;
        private TabPage tabPage8;
        private Button legend;
        private Button squareRid;
        private Button outerBorder;
        private Button compass;
        private Button scare;
        private Button name;
        private TabPage tabPage9;
        private Button population;
        private Button classification;
        private Button radar;
        private Button indexAnalysis;
        private Button pieChart;
        private Label label18;
        private Label label17;
    }

    class Edit
    {
        public bool mIsEditing;                          //编辑状态
        public bool mHasEdited;                         //是否编辑
        public IFeatureLayer mCurrentLayer;              //当前编辑图层
        private IWorkspaceEdit mWorkspaceEdit;            //编辑工作空间
        private IMap mMap;                                //地图
        private IDisplayFeedback mDisplayFeedback;        //用于鼠标与控件进行可视化交互
        private IFeature mPanFeature;                     //移动的要素
        public IFeature selectedFeature;
        public IPoint inputPoint;
        public IGeometry inputGeo;

        public Edit(IFeatureLayer editLayer, IMap map)
        {
            mCurrentLayer = editLayer;
            this.mMap = map;
        }

        public Edit()
        { 
        }

        //开始编辑
        public void StartEditing()
        {
            //获取要素工作空间
            IFeatureClass pFeatureClass = mCurrentLayer.FeatureClass;
            IWorkspace pWorkspace = (pFeatureClass as IDataset).Workspace;
            mWorkspaceEdit = pWorkspace as IWorkspaceEdit;
            if (mWorkspaceEdit == null)
                return;
            //开始编辑
            if (!mWorkspaceEdit.IsBeingEdited())
            {
                mWorkspaceEdit.StartEditing(true);
                mIsEditing = true;
            }
        }

        // 保存编辑
        // true时保存，false时不保存
        public void SaveEditing(bool save)
        {
            if (!save)
            {
                mWorkspaceEdit.StopEditing(false);
            }
            else if (save && mHasEdited && mIsEditing)
            {
                mWorkspaceEdit.StopEditing(true);
            }
            mHasEdited = false;
        }

        //停止编辑
        public void StopEditing(bool save)
        {
            this.SaveEditing(save);
            mIsEditing = false;
        }       

        public void CreateMouseDown(double mapX, double mapY)
        {
            //鼠标点击位置
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            INewLineFeedback pNewLineFeedback;
            INewPolygonFeedback pNewPolygonFeedback;

            //判断编辑状态
            if (mIsEditing)
            {
                //针对线和多边形，判断交互状态，第一次时要初始化，再次点击则直接添加节点
                if (mDisplayFeedback == null)
                {
                    //根据图层类型创建不同要素
                    switch (mCurrentLayer.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPoint:
                            //添加点要素
                            inputPoint = pPoint;//用于后面撤回操作
                            AddFeature(pPoint);
                            break;
                        case esriGeometryType.esriGeometryPolyline:
                            mDisplayFeedback = new NewLineFeedbackClass();
                            //获取当前屏幕显示
                            mDisplayFeedback.Display = ((IActiveView)this.mMap).ScreenDisplay;
                            pNewLineFeedback = mDisplayFeedback as INewLineFeedback;
                            //开始追踪
                            pNewLineFeedback.Start(pPoint);
                            break;
                        case esriGeometryType.esriGeometryPolygon:
                            mDisplayFeedback = new NewPolygonFeedbackClass();
                            mDisplayFeedback.Display = ((IActiveView)this.mMap).ScreenDisplay;
                            pNewPolygonFeedback = mDisplayFeedback as INewPolygonFeedback;
                            //开始追踪
                            pNewPolygonFeedback.Start(pPoint);
                            break;
                    }

                }
                else //第一次之后的点击则添加节点
                {
                    if (mDisplayFeedback is INewLineFeedback)
                    {
                        pNewLineFeedback = mDisplayFeedback as INewLineFeedback;
                        pNewLineFeedback.AddPoint(pPoint);
                    }
                    else if (mDisplayFeedback is INewPolygonFeedback)
                    {
                        pNewPolygonFeedback = mDisplayFeedback as INewPolygonFeedback;
                        pNewPolygonFeedback.AddPoint(pPoint);
                    }
                }
            }
        }

        public void MouseMove(double mapX, double mapY)
        {
            if (mDisplayFeedback == null)
                return;
            //获取鼠标移动点位，并移动至当前点位
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);
            mDisplayFeedback.MoveTo(pPoint);
        }

        public void CreateDoubleClick(double mapX, double mapY)
        {
            if (mDisplayFeedback == null)
                return;
            IGeometry pGeometry = null;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            INewLineFeedback pNewLineFeedback;
            INewPolygonFeedback pNewPolygonFeedback;
            IPointCollection pPointCollection;
            //判断编辑状态
            if (mIsEditing)
            {
                if (mDisplayFeedback is INewLineFeedback)
                {
                    pNewLineFeedback = mDisplayFeedback as INewLineFeedback;
                    //添加点击点
                    pNewLineFeedback.AddPoint(pPoint);
                    //结束Feedback
                    IPolyline pPolyline = pNewLineFeedback.Stop();
                    pPointCollection = pPolyline as IPointCollection;
                    //至少两点时才创建线要素
                    if (pPointCollection.PointCount < 2)
                        MessageBox.Show("至少需要两点才能建立线要素！", "提示");
                    else
                        pGeometry = pPolyline as IGeometry;
                }
                else if (mDisplayFeedback is INewPolygonFeedback)
                {
                    pNewPolygonFeedback = mDisplayFeedback as INewPolygonFeedback;
                    //添加点击点
                    pNewPolygonFeedback.AddPoint(pPoint);
                    //结束Feedback
                    IPolygon pPolygon = pNewPolygonFeedback.Stop();
                    pPointCollection = pPolygon as IPointCollection;
                    //至少三点才能创建线要素
                    if (pPointCollection.PointCount < 3)
                        MessageBox.Show("至少需要两点才能建立线要素！", "提示");
                    else
                        pGeometry = pPolygon as IGeometry;
                }
                mDisplayFeedback.Display = ((IActiveView)this.mMap).ScreenDisplay;
                //不为空时添加
                if (pGeometry != null)
                {
                    inputGeo = pGeometry;//用于后面撤回操作
                    AddFeature(pGeometry);
                    //创建完成将DisplayFeedback置为空
                    mDisplayFeedback = null;
                }
            }
        }

        public void PanMouseDown(double mapX, double mapY)
        {
            //清除地图选择集
            mMap.ClearSelection();
            //获取鼠标点击位置
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            IActiveView pActiveView = mMap as IActiveView;
            //获取点击到的要素
            mPanFeature =SelectFeature(pPoint);
            if (mPanFeature == null)
                return;
            //获取要素形状
            IGeometry pGeometry = mPanFeature.Shape;

            IMovePointFeedback pMovePointFeedback;
            IMoveLineFeedback pMoveLineFeedback;
            IMovePolygonFeedback pMovePolygonFeedback;
            //根据要素类型定义移动方式
            switch (pGeometry.GeometryType)
            {
                case esriGeometryType.esriGeometryPoint:
                    mDisplayFeedback = new MovePointFeedbackClass();
                    //获取屏幕显示
                    mDisplayFeedback.Display = pActiveView.ScreenDisplay;
                    //开始追踪
                    pMovePointFeedback = mDisplayFeedback as IMovePointFeedback;
                    pMovePointFeedback.Start((IPoint)pGeometry, pPoint);
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    mDisplayFeedback = new MoveLineFeedbackClass();
                    mDisplayFeedback.Display = pActiveView.ScreenDisplay;
                    //开始追踪
                    pMoveLineFeedback = mDisplayFeedback as IMoveLineFeedback;
                    pMoveLineFeedback.Start((IPolyline)pGeometry, pPoint);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    mDisplayFeedback = new MovePolygonFeedbackClass();
                    mDisplayFeedback.Display = pActiveView.ScreenDisplay;
                    //开始追踪
                    pMovePolygonFeedback = mDisplayFeedback as IMovePolygonFeedback;
                    pMovePolygonFeedback.Start((IPolygon)pGeometry, pPoint);
                    break;
            }
        }

        public void PanMouseUp(double mapX, double mapY)//移动要素
        {
            if (mDisplayFeedback == null)
                return;
            //获取点位
            IActiveView pActiveView = mMap as IActiveView;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            IMovePointFeedback pMovePointFeedback;
            IMoveLineFeedback pMoveLineFeedback;
            IMovePolygonFeedback pMovePolygonFeedback;
            IGeometry pGeometry;
            //根据移动要素类型选择移动方式
            if (mDisplayFeedback is IMovePointFeedback)
            {
                pMovePointFeedback = mDisplayFeedback as IMovePointFeedback;
                //结束追踪
                pGeometry = pMovePointFeedback.Stop();
                //更新要素
                UpdateFeature(mPanFeature, pGeometry);
            }
            else if (mDisplayFeedback is IMoveLineFeedback)
            {
                pMoveLineFeedback = mDisplayFeedback as IMoveLineFeedback;
                //结束追踪
                pGeometry = pMoveLineFeedback.Stop();
                //更新要素
                UpdateFeature(mPanFeature, pGeometry);
            }
            else if (mDisplayFeedback is IMovePolygonFeedback)
            {
                pMovePolygonFeedback = mDisplayFeedback as IMovePolygonFeedback;
                pGeometry = pMovePolygonFeedback.Stop();
                UpdateFeature(mPanFeature, pGeometry);
            }
            mDisplayFeedback = null;
            pActiveView.Refresh();
        }

        public void AddFeature(IPoint inputFeature)
        {
            IFeature pFeature;
            IFeatureClassWrite fr = mCurrentLayer.FeatureClass as IFeatureClassWrite;
            pFeature = mCurrentLayer.FeatureClass.CreateFeature();
            pFeature.Shape = inputFeature;
            fr.WriteFeature(pFeature);
            mHasEdited = true;
        }

        public void AddFeature(IGeometry inputFeature)
        {
            IFeature pFeature;
            IFeatureClassWrite fr = mCurrentLayer.FeatureClass as IFeatureClassWrite;
            pFeature = mCurrentLayer.FeatureClass.CreateFeature();
            pFeature.Shape = inputFeature;
            fr.WriteFeature(pFeature);
            mHasEdited = true;
        }

       /* public void UndoFeature()
        {
            IFeature pFeature;
            IFeatureClassWrite fr = mCurrentLayer.FeatureClass as IFeatureClassWrite;
            pFeature = mCurrentLayer.FeatureClass.CreateFeature();
            //IFeature pFeature;
            if (inputPoint != null)
            {
                pFeature.Shape = inputPoint;
                fr.RemoveFeature(pFeature);
                mHasEdited = true;
            }
            if (inputGeo != null)
            {

                pFeature.Shape = inputGeo;
                fr.RemoveFeature(pFeature);
                mHasEdited = true;
            }
        }*/

        //点选一个地点，选择一个要素（来源百度）
        private double ConvertPixelsToMapUnits(IActiveView pActiveView, double pixelUnits)//selectfeature中用到的一个辅助函数
        {
            // Uses the ratio of the size of the map in pixels to map units to do the conversion  
            IPoint p1 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperLeft;
            IPoint p2 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperRight;
            int x1, x2, y1, y2;
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p1, out x1, out y1);
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p2, out x2, out y2);
            double pixelExtent = x2 - x1;
            double realWorldDisplayExtent = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / pixelExtent;
            return pixelUnits * sizeOfOnePixel;
        }  

        private IFeature SelectFeature(IPoint pPoint)
        {
            IActiveView pActiveView = mMap as IActiveView;
            IFeatureLayer pFeatureLayer = mCurrentLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            //设置点击点的位置 
            ITopologicalOperator pTOpo = pPoint as ITopologicalOperator;
            double length;
            length = ConvertPixelsToMapUnits(pActiveView, 4);
            IGeometry pBuffer = pTOpo.Buffer(length);
            IGeometry pGeomentry = pBuffer.Envelope;
            //空间滤过器  
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.Geometry = pGeomentry;
            switch (pFeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }
            IFeatureSelection pFSelection = pFeatureLayer as IFeatureSelection;
            pFSelection.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            ISelectionSet pSelectionset = pFSelection.SelectionSet;
            ICursor pCursor;
            pSelectionset.Search(null, true, out pCursor);
            IFeatureCursor pFeatCursor = pCursor as IFeatureCursor;
            IFeature pFeature = pFeatCursor.NextFeature();
            selectedFeature = pFeature;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphicSelection, null, null);
            return pFeature;
        }

        //更新要素，主要来源于百度
        private bool UpdateFeature(IFeature ft, IGeometry igeo)
        {
            //若igeo为空的话不执行
            if (igeo == null) return false;
            if (igeo.IsEmpty) return false;

            IDataset dataset = ft.Class as IDataset;
            IWorkspaceEdit workspaceEdit = dataset.Workspace as IWorkspaceEdit;
            if (!workspaceEdit.IsBeingEdited()) return false;

            workspaceEdit.StartEditOperation();
            ft.Shape = igeo;
            // ft.Store();
            workspaceEdit.StopEditOperation();
            /*IFeatureSelection pFSelection = this.mCurrentLayer  as IFeatureSelection;
            pFSelection.Clear();
            pFSelection.Add(ft);
            ClearSelection();
            return true;*/

            IFeatureClassWrite wr = mCurrentLayer.FeatureClass as IFeatureClassWrite;
            // pFeature.Shape = inputFeature;
            //wr.RemoveFeature(ft
            wr.WriteFeature(ft);
            mHasEdited = true;
            return true;
        }

        public bool RemoveFeature()
        {
            if (selectedFeature == null)
                return false;
            IFeatureClassWrite wr = mCurrentLayer.FeatureClass as IFeatureClassWrite;
            wr.RemoveFeature(selectedFeature);
            return true;
        }

    }
}

