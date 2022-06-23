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

namespace GYMS.User_controls
{
    public partial class UseriDetial : UserControl
    {
        private PersonModel personModel;
        public PersonModel personModel_revise = new PersonModel();//修改后的数据，注意回传给主页面进行信息更新
        public PersonModel PersonModel_revise
        {
            get
            {
                return personModel_revise;
            }
        }
        public UseriDetial(PersonModel _personModel)
        {
            InitializeComponent();
            personModel = _personModel;
            personModel_revise = _personModel;
            InitGlobal();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        public void InitGlobal()
        {
            label7.Text = personModel.Id.ToString();
            ucTextBoxEx1.InputText = personModel.Name;
            ucTextBoxEx2.InputText = personModel.Email;
            if (personModel.Gender == 0)
            {
                ucRadioButton1.Checked = true;
            }
            else
            {
                ucRadioButton2.Checked = true;
            }
            if (personModel.Identity == 0)
            {
                label8.Text = "普通用户";
            }
            else
            {
                label8.Text = "管理员";
            }
            if (personModel.Avatar != null)
            {
                MemoryStream stream = new MemoryStream(personModel.Avatar);
                //两种读取图片的方式
                //stream.Write(industryModel.Picture, 0, industryModel.Picture.Length);
                //pictureBox1.Image = new Bitmap(stream);
                pictureBox1.Image = System.Drawing.Image.FromStream(stream);

                stream.Close();
            }


        }
        /// <summary>
        /// 头像显示
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
                //textBox1.Text = "";
                FileStream FStream = new FileStream(//创建文件流对象
openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader BReader = new BinaryReader(FStream);//创建二进制流对象
                personModel_revise.Avatar = BReader.ReadBytes((int)FStream.Length);//得到字节数组
                FStream.Close();
                BReader.Close();
            }
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            personModel_revise.Id = int.Parse(label7.Text);
            personModel_revise.Name = ucTextBoxEx1.InputText.Trim();
            personModel_revise.Email = ucTextBoxEx2.InputText.Trim();
            if (ucRadioButton1.Checked)
            {
                personModel_revise.Gender = 0;
            }
            else
            {
                personModel_revise.Gender = 1;
            }
            if (label8.Text == "普通用户")
            {
                personModel_revise.Identity = 0;
            }
            else
            {
                personModel_revise.Identity = 1;
            }
            //进入逻辑层判断是否合法
            if (new PersonBLL().Revise(personModel_revise, out string messageStr))
            {
                MessageBox.Show(messageStr);
            }
            else
            {
                MessageBox.Show(messageStr);
            }
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
            //this.Close()
        }
    }
}
