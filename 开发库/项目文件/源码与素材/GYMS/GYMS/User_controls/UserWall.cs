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

namespace GYMS.User_controls
{
    public partial class UserWall : UserControl
    {
        public UserWall()
        {
            InitializeComponent();
        }

        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
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
                //personModel_revise.Avatar = BReader.ReadBytes((int)FStream.Length);//得到字节数组
                FStream.Close();
                BReader.Close();
            }
        }
        /// <summary>
        /// 判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            //pictureBox2.Image = Image.FromFile("E:\\大创\\源码与素材\\WALL\\example.png");
            label2.Text = "一般";
        }
    }
}
