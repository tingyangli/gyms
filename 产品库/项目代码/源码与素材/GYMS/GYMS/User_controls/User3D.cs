using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMS.User_controls
{
    public partial class User3D : UserControl
    {
        public User3D()
        {
            InitializeComponent();
        }

        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*.jpg,*jpeg,*.bmp,*.ico,*.png,*.tif,*.wmf|*.jpg;*jpeg;*.bmp;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.Title = "选择用户头像";
            openFileDialog1.ShowDialog();
        }

        private void User3D_Load(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;//允许同时选择多个文件
        }
    }
}
