using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using myGISproject.Classes;
using ESRI.ArcGIS.SystemUI;
using myGISproject.Forms;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geodatabase;
using stdole;
namespace myGISproject
{
    public partial class Form1 : Form
    {
        private ILayer pLayer;//打开属性表的图层
        private string pMapUnits;//修改单位
        private Pan pan = null;
        private bool roamStatus = false;
        int Flag = 0;//控制放大缩小
        string LayPath;//读入的路径
        esriGeometryType EditType;//正在编辑的图层的类别
        IFeatureLayer editLayer;//正在编辑的图层
        Edit mEdit = new Edit();
        int bufferCount;
        public int caozuo = 0; //用于控制图名
        private IPoint m_PointPt = null;//鼠标点击位置
        private EnumMapSurroundType _enumMapSurType = EnumMapSurroundType.None;//添加的种类
        private EnumChartRenderType _enumChartType = EnumChartRenderType.UnKnown;  //图表
        private INewEnvelopeFeedback pNewEnvelopeFeedback;//鼠标获取矩形
        private IStyleGalleryItem pStyleGalleryItem;
        private OperatePageLayout m_OperatePageLayout = new OperatePageLayout();
        private frmSymbol frmSym = null;//控制符号窗口

        public Form1()
        {
            InitializeComponent();
        }



        private void axMapControl1_OnExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEvent e)
        {

            // 得到新范围
            IEnvelope pEnvelope = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            //在绘制前，清除axMapControl2中的任何图形元素
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pElement = pRectangleEle as IElement;
            pElement.Geometry = pEnvelope;
            //设置鹰眼图中的红线框
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0; pColor.Transparency = 255;
            //产生一个线符号对象
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 3; pOutline.Color = pColor;
            //设置颜色属性
            pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0; pColor.Transparency = 0;
            //设置填充符号的属性
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor; pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pElement as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeEle, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);//部分刷新

        }

        private void axMapControl1_OnMapReplaced(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEvent e)
        {
            if (axMapControl1.LayerCount > 0)
            {
                axMapControl2.Map = new MapClass();
                for (int i = axMapControl1.Map.LayerCount - 1; i >= 0; i--)
                {
                    axMapControl2.AddLayer(axMapControl1.get_Layer(i));
                }
                axMapControl2.Extent = axMapControl1.Extent;
                axMapControl2.Refresh();
            }
            CopyMapFromMapControlToPageLayoutControl();
            #region 坐标单位替换
            esriUnits mapUnits = axMapControl1.MapUnits;
            switch (mapUnits)
            {
                case esriUnits.esriCentimeters:
                    pMapUnits = "Centimeters";
                    break;
                case esriUnits.esriDecimalDegrees:
                    pMapUnits = "Decimal Degrees";
                    break;
                case esriUnits.esriDecimeters:
                    pMapUnits = "Decimeters";
                    break;
                case esriUnits.esriFeet:
                    pMapUnits = "Feet";
                    break;
                case esriUnits.esriInches:
                    pMapUnits = "Inches";
                    break;
                case esriUnits.esriKilometers:
                    pMapUnits = "Kilometers";
                    break;
                case esriUnits.esriMeters:
                    pMapUnits = "Meters";
                    break;
                case esriUnits.esriMiles:
                    pMapUnits = "Miles";
                    break;
                case esriUnits.esriMillimeters:
                    pMapUnits = "Millimeters";
                    break;
                case esriUnits.esriNauticalMiles:
                    pMapUnits = "NauticalMiles";
                    break;
                case esriUnits.esriPoints:
                    pMapUnits = "Points";
                    break;
                case esriUnits.esriUnknownUnits:
                    pMapUnits = "Unknown";
                    break;
                case esriUnits.esriYards:
                    pMapUnits = "Yards";
                    break;
            }
            #endregion


        }

        private void axMapControl2_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                axMapControl1.CenterAt(pPoint);
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }

        }

        private void axMapControl2_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (axMapControl2.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    axMapControl1.CenterAt(pPoint);
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = axMapControl2.TrackRectangle();
                    axMapControl1.Extent = pEnv;
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }

        }


        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (axMapControl1.LayerCount > 0)
            {
                esriTOCControlItem pItem = new esriTOCControlItem();
                pLayer = new FeatureLayerClass();
                IBasicMap pBasicMap = new MapClass();
                object pOther = new object();
                object pIndex = new object();
                // Returns the item in the TOCControl at the specified coordinates.
                axTOCControl1.HitTest(e.x, e.y, ref pItem, ref pBasicMap, ref pLayer, ref pOther, ref pIndex);
            }//TOCControl类的ITOCControl接口的HitTest方法
            if (e.button == 2)
            {
                contextMenuStrip1.Show(axTOCControl1, e.x, e.y);
            }
        }

        private void openAttributeTableToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //传入图层，在右击事件里返回的图层
            FrmAttribute frm1 = new FrmAttribute(pLayer);
            frm1.Show();
        }

        private void CopyMapFromMapControlToPageLayoutControl()
        {
            //获得IObjectCopy接口
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            //获得要拷贝的图层 
            System.Object pSourceMap = axMapControl1.Map;
            //获得拷贝图层
            System.Object pCopiedMap = pObjectCopy.Copy(pSourceMap);
            //获得要重绘的地图 
            System.Object pOverwritedMap = axPageLayoutControl1.ActiveView.FocusMap;
            //重绘pagelayout地图
            pObjectCopy.Overwrite(pCopiedMap, ref pOverwritedMap);
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            //获得IActiveView接口
            IActiveView pPageLayoutView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
            //获得IDisplayTransformation接口
            IDisplayTransformation pDisplayTransformation = pPageLayoutView.ScreenDisplay.DisplayTransformation;
            //设置可视范围
            pDisplayTransformation.VisibleBounds = axMapControl1.Extent;
            axPageLayoutControl1.ActiveView.Refresh(); //刷新地图
            //根据MapControl的视图范围，确定PageLayoutControl的视图范围
            CopyMapFromMapControlToPageLayoutControl();

        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            /*// 取得鼠标所在工具的索引号  
            int index = axToolbarControl1.HitTest(e.x, e.y, false); 
            if (index != -1)
            {
                // 取得鼠标所在工具的 ToolbarItem  
                IToolbarItem toolbarItem = axToolbarControl1.GetItem(index);
                // 设置状态栏信息  
                MessageLabel.Text = toolbarItem.Command.Message;
            }
            else
            {
                MessageLabel.Text = " 就绪 ";
            }*/
            // 显示当前比例尺
            ScaleLabel.Text = " 比例尺 1:" + ((long)this.axMapControl1.MapScale).ToString();
            // 显示当前坐标
            if (pMapUnits!=null)
            CoordinateLabel.Text = " 当前坐标 X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + pMapUnits.ToString();

            //漫游（BaseTool方法）
           if (pan != null)
                pan.OnMouseMove(e.button, e.shift, e.x, e.y);


           //判断是否处于编辑状态
           if (mEdit.mIsEditing&&!EditBox.SelectedItem.Equals("漫游模式"))
           {
               switch (EditBox.SelectedIndex)
               {
                   case 0:
                   case 1:
                       mEdit.MouseMove(e.mapX, e.mapY);
                       break;
               }
           }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //FileName:Gets or sets a string containing the file name selected in the file dialog box
            //string MxdPath = OpenMXD.FileName;
            //axMapControl1.LoadMxFile(); //IMapControl2的方法
            EditBox.Items.Add("新建");
            EditBox.Items.Add("移动或删除");
            EditBox.Items.Add("漫游模式");
            EditBox.SelectedIndex = 0;
            //开始编辑之前，将编辑按钮设为不可用
            //this.EditBox.Enabled = false;
            this.SaveBtn.Enabled = false;
            this.StopEditBtn.Enabled = false;
            this.DeleteBtn.Enabled = false;

        }


        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            //漫游（BaseTool方法）
            if (pan != null)
                pan.OnMouseUp(e.button, e.shift, e.x, e.y);

            //判断是否鼠标左键
            if (e.button != 1)
                return;
            //判断是否处于编辑状态
            if (mEdit.mIsEditing && !EditBox.SelectedItem.Equals("漫游模式"))
            {
                switch (EditBox.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        mEdit.PanMouseUp(e.mapX, e.mapY);//移动
                        break;
                }
            }

            if(mEdit.mHasEdited)
                this.SaveBtn.Enabled = true;
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope ipEnv;
            /*if (pan != null)
                pan.OnMouseDown(e.button, e.shift, e.x, e.y);*/
            if (Flag == 2)
            {
                ipEnv = axMapControl1.TrackRectangle();
                axMapControl1.Extent = ipEnv;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            else if (Flag == 1)
            {
                ipEnv = axMapControl1.TrackRectangle();
                ipEnv = axMapControl1.Extent;
                ipEnv.Expand(2, 2, true);
                axMapControl1.Extent = ipEnv;
            }


            //判断是否鼠标左键
            if (e.button != 1)
                return;
            //判断是否处于编辑状态
            if (mEdit.mIsEditing&&!EditBox.SelectedItem.Equals("漫游模式"))
            {
                //清除放大缩小和漫游，避免干扰
                Flag = 0;
                axMapControl1.CurrentTool = null;
                roamStatus = false;
                switch (EditBox.SelectedIndex)
                {
                    case 0:
                        mEdit.CreateMouseDown(e.mapX, e.mapY);
                        //如果编辑的是点，立即刷新地图，显示该点
                        if (EditType == esriGeometryType.esriGeometryPoint)
                            axMapControl1.Refresh();
                        break;
                    case 1:
                        mEdit.PanMouseDown(e.mapX, e.mapY);
                        axMapControl1.Refresh();
                        break;
                }
            }

        }


        private void RoamBtn_Click(object sender, EventArgs e)
        {
           /* Flag = 0;
            ///声明并初始化
            pan = new Pan();
            //关联MapControl
            pan.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状 
            //this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
            this.axMapControl1.CurrentTool = pan;*/
            Flag = 0;
            if (roamStatus == false)
            {
                ICommand pCommand = new ControlsMapPanToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(axMapControl1.Object);
                axMapControl1.CurrentTool = pTool;
                roamStatus = true;
            }
            else
            {
                axMapControl1.CurrentTool = null;
                roamStatus = false;
            }
        }

        private void RoamControl()
        { 
            if(roamStatus==true)
            {
                axMapControl1.CurrentTool = null;
                roamStatus = false;
            }
        }


        private void ZoominBtn_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
            Flag = 2;
            RoamControl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
            Flag = 1;
            RoamControl();
        }

        private void FixedZoominBtn_Click(object sender, EventArgs e)
        {
            //声明与初始化 
            FixedZoomIn fixedZoomin = new FixedZoomIn();
            //与MapControl关联
            fixedZoomin.OnCreate(this.axMapControl1.Object);
            fixedZoomin.OnClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsMapZoomOutFixedCommandClass();
            command.OnCreate(this.axMapControl1.Object);
            command.OnClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenMXD = new OpenFileDialog(); //可实例化类
            // Gets or sets the file dialog box title. (Inherited from FileDialog.)
            OpenMXD.Title = "打开地图"; // OpenFileDialog类的属性Title
            // Gets or sets the initial directory displayed by the file dialog box. 
            OpenMXD.InitialDirectory = @"E:\Documents\TIAN\personal materials\2018 FALL\地理信息系统课程设计\实习3\地图数据（实习三）\实习数据";
            // Gets or sets the current file name filter string ,Save as file type
            OpenMXD.Filter = "Map Documents (*.mxd)|*.mxd";
            if (OpenMXD.ShowDialog() == DialogResult.OK) //ShowDialog是类的方法
            {
                //FileName:Gets or sets a string containing the file name selected in the file dialog box
                string MxdPath = OpenMXD.FileName;
                axMapControl1.LoadMxFile(MxdPath); //IMapControl2的方法
            }
            updateCombobox();
        }

        private void OpenShpBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenShpFile = new OpenFileDialog();
            OpenShpFile.Title = "打开Shape文件";
            OpenShpFile.InitialDirectory = "C:";
            OpenShpFile.Filter = "Shape文件(*.shp)|*.shp";
            if (OpenShpFile.ShowDialog() == DialogResult.OK)
            {
                string ShapPath = OpenShpFile.FileName;
                int Position = ShapPath.LastIndexOf("\\"); //利用"\\"将文件路径分成两部分
                string FilePath = ShapPath.Substring(0, Position);
                string ShpName = ShapPath.Substring(Position + 1);
                axMapControl1.AddShapeFile(FilePath, ShpName);
            }
        }

        private void OpenLyrBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenLyrFile = new OpenFileDialog();
            OpenLyrFile.Title = "打开Lyr";
            OpenLyrFile.InitialDirectory = "C:";
            OpenLyrFile.Filter = "lyr文件(*.lyr)|*.lyr";
            if (OpenLyrFile.ShowDialog() == DialogResult.OK)
            {
                LayPath = OpenLyrFile.FileName;
                axMapControl1.AddLayerFromFile(LayPath);
            }
        }

        private void AttributeQueryBtn_Click(object sender, EventArgs e)
        {
            AttributeQueryForm atb = new AttributeQueryForm(this.axMapControl1);
            atb.Show();
        }

        private void GlobalViewBtn_Click(object sender, EventArgs e)
        {
            axMapControl1.Extent = axMapControl1.FullExtent;
        }


        private void button1_Click(object sender, EventArgs e)//查询
        {
            ICommand pCommand = new ControlsMapIdentifyToolClass();
            ITool pTool = pCommand as ITool;
            pCommand.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = pTool;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ICommand pCommand = new ControlsMapMeasureTool();
            ITool pTool = pCommand as ITool;
            pCommand.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = pTool;
        }

        private void GotoBtn_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ControlsMapGoToCommandClass();
            pCommand.OnCreate(axMapControl1.Object);
            pCommand.OnClick();
        }


        private void button6_Click_1(object sender, EventArgs e)
        {
            //判断MapControl中是否包含图层
            if (this.axMapControl1.LayerCount == 0)
                return;

            if (BufferOutput.Text.Equals(""))
            {
                MessageBox.Show("请设置输出路径");
                return;
            }

            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请输入缓冲区半径");
                return;
            }
            
            //在LayerBox中选中一个欲分析的图层
            ILayer pLayer = this.axMapControl1.Map.get_Layer(LayerBox.SelectedIndex);
            string test = this.axMapControl1.Map.get_Layer(LayerBox.SelectedIndex).Name;
            //输出路径,可以自行指定
            string strOutputPath = BufferOutput.Text + "\\buffer";

            //缓冲半径
            double dblDistace=0;
            if (Convert.ToDouble(this.textBox1.Text) > 0)
            {
                dblDistace = Convert.ToDouble(this.textBox1.Text);
                //获取一个geoprocessor的实例,避免与命名空间Geoprocessing中的Geoprocessor发生引用错误
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
                gp.OverwriteOutput = true;

                //创建一个Buffer工具的实例
                if (bufferCount != 0)//注意这句话！否则会因为命名重复不能在程序中多次生成缓冲区
                    strOutputPath += bufferCount.ToString();
                ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(pLayer, strOutputPath, dblDistace);
                //执行缓冲区分析
                IGeoProcessorResult results = null;
                results = gp.Execute(buffer, null) as IGeoProcessorResult;


                //判断缓冲区是否成功生成
                if (results.Status != esriJobStatus.esriJobSucceeded)
                    MessageBox.Show("图层" + pLayer.Name + "缓冲区生成失败！");
                else
                {
                    MessageBox.Show("缓冲区生成成功！");
                    //将生成图层加入MapControl
                    int index = strOutputPath.LastIndexOf("\\");
                    this.axMapControl1.AddShapeFile(strOutputPath.Substring(0, index), strOutputPath.Substring(index));
                    bufferCount++;
                    updateCombobox();
                }
            }
            else MessageBox.Show("输入半径错误！\n图层" + pLayer.Name + "缓冲区生成失败！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ControlsNewLineToolClass();
            ITool pTool = pCommand as ITool;
            pCommand.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = pTool;
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            ICommand pCommand = new ControlsSelectFeaturesToolClass();
            ITool pTool = pCommand as ITool;
            pCommand.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = pTool;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //清空原有选项
            EditLayerBox.Items.Clear();
            //没有添加图层时返回
            if (this.axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("MapControl中未添加图层！", "提示");
                return;
            }
            //加载图层
            for (int i = 0; i < this.axMapControl1.Map.LayerCount; i++)
            {
                ILayer pLayer = this.axMapControl1.get_Layer(i);
                EditLayerBox.Items.Add(pLayer.Name);
            }
            this.axMapControl1.Refresh();
            EditLayerBox.SelectedIndex = 0;

        }

        private void StartEditBtn_Click(object sender, EventArgs e)
        {
            //判断是否存在可编辑图层
            if (this.axMapControl1.Map.LayerCount == 0)
                return;
            if (this.EditLayerBox.Items.Count == 0)
            {
                MessageBox.Show("请选择要编辑的图层", "提示");
                return;
            }


            //获取编辑图层
            IMap pMap = this.axMapControl1.Map;
            IFeatureLayer pFeatureLayer = this.axMapControl1.get_Layer(EditLayerBox.SelectedIndex) as IFeatureLayer;
            editLayer = pFeatureLayer;
            //获取图层属性
            EditType = pFeatureLayer.FeatureClass.ShapeType;
            //初始化编辑
            if (mEdit == null)
            {
                mEdit = new Edit(pFeatureLayer, pMap);
            }
            //开始编辑
            mEdit.StartEditing();
            //开始编辑设为不可用，将其他编辑按钮设为可用
            this.StartEditBtn.Enabled = false;
            //this.EditBox.Enabled = true;
            //this.EditLayerBox.Enabled = false;
            this.DeleteBtn.Enabled = true;
            this.StopEditBtn.Enabled = true;
            this.SaveBtn.Enabled = true;
            //初始化按键
            if (this.EditBox.SelectedIndex == 0)
            {
                this.DeleteBtn.Enabled = false;
                this.UndoBtn.Enabled = false;
                this.RoamBtn.Enabled = false;
                this.GlobalViewBtn.Enabled = false;
                this.ZoominBtn.Enabled = false;
                this.ZoomoutBtn.Enabled = false;
                this.FixedZoominBtn.Enabled = false;
                this.FixedZoomoutBtn.Enabled = false;
                this.RecoverBtn.Enabled = false;
            }
            if (this.EditBox.SelectedIndex == 1)
            {
                this.DeleteBtn.Enabled = true;
                this.UndoBtn.Enabled = true;
                this.RoamBtn.Enabled = false;
                this.GlobalViewBtn.Enabled = false;
                this.ZoominBtn.Enabled = false;
                this.ZoomoutBtn.Enabled = false;
                this.FixedZoominBtn.Enabled = false;
                this.FixedZoomoutBtn.Enabled = false;
                this.RecoverBtn.Enabled = false;
            }
            if (this.EditBox.SelectedIndex == 2)
            {
                this.DeleteBtn.Enabled = false;
                this.UndoBtn.Enabled = false;
                this.RoamBtn.Enabled = true;
                this.GlobalViewBtn.Enabled = true;
                this.ZoominBtn.Enabled = true;
                this.ZoomoutBtn.Enabled = true;
                this.FixedZoominBtn.Enabled = true;
                this.FixedZoomoutBtn.Enabled = true;
                this.RecoverBtn.Enabled = true;
            }
        }

        private void StopEditBtn_Click(object sender, EventArgs e)
        {
            if (mEdit == null)         
                return;
            if (mEdit.mHasEdited)//编辑过
            {
                DialogResult dr = MessageBox.Show("图层已编辑，是否保存？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    mEdit.SaveEditing(true);
                    //重新设置按键的可用性
                    this.StartEditBtn.Enabled = true;
                    //this.EditBox.Enabled = false;
                    this.EditLayerBox.Enabled = true;
                    this.StopEditBtn.Enabled = false;
                    this.SaveBtn.Enabled = false;
                    this.DeleteBtn.Enabled = false;
                    mEdit = null;//清除mEdit，以免产生编辑时的操作
                    //刷新屏幕，使能够看到添加的要素
                    axMapControl1.Refresh();
                }
                else
                {
                    mEdit.SaveEditing(false);
                    //重新设置按键的可用性
                    this.StartEditBtn.Enabled = true;
                    //this.EditBox.Enabled = false;
                    this.EditLayerBox.Enabled = true;
                    this.StopEditBtn.Enabled = false;
                    this.SaveBtn.Enabled = false;
                    this.DeleteBtn.Enabled = false;
                    mEdit = null;//清除mEdit，以免产生编辑时的操作
                    //刷新屏幕，使没有保存的要素消失
                    axMapControl1.Refresh();
                }
            }
            else//未编辑过
            {
                //不保存
                mEdit.SaveEditing(false);
                mEdit = null;//清除mEdit，以免产生编辑时的操作
                //重新设置按键的可用性
                this.StartEditBtn.Enabled = true;
                this.EditLayerBox.Enabled = true;
                this.StopEditBtn.Enabled = false;
                this.SaveBtn.Enabled = false; 
                this.DeleteBtn.Enabled = false;
                axMapControl1.Refresh();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //判断编辑是否初始化
            if (mEdit == null)
                return;
            //处于编辑状态且已编辑则保存
            if (mEdit.mIsEditing && mEdit.mHasEdited)
            {
                mEdit.SaveEditing(true);
                //this.EditLayerBox.Enabled = true;
                //this.StartEditBtn.Enabled = true;
                //this.StopEditBtn.Enabled = false;
                this.SaveBtn.Enabled = false;
                //刷新屏幕，使能够看到添加的要素
                axMapControl1.Refresh();
                mEdit.mHasEdited = false;
            }
        }

        private void axMapControl1_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            //判断是否鼠标左键
            if (e.button != 1)
                return;

            //判断是否处于编辑状态
            if (mEdit.mIsEditing)
            {
                switch (EditBox.SelectedIndex)
                {
                    case 0:
                        mEdit.CreateDoubleClick(e.mapX, e.mapY);
                        if (EditType == esriGeometryType.esriGeometryPolyline || EditType == esriGeometryType.esriGeometryPolygon)
                            axMapControl1.Refresh();
                        break;
                    case 1:
                        break;
                }
            }

        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {

            if (editLayer == null) return;
            IFeatureLayer featLayer = editLayer as IFeatureLayer;
            IDataset dataset = featLayer.FeatureClass as IDataset;
            IWorkspaceEdit workspaceEdit = dataset.Workspace as IWorkspaceEdit;
            workspaceEdit.UndoEditOperation();
            this.axMapControl1.Refresh();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (mEdit.RemoveFeature())
            {
                mEdit.mHasEdited = true;
                this.SaveBtn.Enabled = true;
                //注意要刷新！
                axMapControl1.Refresh();
            }
        }

        private void RecoverBtn_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrow;
            Flag = 0;
            axMapControl1.CurrentTool = null;
            roamStatus = false;
        }

        private void AttributeQuery_Click(object sender, EventArgs e)
        {
            AttributeQueryForm frmattributequery = new AttributeQueryForm(this.axMapControl1);
            frmattributequery.Show();
        }

        private void 删除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.axMapControl1.Map.DeleteLayer(pLayer);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            dialog.SelectedPath = @"E:\Documents\TIAN\personal materials\2018 SPRING\地理信息系统工程设计\myGISproject";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.IntersectOutput.Text = dialog.SelectedPath;
            }  
        }


        bool updateCombobox()//更新所有ComboBox
        {
            //清空原有选项
            LayerBox.Items.Clear();
            IntersectBox1.Items.Clear();
            IntersectBox2.Items.Clear();
            //没有添加图层时返回
            if (this.axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("MapControl中未添加图层！", "提示");
                return false;
            }
            //加载图层
            for (int i = 0; i < this.axMapControl1.Map.LayerCount; i++)
            {
                ILayer pLayer = this.axMapControl1.get_Layer(i);
                LayerBox.Items.Add(pLayer.Name);
                IntersectBox1.Items.Add(pLayer.Name);
                IntersectBox2.Items.Add(pLayer.Name);
            }
            LayerBox.SelectedIndex = 0;
            IntersectBox1.SelectedIndex = 0;
            IntersectBox2.SelectedIndex = 0;
            this.axMapControl1.Refresh();
            return true;
        }

        private void BufferBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            dialog.SelectedPath = @"E:\Documents\TIAN\personal materials\2018 SPRING\地理信息系统工程设计\myGISproject";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.BufferOutput.Text = dialog.SelectedPath;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //添加两个以上图层时才允许叠置
            if (this.axMapControl1.LayerCount < 2)
            {
                MessageBox.Show("请添加两个以上图层");
                return;
            }

            if (this.IntersectBox1.SelectedIndex < 0 || this.IntersectBox2.SelectedIndex < 0)
                return;

            if (this.IntersectOutput.Text.Equals(""))
            {
                MessageBox.Show("请先设置输出路径");
                return;
            }

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
            gp.OverwriteOutput = true;


            //创建叠置分析实例
            Intersect intersectTool = new Intersect();
            //获取MapControl中的前两个图层
            ILayer pInputLayer1 = this.axMapControl1.get_Layer(this.IntersectBox1.SelectedIndex);
            ILayer pInputLayer2 = this.axMapControl1.get_Layer(this.IntersectBox2.SelectedIndex);
            //转换为object类型
            object inputfeature1 = pInputLayer1;
            object inputfeature2 = pInputLayer2;
            //设置参与叠置分析的多个对象
            IGpValueTableObject pObject = new GpValueTableObjectClass();
            pObject.SetColumns(2);
            pObject.AddRow(ref inputfeature1);
            pObject.AddRow(ref inputfeature2);
            intersectTool.in_features = pObject;
            //设置输出路径

            string strTempPath = this.IntersectOutput.Text;
            string strOutputPath = strTempPath + pInputLayer1.Name + "_" + pInputLayer2.Name + "_Intersect.shp";
            intersectTool.out_feature_class = strOutputPath;
            //执行叠置分析
            IGeoProcessorResult result = null;
            result = gp.Execute(intersectTool, null) as IGeoProcessorResult;

            //判断叠置分析是否成功
            if (result.Status != ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobSucceeded)
                MessageBox.Show("叠置求交失败!");
            else
            {
                MessageBox.Show("叠置求交成功！");
                int index = strOutputPath.LastIndexOf("\\");
                this.axMapControl1.AddShapeFile(strOutputPath.Substring(0, index), strOutputPath.Substring(index));
                intersectTool.in_features = null;
                updateCombobox();
            }

        }

        private void EditBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EditBox.SelectedIndex == 0)
            {
                this.DeleteBtn.Enabled = false;
                this.UndoBtn.Enabled = false;
                this.RoamBtn.Enabled = false;
                this.GlobalViewBtn.Enabled = false;
                this.ZoominBtn.Enabled = false;
                this.ZoomoutBtn.Enabled = false;
                this.FixedZoominBtn.Enabled = false;
                this.FixedZoomoutBtn.Enabled = false;
                this.RecoverBtn.Enabled = false;
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrow;
                Flag = 0;
                axMapControl1.CurrentTool = null;
                roamStatus = false;
            }
            if (this.EditBox.SelectedIndex == 1)
            {
                this.DeleteBtn.Enabled = true;
                this.UndoBtn.Enabled = true;
                this.RoamBtn.Enabled = false;
                this.GlobalViewBtn.Enabled = false;
                this.ZoominBtn.Enabled = false;
                this.ZoomoutBtn.Enabled = false;
                this.FixedZoominBtn.Enabled = false;
                this.FixedZoomoutBtn.Enabled = false;
                this.RecoverBtn.Enabled = false;
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrow;
                Flag = 0;
                axMapControl1.CurrentTool = null;
                roamStatus = false;
            }
            if (this.EditBox.SelectedIndex == 2)
            {
                this.DeleteBtn.Enabled = false;
                this.UndoBtn.Enabled = false;
                this.RoamBtn.Enabled = true;
                this.GlobalViewBtn.Enabled = true;
                this.ZoominBtn.Enabled = true;
                this.ZoomoutBtn.Enabled = true;
                this.FixedZoominBtn.Enabled = true;
                this.FixedZoomoutBtn.Enabled= true;
                this.RecoverBtn.Enabled = true;
            }
        }

        private void EditLayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mEdit != null)
            {
                mEdit.mCurrentLayer = this.axMapControl1.get_Layer(this.EditLayerBox.SelectedIndex) as IFeatureLayer;
                EditType = mEdit.mCurrentLayer.FeatureClass.ShapeType;
                //string test = this.axMapControl1.get_Layer(this.EditBox.SelectedIndex).Name;
            }
        }

        private void name_Click(object sender, EventArgs e)
        {
            if (caozuo == 1)
                caozuo = 0;
            else
                caozuo = 1;
        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            try
            {
                if (caozuo == 1)
                {
                    IActiveView pActiveView = null;
                    pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
                    m_PointPt = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

                    IGraphicsContainer pContainer = axPageLayoutControl1.PageLayout as IGraphicsContainer;
                    ITextElement ptext = new TextElementClass();
                    ptext.Text = "株林镇地表覆盖图";


                    IElement pEle = ptext as IElement;

                    pEle.Geometry = m_PointPt;

                    pContainer.AddElement(pEle, 0);
                    pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    caozuo = 0;
                }
                if (_enumMapSurType != EnumMapSurroundType.None)
                {
                    IActiveView pActiveView = null;
                    pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
                    m_PointPt = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                    if (pNewEnvelopeFeedback == null)
                    {
                        pNewEnvelopeFeedback = new NewEnvelopeFeedbackClass();
                        pNewEnvelopeFeedback.Display = pActiveView.ScreenDisplay;
                        pNewEnvelopeFeedback.Start(m_PointPt);
                    }
                    else
                    {
                        pNewEnvelopeFeedback.MoveTo(m_PointPt);
                        IEnvelope pEnvelope = pNewEnvelopeFeedback.Stop();
                        AddMapSurround(pActiveView, _enumMapSurType, pEnvelope);
                        pNewEnvelopeFeedback = null;
                        _enumMapSurType = EnumMapSurroundType.None;
                    }

                }
            }
            catch
            {
            }
        }

        private void AddMapSurround(IActiveView pAV, EnumMapSurroundType _enumMapSurroundType, IEnvelope pEnvelope)
        {
            try
            {
                switch (_enumMapSurroundType)
                {
                    case EnumMapSurroundType.NorthArrow:
                        addNorthArrow(axPageLayoutControl1.PageLayout, pEnvelope, pAV);
                        break;
                    case EnumMapSurroundType.ScaleBar:
                        makeScaleBar(pAV, axPageLayoutControl1.PageLayout, pEnvelope);
                        break;
                    case EnumMapSurroundType.Legend:
                        MakeLegend(pAV, axPageLayoutControl1.PageLayout, pEnvelope);
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        #region 指北针
        /// <summary>
        /// 插入指北针
        /// </summary>
        /// <param name="pPageLayout"></param>
        /// <param name="pEnv"></param>
        /// <param name="pActiveView"></param>
        void addNorthArrow(IPageLayout pPageLayout, IEnvelope pEnv, IActiveView pActiveView)
        {
            //  MessageBox.Show("1");
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null)
            {
                //  MessageBox.Show("2");
                return;
            }
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            INorthArrow pNorthArrow = new MarkerNorthArrowClass();
            pNorthArrow = pStyleGalleryItem.Item as INorthArrow;
            pNorthArrow.Size = pEnv.Width * 50;
            pMapSurroundFrame.MapSurround = (IMapSurround)pNorthArrow;//根据用户的选取，获取相应的MapSurround            
            IElement pElement = axPageLayoutControl1.FindElementByName("NorthArrows");//获取PageLayout中的指北针元素
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);  //如果存在指北针，删除已经存在的指北针
            }
            IElementProperties pElePro = null;
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = (IGeometry)pEnv;
            pElePro = pElement as IElementProperties;
            pElePro.Name = "NorthArrows";
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region  比例尺
        /// <summary>
        /// 比例尺
        /// </summary>
        /// <param name="pActiveView"></param>
        /// <param name="pPageLayout"></param>
        /// <param name="pEnv"></param>
        public void makeScaleBar(IActiveView pActiveView, IPageLayout pPageLayout, IEnvelope pEnv)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null) return;
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            pMapSurroundFrame.MapSurround = (IMapSurround)pStyleGalleryItem.Item;
            IElement pElement = axPageLayoutControl1.FindElementByName("ScaleBar");
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);  //删除已经存在的比例尺
            }
            IElementProperties pElePro = null;
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = (IGeometry)pEnv;
            pElePro = pElement as IElementProperties;
            pElePro.Name = "ScaleBar";
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region 添加图例
        /// <summary>
        /// 添加图例
        /// </summary>
        /// <param name="activeView"></活动窗口>
        /// <param name="pageLayout"></布局窗口>
        /// <param name="pEnv"></包络线>
        private void MakeLegend(IActiveView pActiveView, IPageLayout pPageLayout, IEnvelope pEnv)
        {
            UID pID = new UID();
            pID.Value = "esriCarto.Legend";
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pID, null);//根据唯一标示符，创建与之对应MapSurroundFrame
            IElement pDeletElement = axPageLayoutControl1.FindElementByName("Legend");//获取PageLayout中的图例元素
            if (pDeletElement != null)
            {
                pGraphicsContainer.DeleteElement(pDeletElement);  //如果已经存在图例，删除已经存在的图例
            }
            //设置MapSurroundFrame背景
            ISymbolBackground pSymbolBackground = new SymbolBackgroundClass();
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
            pLineSymbol.Color = m_OperatePageLayout.GetRgbColor(0, 0, 0);
            pFillSymbol.Color = m_OperatePageLayout.GetRgbColor(255, 255, 255);
            pFillSymbol.Outline = pLineSymbol;
            pSymbolBackground.FillSymbol = pFillSymbol;
            pMapSurroundFrame.Background = pSymbolBackground;
            //添加图例
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = pEnv as IGeometry;
            IMapSurround pMapSurround = pMapSurroundFrame.MapSurround;
            ILegend pLegend = pMapSurround as ILegend;
            pLegend.ClearItems();
            pLegend.Title = "图例";
            for (int i = 0; i < pActiveView.FocusMap.LayerCount; i++)
            {
                ILegendItem pLegendItem = new HorizontalLegendItemClass();
                pLegendItem.Layer = pActiveView.FocusMap.get_Layer(i);//获取添加图例关联图层             
                pLegendItem.ShowDescriptions = false;
                pLegendItem.Columns = 1;
                pLegendItem.ShowHeading = true;
                pLegendItem.ShowLabels = true;
                pLegend.AddItem(pLegendItem);//添加图例内容
            }
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region 方里网
        public void DeleteMapGrid(IActiveView pActiveView, IPageLayout pPageLayout)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer graphicsContainer = pPageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(pMap);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            if (mapGrids.MapGridCount > 0)
            {
                IMapGrid pMapGrid = mapGrids.get_MapGrid(0);
                mapGrids.DeleteMapGrid(pMapGrid);
            }
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);
        }

        public void CreateMeasuredGrid(IActiveView pActiveView, IPageLayout pPageLayout)
        {
            IMap map = pActiveView.FocusMap;
            IMeasuredGrid pMeasuredGrid = new MeasuredGridClass();
            //设置格网基本属性           
            pMeasuredGrid.FixedOrigin = false;
            pMeasuredGrid.Units = map.MapUnits;
            pMeasuredGrid.XIntervalSize = 1000;//纬度间隔           
            pMeasuredGrid.YIntervalSize = 1000;//经度间隔.             
            //设置GridLabel格式
            IGridLabel pGridLabel = new FormattedGridLabelClass();
            IFormattedGridLabel pFormattedGridLabel = new FormattedGridLabelClass();
            INumericFormat pNumericFormat = new NumericFormatClass();
            pNumericFormat.AlignmentOption = esriNumericAlignmentEnum.esriAlignLeft;
            pNumericFormat.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfDecimals;
            pNumericFormat.RoundingValue = 0;
            pNumericFormat.ZeroPad = true;
            pFormattedGridLabel.Format = pNumericFormat as INumberFormat;
            pGridLabel = pFormattedGridLabel as IGridLabel;
            stdole.StdFont myFont = new stdole.StdFont();
            myFont.Name = "宋体";
            myFont.Size = 25;
            pGridLabel.Font = myFont as stdole.IFontDisp;
            IMapGrid pMapGrid = new MeasuredGridClass();
            pMapGrid = pMeasuredGrid as IMapGrid;
            pMapGrid.LabelFormat = pGridLabel;
            //将格网添加到地图上           
            IGraphicsContainer graphicsContainer = pPageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(map);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            mapGrids.AddMapGrid(pMapGrid);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);
        }
        #endregion

        private void frmSym_GetSelSymbolItem(ref IStyleGalleryItem pStyleItem)
        {
            pStyleGalleryItem = pStyleItem;
        }

        private void scare_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.ScaleBar;
                if (frmSym == null || frmSym.IsDisposed)
                {
                    frmSym = new frmSymbol();
                    frmSym.GetSelSymbolItem += new frmSymbol.GetSelSymbolItemEventHandler(frmSym_GetSelSymbolItem);
                }
                frmSym.EnumMapSurType = _enumMapSurType;
                frmSym.InitUI();
                frmSym.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void compass_Click(object sender, EventArgs e)
        {
            _enumMapSurType = EnumMapSurroundType.NorthArrow;
            if (frmSym == null || frmSym.IsDisposed)
            {
                frmSym = new frmSymbol();
                frmSym.GetSelSymbolItem += new frmSymbol.GetSelSymbolItemEventHandler(frmSym_GetSelSymbolItem);
            }
            frmSym.EnumMapSurType = _enumMapSurType;
            frmSym.InitUI();
            frmSym.ShowDialog();
        }

        private void outerBorder_Click(object sender, EventArgs e)
        {
            try
            {
                IEnvelope NTK = new EnvelopeClass();
                ISelection selection = axMapControl1.Map.FeatureSelection;
                IEnumFeature enumFeature = (IEnumFeature)selection;
                enumFeature.Reset();
                IFeature sFeature = enumFeature.Next();
                while (sFeature != null)
                {
                    NTK.Union(sFeature.Extent);
                    sFeature = enumFeature.Next();
                }
                if (NTK.IsEmpty != true)
                {
                    NTK.Expand(1.1, 1.1, true);
                }
                IMap map = axMapControl1.Map;
                IGraphicsContainer pContainer = map as IGraphicsContainer;
                IActiveView pActiveView = (IActiveView)map;
                IRectangleElement pRectangleEle = new RectangleElementClass();
                IElement pEle = pRectangleEle as IElement;


                pEle.Geometry = NTK;

                IRgbColor pColor = new RgbColorClass();
                pColor.Red = 0;
                pColor.Green = 0;
                pColor.Blue = 0;
                pColor.Transparency = 255;
                //产生一个线符号对象
                ILineSymbol pOutline = new SimpleLineSymbolClass();
                pOutline.Width = 1;
                pOutline.Color = pColor;
                //设置颜色属性
                pColor = new RgbColorClass();
                pColor.Red = 0;
                pColor.Green = 0;
                pColor.Blue = 0;
                pColor.Transparency = 0;
                //设置填充符号的属性
                IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                pFillSymbol.Color = pColor;
                pFillSymbol.Outline = pOutline;
                IFillShapeElement pFillShapeEle = pEle as IFillShapeElement;
                pFillShapeEle.Symbol = pFillSymbol;
                pContainer.AddElement((IElement)pFillShapeEle, 0);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            }
            catch
            {
            }
        }

        private void squareRid_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView pActiveView = axPageLayoutControl1.ActiveView;
                IPageLayout pPageLayout = axPageLayoutControl1.PageLayout;
                DeleteMapGrid(pActiveView, pPageLayout);
                // CreateGraticuleMapGrid(pActiveView, pPageLayout);
                CreateMeasuredGrid(pActiveView, pPageLayout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void legend_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.Legend;
            }
            catch (Exception ex)
            {

            }
        }

        private void pieChart_Click(object sender, EventArgs e)
        {
            _enumChartType = EnumChartRenderType.PieChart;
            ILayer pLayer = null;
            IFeatureLayer mFeatureLayer = null;
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                ILayer pLayert;
                pLayert = axMapControl1.get_Layer(i);
                if (pLayert.Name == "XZQ")
                {
                    pLayer = pLayert;
                    mFeatureLayer = pLayert as IFeatureLayer;
                }
            }

            Dictionary<string, IRgbColor> _dicFieldAndColor = null;
            _dicFieldAndColor = new Dictionary<string, IRgbColor>();
            IRgbColor pRgbColor = null;
            OperateMap m_OperMap = new OperateMap();

            pRgbColor = m_OperMap.GetRgbColor(255, 217, 47);
            _dicFieldAndColor.Add("耕地", pRgbColor);
            pRgbColor = m_OperMap.GetRgbColor(141, 160, 203);
            _dicFieldAndColor.Add("园地", pRgbColor);
            pRgbColor = m_OperMap.GetRgbColor(252, 141, 98);
            _dicFieldAndColor.Add("城镇村工矿", pRgbColor);
            pRgbColor = m_OperMap.GetRgbColor(231, 138, 195);
            _dicFieldAndColor.Add("林地及草地", pRgbColor);
            pRgbColor = m_OperMap.GetRgbColor(166, 216, 84);
            _dicFieldAndColor.Add("水域", pRgbColor);
            pRgbColor = m_OperMap.GetRgbColor(154, 186, 240);
            _dicFieldAndColor.Add("交通运输", pRgbColor);
            pRgbColor = m_OperMap.GetRgbColor(36, 108, 175);
            _dicFieldAndColor.Add("其他", pRgbColor);

            ChartRenderer(mFeatureLayer, _dicFieldAndColor);
        }

        #region 饼图
        private void ChartRenderer(IFeatureLayer pFeatLyr, Dictionary<string, IRgbColor> dicFieldAndColor)
        {
            IGeoFeatureLayer pGeoFeatLyr = pFeatLyr as IGeoFeatureLayer;
            IChartRenderer pChartRender = new ChartRendererClass();
            IRendererFields pRenderFields = pChartRender as IRendererFields;
            IFeatureCursor pCursor = null;
            IDataStatistics pDataSta = null;
            double dMax = 0; double dTemp = 0;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pCursor = pGeoFeatLyr.Search(pQueryFilter, true);
            //遍历出所选择的第一个字段的最大值，，作为设置专题图的比例大小的依据
            foreach (KeyValuePair<string, IRgbColor> _keyValue in dicFieldAndColor)
            {
                pRenderFields.AddField(_keyValue.Key, _keyValue.Key);
                pDataSta = new DataStatisticsClass();
                pDataSta.Cursor = pCursor as ICursor;
                pDataSta.Field = _keyValue.Key;
                dTemp = pDataSta.Statistics.Maximum;
                if (dTemp >= dMax)
                {
                    dMax = dTemp;
                }
            }

            IRgbColor pRgbColor = null;
            IChartSymbol pChartSym = null;
            IFillSymbol pFillSymbol = null;
            IMarkerSymbol pMarkerSym = null;
            IBarChartSymbol pBarChartSym = null;
            IPieChartSymbol pPieChartSymbol = null;
            IStackedChartSymbol pStackChartSym = null;

            // 定义并设置渲染样式
            switch (_enumChartType)
            {
                case EnumChartRenderType.PieChart:
                    pPieChartSymbol = new PieChartSymbolClass();
                    pPieChartSymbol.Clockwise = true;//说明饼图是否顺时针方向
                    pPieChartSymbol.UseOutline = true;//说明是否使用轮廓线
                    ILineSymbol pLineSym = new SimpleLineSymbolClass();
                    //     pLineSym.Color = m_OperateMap.GetRgbColor(100, 205, 30) as IColor;
                    pLineSym.Width = 1;
                    pPieChartSymbol.Outline = pLineSym;
                    break;
                case EnumChartRenderType.BarChart:
                    pBarChartSym = new BarChartSymbolClass();
                    pBarChartSym.Width = 6;//设置每个条形图的宽度
                    break;
                case EnumChartRenderType.StackChart:
                    pStackChartSym = new StackedChartSymbolClass();
                    pStackChartSym.Width = 6;//设置每个堆叠图的宽度
                    break;
            }
            if (pPieChartSymbol != null)
            {
                pChartSym = pPieChartSymbol as IChartSymbol;
                pMarkerSym = pPieChartSymbol as IMarkerSymbol;
                pMarkerSym.Size = 50; //设置饼状图的大小
            }
            if (pBarChartSym != null)
            {
                pChartSym = pBarChartSym as IChartSymbol;
                pMarkerSym = pBarChartSym as IMarkerSymbol;
                pMarkerSym.Size = 50;//设置条形图的高度
            }
            else if (pStackChartSym != null)
            {
                pChartSym = pStackChartSym as IChartSymbol;
                pMarkerSym = pStackChartSym as IMarkerSymbol;
                pMarkerSym.Size = 60;//设置堆叠图的高度
            }
            pChartSym.MaxValue = dMax;
            ISymbolArray pSymArray = null;
            if (pBarChartSym != null)
            {
                pSymArray = pBarChartSym as ISymbolArray;
            }
            else if (pStackChartSym != null)
            {
                pSymArray = pStackChartSym as ISymbolArray;
            }
            else if (pPieChartSymbol != null)
            {
                pSymArray = pPieChartSymbol as ISymbolArray;
            }

            foreach (KeyValuePair<string, IRgbColor> _keyValue in dicFieldAndColor)
            {
                //获取渲染字段的颜色值
                pRgbColor = _keyValue.Value;
                pFillSymbol = new SimpleFillSymbolClass();
                pFillSymbol.Color = pRgbColor as IColor;
                pSymArray.AddSymbol(pFillSymbol as ISymbol);
            }
            if (pPieChartSymbol != null)
            {
                pChartRender.ChartSymbol = pPieChartSymbol as IChartSymbol;
            }
            if (pBarChartSym != null)
            {
                pChartRender.ChartSymbol = pBarChartSym as IChartSymbol;
            }
            else if (pStackChartSym != null)
            {
                pChartRender.ChartSymbol = pStackChartSym as IChartSymbol;
            }

            //     pFillSymbol = new SimpleFillSymbolClass();
            //      pFillSymbol.Color = m_OperateMap.GetRgbColor(239, 228, 190);
            //      pChartRender.BaseSymbol = pFillSymbol as ISymbol;// 设置背景符号
            //让符号处于图形中央（若渲染的图层为点图层，则该句应去掉，否则不显示渲染结果）
            //pChartRender.UseOverposter = false; 
            pChartRender.CreateLegend();
            pGeoFeatLyr.Renderer = pChartRender as IFeatureRenderer;
            axMapControl1.Refresh();
            axTOCControl1.Update();
            _enumChartType = EnumChartRenderType.UnKnown;
        }
        #endregion 
        private void indexAnalysis_Click(object sender, EventArgs e)
        {
            ILayer pLayer = null;
            IFeatureLayer mFeatureLayer = null;
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                ILayer pLayert;
                pLayert = axMapControl1.get_Layer(i);
                if (pLayert.Name == "XZQ - 副本")
                {
                    pLayer = pLayert;
                    mFeatureLayer = pLayert as IFeatureLayer;
                }
            }
            GraduatedColors(mFeatureLayer, "拆迁适宜度", 7);
        }

        public void GraduatedColors(IFeatureLayer pFeatLyr, string sFieldName, int numclasses)
        {
            IGeoFeatureLayer pGeoFeatureL = pFeatLyr as IGeoFeatureLayer;
            object dataFrequency;
            object dataValues;
            bool ok;
            int breakIndex;

            ITable pTable = pGeoFeatureL.FeatureClass as ITable;
            ITableHistogram pTableHistogram = new BasicTableHistogramClass();
            IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
            pTableHistogram.Field = sFieldName;
            pTableHistogram.Table = pTable;
            pBasicHistogram.GetHistogram(out dataValues, out dataFrequency);     //获取渲染字段的值及其出现的频率
            IClassifyGEN pClassify = new EqualIntervalClass();
            try
            {
                pClassify.Classify(dataValues, dataFrequency, ref  numclasses);  //根据获取字段的值和出现的频率对其进行等级划分 
            }
            catch (Exception ex)
            {

            }
            //返回一个数组
            double[] Classes = pClassify.ClassBreaks as double[];
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pClassBreaksRenderer = new ClassBreaksRendererClass();
            pClassBreaksRenderer.Field = sFieldName; //设置分级字段
            pClassBreaksRenderer.BreakCount = ClassesCount; //设置分级数目
            pClassBreaksRenderer.SortClassesAscending = true;//分级后的图例是否按升级顺序排列
            //设置分级着色所需颜色带的起止颜色
            IHsvColor pFromColor = new HsvColorClass();
            pFromColor.Hue = 0;//黄色
            pFromColor.Saturation = 10;
            pFromColor.Value = 96;
            IHsvColor pToColor = new HsvColorClass();
            pToColor.Hue = 0;
            pToColor.Saturation = 50;
            pToColor.Value = 96;
            //产生颜色带对象
            IAlgorithmicColorRamp pAlgorithmicCR = new AlgorithmicColorRampClass();
            pAlgorithmicCR.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            pAlgorithmicCR.FromColor = pFromColor;
            pAlgorithmicCR.ToColor = pToColor;
            pAlgorithmicCR.Size = ClassesCount;
            pAlgorithmicCR.CreateRamp(out ok);
            //获得颜色
            IEnumColors pEnumColors = pAlgorithmicCR.Colors;
            //需要注意的是分级着色对象中的symbol和break的下标都是从0开始
            for (breakIndex = 0; breakIndex <= ClassesCount - 1; breakIndex++)
            {
                IColor pColor = pEnumColors.Next();
                switch (pGeoFeatureL.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            ISimpleFillSymbol pSimpleFillS = new SimpleFillSymbolClass();
                            pSimpleFillS.Color = pColor;
                            pSimpleFillS.Style = esriSimpleFillStyle.esriSFSSolid;
                            pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleFillS);//设置填充符号
                            pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);//设定每一分级的分级断点
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                            pSimpleLineSymbol.Color = pColor;
                            pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleLineSymbol);
                            pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);
                            break;
                        }
                    case esriGeometryType.esriGeometryPoint:
                        {
                            ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                            pSimpleMarkerSymbol.Color = pColor;
                            pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleMarkerSymbol);//设置填充符号
                            pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);//设定每一分级的分级断点
                            break;
                        }
                }
            }
            pGeoFeatureL.Renderer = (IFeatureRenderer)pClassBreaksRenderer;
            axMapControl1.Refresh();
            axTOCControl1.Update();
        }

        private void radar_Click(object sender, EventArgs e)
        {
            //新范围
            IGraphicsContainer pGraphicsContainer = axMapControl1.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();


            #region 定义填充颜色与类型
            IRgbColor pColor = new RgbColorClass();//颜色
            pColor.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();//(B,G,R)
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();//产生一个线符号对象
            pLineSymbol.Width = 0.2;
            pLineSymbol.Color = pColor;
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();//设置填充符号的属性
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pLineSymbol;
            #endregion

            IPoint pPoint = new PointClass();
            pPoint.PutCoords(38634004, 3357284);


            //画圈
            int r = 400;
            for (int i = 0; i < 3; i++)
            {
                IConstructCircularArc pConstructCircularArc = new CircularArcClass();
                pConstructCircularArc.ConstructCircle(pPoint, r + i * r, false);
                ICircularArc pArc = pConstructCircularArc as ICircularArc;
                ISegment pSegment1 = pArc as ISegment; //通过ISegmentCollection构建Ring对象
                ISegmentCollection pSegCollection = new RingClass();
                object o = Type.Missing; //添加Segement对象即圆
                pSegCollection.AddSegment(pSegment1, ref o, ref o); //QI到IRing接口封闭Ring对象，使其有效
                IRing pRing = pSegCollection as IRing;
                pRing.Close(); //通过Ring对象使用IGeometryCollection构建Polygon对象


                IGeometryCollection pGeometryColl = new PolygonClass();
                pGeometryColl.AddGeometry(pRing, ref o, ref o); //构建一个CircleElement对象
                IElement pElement = new CircleElementClass();
                pElement.Geometry = pGeometryColl as IGeometry;


                //填充圆的颜色
                IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
                pFillShapeElement.Symbol = pFillSymbol;
                IGraphicsContainer pGC = this.axMapControl1.ActiveView.GraphicsContainer;
                pGC.AddElement(pElement, 0);
            }

            //画柱
            for (int i = 0; i < 18; i++)
            {

                IPoint pPoint2;
                pPoint2 = new PointClass();
                double x;
                double y;
                x = pPoint.X + 3 * r * Math.Cos(2 * i * Math.PI / 18);
                y = pPoint.Y + 3 * r * Math.Sin(2 * i * Math.PI / 18);

                pPoint2.PutCoords(x, y);
                ILine pLine;
                pLine = new LineClass();
                pLine.PutCoords(pPoint, pPoint2);
                IGeometryCollection pPolyline;
                pPolyline = new PolylineClass();
                ISegmentCollection pPath;
                pPath = new PathClass();
                object Missing1 = Type.Missing;
                object Missing2 = Type.Missing;
                pPath.AddSegment(pLine as ISegment, ref Missing1, ref Missing2);
                pPolyline.AddGeometry(pPath as IGeometry, ref Missing1, ref Missing2);

                IRgbColor rGBColor = new RgbColorClass();
                rGBColor.Red = 0;
                rGBColor.Green = 0;
                rGBColor.Blue = 0;

                IElement element = DrawLineSymbol(pPolyline as IGeometry, rGBColor);

                pGraphicsContainer.AddElement(element, 0);
            }
            //读txt
            // string dir = "E:\\王令琦\\王令琦\\实习三\\";
            string dir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "data\\";
            string file = "雷达图数据.txt";
            StreamReader sr = new StreamReader(dir + file);
            /* while (sr.Peek() > -1)
             {
                 MessageBox.Show(sr.ReadToEnd());
             }
             */
            ArrayList DataStore = new ArrayList();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] sArray = line.Split(',');
                Data data = new Data();
                data.qs = sArray[0];
                data.rjgd = sArray[1];
                DataStore.Add(data);
            }


            sr.Close();

            //画数据
            IPoint[] points = new IPoint[DataStore.Count];
            for (int i = 0; i < DataStore.Count; i++)
            {
                Data a = DataStore[i] as Data;
                string str = a.rjgd;
                double number = double.Parse(str);

                double x;
                double y;
                x = pPoint.X + number * 3 * r * Math.Cos(2 * i * Math.PI / 18) / 1565;
                y = pPoint.Y + number * 3 * r * Math.Sin(2 * i * Math.PI / 18) / 1565;
                IPoint pt = new PointClass();
                pt.PutCoords(x, y);
                points[i] = pt;
                //MessageBox.Show("坐标生成");

            }

            for (int i = 0; i < 17; i++)
            {
                ILine pLine;
                pLine = new LineClass();
                pLine.PutCoords(points[i], points[i + 1]);
                IGeometryCollection pPolyline;
                pPolyline = new PolylineClass();
                ISegmentCollection pPath;
                pPath = new PathClass();
                object Missing1 = Type.Missing;
                object Missing2 = Type.Missing;
                pPath.AddSegment(pLine as ISegment, ref Missing1, ref Missing2);
                pPolyline.AddGeometry(pPath as IGeometry, ref Missing1, ref Missing2);

                IRgbColor rGBColor = new RgbColorClass();
                rGBColor.Red = 100;
                rGBColor.Green = 0;
                rGBColor.Blue = 0;

                IElement element = DrawLineSymbol(pPolyline as IGeometry, rGBColor);

                pGraphicsContainer.AddElement(element, 0);
            }
            ILine pLine2;
            pLine2 = new LineClass();
            pLine2.PutCoords(points[17], points[0]);
            IGeometryCollection pPolyline2;
            pPolyline2 = new PolylineClass();
            ISegmentCollection pPath2;
            pPath2 = new PathClass();
            object Missing12 = Type.Missing;
            object Missing22 = Type.Missing;
            pPath2.AddSegment(pLine2 as ISegment, ref Missing12, ref Missing22);
            pPolyline2.AddGeometry(pPath2 as IGeometry, ref Missing12, ref Missing22);

            IRgbColor rGBColor2 = new RgbColorClass();
            rGBColor2.Red = 100;
            rGBColor2.Green = 0;
            rGBColor2.Blue = 0;

            IElement element2 = DrawLineSymbol(pPolyline2 as IGeometry, rGBColor2);

            pGraphicsContainer.AddElement(element2, 0);



            //注记
            IFontDisp pFont = new StdFont()
            {
                Name = "宋体",
                Size = 5
            } as stdole.IFontDisp;

            ITextSymbol pTextSymbol = new TextSymbolClass()
            {
                Color = pColor,
                Font = pFont,
                Size = 11
            };
            IGraphicsContainer pGraContainer = axMapControl1.Map as IGraphicsContainer;
            this.axMapControl1.Refresh();

        }

        private IElement DrawLineSymbol(IGeometry pGeometry, IRgbColor pColor)
        {
            IElement element = null;
            //线符号样式
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Color = pColor;
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            simpleLineSymbol.Width = 1;
            //线
            ILineElement lineElement = new ESRI.ArcGIS.Carto.LineElementClass();
            lineElement.Symbol = simpleLineSymbol;
            element = (IElement)lineElement;
            element.Geometry = pGeometry;
            return element;
        }

        private void classification_Click(object sender, EventArgs e)
        {
            statisticland st1 = new statisticland(this.axMapControl1);
            st1.Show();
        }

        private void population_Click(object sender, EventArgs e)
        {
            population st1 = new population(axMapControl1);
            st1.Show(); 
        }

    }

    public class Data
    {
        public string qs;
        public string rjgd;

    }


}
