using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BLL;
namespace GYMS
{
    public partial class FormGYUpdate : Form
    {
        IndustryModel industryModel = new IndustryModel();
        IndustryModel industryModel_revise = new IndustryModel();
        public FormGYUpdate(IndustryModel model)
        {
            InitializeComponent();
            industryModel = model;
            InitGlobal();
        }
        /// <summary>
        /// 初始化界面,按照名字如果为修改，名字不能变（时间问题还没修改）
        /// </summary>
        public void InitGlobal()
        {
            if (industryModel.Name != "")
            {
                if (industryModel.Picture != null)
                {
                    MemoryStream stream = new MemoryStream(industryModel.Picture);
                    //两种读取图片的方式
                    //stream.Write(industryModel.Picture, 0, industryModel.Picture.Length);
                    //pictureBox1.Image = new Bitmap(stream);
                    pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                    stream.Close();
                }
                ucTextBoxEx1.InputText = industryModel.Name;
                ucTextBoxEx2.InputText = industryModel.Address;
                ucTextBoxEx3.InputText = industryModel.Department;
                ucTextBoxEx4.InputText = industryModel.Distribution_characteristics;
                ucTextBoxEx5.InputText = industryModel.Position_characteristics;
                ucTextBoxEx6.InputText = industryModel.Terrain_features;
                ucTextBoxEx7.InputText = industryModel.Geospatial_relationships;
                ucTextBoxEx8.InputText = industryModel.Age;
                ucTextBoxEx9.InputText = industryModel.Era;
                ucTextBoxEx10.InputText = industryModel.Footprint;
                ucTextBoxEx11.InputText = industryModel.Status_quo;
                ucTextBoxEx12.InputText = industryModel.Protective_measures;
                ucTextBoxEx13.InputText = industryModel.Current_use;
                ucBtnExt2.Visible = true;
                ucBtnExt4.Visible = false;
            }
            else
            {
                ucBtnExt2.Visible = false;
                ucBtnExt4.Visible = true;
            }
            
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*.jpg,*jpeg,*.bmp,*.ico,*.png,*.tif,*.wmf|*.jpg;*jpeg;*.bmp;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.Title = "选择用户头像";
            //判断是否选择了头像
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //显示选择的用户头像
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                FileStream FStream = new FileStream(//创建文件流对象
openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader BReader = new BinaryReader(FStream);//创建二进制流对象
                industryModel_revise.Picture = BReader.ReadBytes((int)FStream.Length);//得到字节数组
                FStream.Close();
                BReader.Close();
            }
        }
        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            ucTextBoxEx1.InputText = "";
            ucTextBoxEx2.InputText = "";
            ucTextBoxEx3.InputText = "";
            ucTextBoxEx4.InputText = "";
            ucTextBoxEx5.InputText = "";
            ucTextBoxEx6.InputText = "";
            ucTextBoxEx7.InputText = "";
            ucTextBoxEx8.InputText = "";
            ucTextBoxEx9.InputText = "";
            ucTextBoxEx10.InputText = "";
            ucTextBoxEx11.InputText = "";
            ucTextBoxEx12.InputText = "";
            ucTextBoxEx13.InputText = "";
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ucBtnExt4_BtnClick(object sender, EventArgs e)
        {
            industryModel_revise.Name = ucTextBoxEx1.InputText;
            industryModel_revise.Address = ucTextBoxEx2.InputText;
            industryModel_revise.Department = ucTextBoxEx3.InputText;
            industryModel_revise.Distribution_characteristics = ucTextBoxEx4.InputText;
            industryModel_revise.Position_characteristics = ucTextBoxEx5.InputText;
            industryModel_revise.Terrain_features = ucTextBoxEx6.InputText;
            industryModel_revise.Geospatial_relationships = ucTextBoxEx7.InputText;
            industryModel_revise.Age = ucTextBoxEx8.InputText;
            industryModel_revise.Era = ucTextBoxEx9.InputText;
            industryModel_revise.Footprint = ucTextBoxEx10.InputText;
            industryModel_revise.Status_quo = ucTextBoxEx11.InputText;
            industryModel_revise.Protective_measures = ucTextBoxEx12.InputText;
            industryModel_revise.Current_use = ucTextBoxEx13.InputText;

            IndustryBLL industryBLL = new IndustryBLL();
            if (industryBLL.Insert(industryModel_revise, out string messageStr) == true)
            {
                MessageBox.Show(messageStr);
                DialogResult = DialogResult.OK;//注册成功，关闭界面
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
        /// <summary>
        /// 修改工业遗产信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            industryModel_revise.Name = ucTextBoxEx1.InputText;
            industryModel_revise.Address = ucTextBoxEx2.InputText;
            industryModel_revise.Department = ucTextBoxEx3.InputText;
            industryModel_revise.Distribution_characteristics = ucTextBoxEx4.InputText;
            industryModel_revise.Position_characteristics = ucTextBoxEx5.InputText;
            industryModel_revise.Terrain_features = ucTextBoxEx6.InputText;
            industryModel_revise.Geospatial_relationships = ucTextBoxEx7.InputText;
            industryModel_revise.Age = ucTextBoxEx8.InputText;
            industryModel_revise.Era = ucTextBoxEx9.InputText;
            industryModel_revise.Footprint = ucTextBoxEx10.InputText;
            industryModel_revise.Status_quo = ucTextBoxEx11.InputText;
            industryModel_revise.Protective_measures = ucTextBoxEx12.InputText;
            industryModel_revise.Current_use = ucTextBoxEx13.InputText;
            IndustryBLL industryBLL = new IndustryBLL();
            if (industryBLL.Revise(industryModel_revise, out string messageStr) == true)
            {
                MessageBox.Show(messageStr);
                DialogResult = DialogResult.OK;//注册成功，关闭界面
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
    }
}
