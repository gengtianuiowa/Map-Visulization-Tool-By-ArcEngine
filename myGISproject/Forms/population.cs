using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace myGISproject.Forms
{
    public partial class population : Form
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
        public population(ESRI.ArcGIS.Controls.AxMapControl mapControl)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
        }

        private void population_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();//每次查询前都将当前的表数据显示栏清空
            listView1.Columns.Add("权属名称", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("人口", 100, HorizontalAlignment.Center);


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
                if (strLayerName == "株林镇分村人口")
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
                index = pFeatureClass.Fields.FindField("XZQMC");
                string qs = pFeature.get_Value(index).ToString();
                index = pFeatureClass.Fields.FindField("XZQRK");
                string rk = pFeature.get_Value(index).ToString();
                ListViewItem li = new ListViewItem(qs);
                li.SubItems.Add(rk);
                listView1.Items.Add(li);
                Datar data = new Datar();
                data.qs = qs;
                data.rk = int.Parse(rk);
                DataStore.Add(data);
                pFeature = featureCursor.NextFeature();
            }
            /*string pathout = "E:\\rk.txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(pathout, true);
            for (int i = 0; i < DataStore.Count; i++)
            {
                Datar a = DataStore[i] as Datar;
                sw.WriteLine(a.qs + "," + a.rk);
            }
            sw.Close();
            sw.Dispose();*/
        }
    }
    public class Datar
    {
        public string qs;
        public int rk;

    }
}
