using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BLL;
using System.IO;

namespace GYMS
{
    public partial class FormDetail : Form
    {
        IndustryModel industryModel = new IndustryModel();
        public FormDetail(IndustryModel _industryModel )
        {
            InitializeComponent();
            industryModel = _industryModel;
            InitGlobal();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        public void InitGlobal()
        {
            label14.Text = industryModel.Name;
            label15.Text = industryModel.Address;
            label16.Text = industryModel.Department;
            label17.Text = industryModel.Distribution_characteristics;
            label18.Text = industryModel.Position_characteristics;
            label19.Text = industryModel.Terrain_features;
            label20.Text = industryModel.Geospatial_relationships;
            label21.Text = industryModel.Age;
            label22.Text = industryModel.Era;
            label23.Text = industryModel.Footprint;
            label24.Text = industryModel.Status_quo;
            label25.Text = industryModel.Protective_measures;
            label26.Text = industryModel.Current_use;
            //Text = industryModel.Name;

            if (industryModel.Picture.Length > 0)
            {
                MemoryStream stream = new MemoryStream(industryModel.Picture);
                //两种读取图片的方式
                //stream.Write(industryModel.Picture, 0, industryModel.Picture.Length);
                //pictureBox1.Image = new Bitmap(stream);
                pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                stream.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
