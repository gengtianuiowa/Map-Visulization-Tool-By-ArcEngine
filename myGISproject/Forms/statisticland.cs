using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Collections;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace myGISproject.Forms
{
    public partial class statisticland : Form
    {
        // C#动态数组
        public ArrayList DataStore = new ArrayList();
        //地图数据 
        private ESRI.ArcGIS.Controls.AxMapControl mMapControl;
        //选中图层 
        private IFeatureLayer mFeatureLayer;
        //根据所选择的图层查询得到的特征类
        private IFeatureClass pFeatureClass = null;
        private int indexrk = 0;
        private ILayer pLayerrk;
        public statisticland(ESRI.ArcGIS.Controls.AxMapControl mapControl)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
        }

        private void statisticland_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();//每次查询前都将当前的表数据显示栏清空
            listView1.Columns.Add("权属名称", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("id", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("园地", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("城镇村及工矿", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("林地及草地", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("水域", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("耕地", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("交通运输", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("其他", 100, HorizontalAlignment.Center);


            //MapControl中没有图层时返回 
            if (this.mMapControl.LayerCount <= 0)
                return;
            //获取MapControl中的全部图层名称，并加入ComboBox 
            //图层 
            ILayer pLayer;
            int index = 0;

            //图层名称 
            string strLayerName;
            for (int i = 0; i < this.mMapControl.LayerCount; i++)
            {
                pLayer = this.mMapControl.get_Layer(i);
                strLayerName = pLayer.Name;
                if (strLayerName == "XZQ")
                {
                    indexrk = i;
                    pLayerrk = pLayer;

                }

            }
            //获取人口图层所有属性数据
            //MessageBox.Show("未能找到有效路径", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);     
            mFeatureLayer = mMapControl.get_Layer(indexrk) as IFeatureLayer;
            pFeatureClass = mFeatureLayer.FeatureClass;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.SubFields = "";
            pQueryFilter.WhereClause = "";
            IFeatureCursor featureCursor;
            featureCursor = pFeatureClass.Search(pQueryFilter, false);
            IFeature pFeature;
            pFeature = featureCursor.NextFeature();


            while (pFeature != null)
            {
                index = pFeatureClass.Fields.FindField("QSDWMC");
                string qs = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("id");
                string id = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("园地");
                string yd = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("城镇村工矿");
                string czcgk = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("林地及草地");
                string ldjcd = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("水域");
                string sy = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("耕地");
                string gd = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("交通运输");
                string jtys = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("其他");
                string qt = pFeature.get_Value(index).ToString();
                ListViewItem li = new ListViewItem(qs);
                li.SubItems.Add(id);
                li.SubItems.Add(yd);
                li.SubItems.Add(czcgk);
                li.SubItems.Add(ldjcd);
                li.SubItems.Add(sy);
                li.SubItems.Add(gd);
                li.SubItems.Add(jtys);
                li.SubItems.Add(qt);
                listView1.Items.Add(li);

                Data data = new Data();
                data.qs1 = qs;
                data.id1 = double.Parse(id);
                data.yd1 = double.Parse(yd);
                data.czcgk1 = double.Parse(czcgk);
                data.ldjcd1 = double.Parse(ldjcd);
                data.sy1 = double.Parse(sy);
                data.gd1 = double.Parse(gd);
                data.jtys1 = double.Parse(jtys);
                data.qt1 = double.Parse(qt);

                DataStore.Add(data);

                pFeature = featureCursor.NextFeature();
            }
           /* string pathout = "E:\\Documents\\TIAN\\personal materials\\2018 FALL\\地理信息系统课程设计\\实习3";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(pathout, true);
            for (int i = 0; i < DataStore.Count; i++)
            {
                Data a = DataStore[i] as Data;
                sw.WriteLine(a.qs1 + "," + a.gd1 + "," + a.cd1 + "," + a.ld1 + "," + a.yd1 + "," + a.sy1 + "," + a.fw1);
            }
            sw.Close();
            sw.Dispose();*/
        }
    }
    public class Data
    {
        public string qs1;
        public double id1;
        public double yd1;
        public double czcgk1;
        public double ldjcd1;
        public double sy1;
        public double gd1;
        public double jtys1;
        public double qt1;
    }
}
