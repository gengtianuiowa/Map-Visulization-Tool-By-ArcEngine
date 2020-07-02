using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase; 


namespace myGISproject.Forms
{
    public partial class AttributeQueryForm : Form
    {

        //地图数据 
        private AxMapControl mMapControl;
        //选中图层 
        private IFeatureLayer mFeatureLayer;
        //根据所选择的图层查询得到的特征类
        private IFeatureClass pFeatureClass = null;

        public AttributeQueryForm(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
        }

        private void AttributeQueryForm_Load(object sender, EventArgs e)
        {
            //MapControl中没有图层时返回 
            if (this.mMapControl.LayerCount <= 0)
                return;
            //获取MapControl中的全部图层名称，并加入ComboBox 
            //图层 
            ILayer pLayer;
            //图层名称 
            string strLayerName;
            for (int i = 0; i < this.mMapControl.LayerCount; i++)
            {
                pLayer = this.mMapControl.get_Layer(i);
                strLayerName = pLayer.Name;
                //图层名称加入cboLayer 
                this.cboLayer.Items.Add(strLayerName);
            }
            //默认显示第一个选项 
            this.cboLayer.SelectedIndex = 0;

        }

        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //清空listBoxField控件的内容
            this.listBoxField.Items.Clear();
            //获取cboLayer中选中的图层 
            mFeatureLayer = mMapControl.get_Layer(cboLayer.SelectedIndex) as IFeatureLayer;
            pFeatureClass = mFeatureLayer.FeatureClass;
            //字段名称 
            string strFldName;
            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                strFldName = pFeatureClass.Fields.get_Field(i).Name;
                //图层名称加入cboField 
                this.listBoxField.Items.Add(strFldName);
            }
            //默认显示第一个选项 
            this.listBoxField.SelectedIndex = 0;

        }

        private void listBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sFieldName = listBoxField.Text;
            listBoxValue.Items.Clear();
            int iFieldIndex = 0;
            IField pField = null;
            IFeatureCursor pFeatCursor = pFeatureClass.Search(null, true);
            IFeature pFeat = pFeatCursor.NextFeature();
            iFieldIndex = pFeatureClass.FindField(sFieldName);
            pField = pFeatureClass.Fields.get_Field(iFieldIndex);
            while (pFeat != null)
            {
                listBoxValue.Items.Add(pFeat.get_Value(iFieldIndex));
                pFeat = pFeatCursor.NextFeature();
            }

        }

        private void listBoxValue_DoubleClick(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = listBoxValue.SelectedItem.ToString()  + " ";
        }

        private void listBoxField_DoubleClick(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = listBoxField.SelectedItem.ToString()  + " ";
        }

        private void Btnequal_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "= ";
        }

        private void Btnis_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "is ";

        }

        private void Btnunequal_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "!=";
        }

        private void Btnlike_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "like";
        }

        private void Btnmore_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = ">";
        }

        private void Btnless_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "<";
        }

        private void Btnmoe_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = ">=";
        }

        private void Btnloe_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "<=";
        }

        private void Btnor_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "or";
        }

        private void btnnull_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "null";
        }

        private void Btnnot_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "not";
        }

        private void btnand_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "and";
        }

        private void Btnin_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "ln";
        }

        private void Btnunderline_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "_";
        }

        private void Btnpercent_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "%";
        }

        private void Btncharacter_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "''";
        }

        private void Btnbetween_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = "between";
        }

        private void Btnspace_Click(object sender, EventArgs e)
        {
            textBoxSql.SelectedText = " ";
        }

        private void Btnempty_Click(object sender, EventArgs e)
        {
            this.textBoxSql.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                mMapControl.Map.ClearSelection(); //清除上次查询结果
                IActiveView pActiveView = mMapControl.Map as IActiveView;
                //pQueryFilter的实例化 
                IQueryFilter pQueryFilter = new QueryFilterClass();
                //设置查询过滤条件 
                pQueryFilter.WhereClause = textBoxSql.Text;
                //查询 ,search的参数第一个为过滤条件，第二个为是否重复执行
                IFeatureCursor pFeatureCursor = mFeatureLayer.Search(pQueryFilter, false);
                //获取查询到的要素 
                IFeature pFeature = pFeatureCursor.NextFeature();
                //判断是否获取到要素 
                while (pFeature != null)
                {
                    mMapControl.Map.SelectFeature(mFeatureLayer, pFeature); //选择要素 
                    mMapControl.Extent = pFeature.Shape.Envelope; //放大到要素
                    pFeature = pFeatureCursor.NextFeature();
                }
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                pActiveView.Refresh();//刷新图层
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
