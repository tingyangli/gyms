using BLL;
using MODEL;
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
    public partial class UserInformation : UserControl
    {
        //初始化绑定默认关键词（此数据源可以从数据库取）
        List<string> listOnit = new List<string>();
        //输入key之后，返回的关键词
        List<string> listNew = new List<string>();
        private IndustryModel IndustryModel;
        private List<IndustryModel> industryModels;
        public UserInformation()
        {
            InitializeComponent();
            InitGloabal();
        }
        /// <summary>
        /// 初始化界面和列表
        /// </summary>
        public void InitGloabal()
        {
            int i = 0;
            LinkLabel[] linkLabels = { linkLabel1, linkLabel2, linkLabel3};
            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3};
            //显示图片和名称
            if (new IndustryBLL().Select(out List<IndustryModel> industryModelsUI) == true)
            {
                industryModels = industryModelsUI;
                foreach (IndustryModel industryModel in industryModels)
                {
                    linkLabels[i].Text = industryModel.Name;
                    if (industryModel.Picture.Length > 0)
                    {
                        MemoryStream stream = new MemoryStream(industryModel.Picture);
                        //两种读取图片的方式
                        //stream.Write(industryModel.Picture, 0, industryModel.Picture.Length);
                        //pictureBox1.Image = new Bitmap(stream);
                        pictureBoxes[i].Image = System.Drawing.Image.FromStream(stream);
                        stream.Close();
                    }
                    i++;
                }
            }
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }
        //进入页面初始化原始序列
        private void BindComboBox()
        {
            if (new IndustryBLL().SelectAllName(out List<string> industryModelsUIName))
            {
                listOnit = industryModelsUIName;
            }
        }

        private void textBoxEx1_TextChanged(object sender, EventArgs e)
        {
            //清空combobox
            this.ucCombox1.TextValue = "";
            //清空listNew
            listNew.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit)
            {
                if (item.Contains(this.textBoxEx1.Text))
                {
                    //符合，插入ListNew
                    listNew.Add(item);
                }
            }
            string[] vs = listNew.ToArray();
            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < vs.Length; i++)
            {
                lstCom.Add(new KeyValuePair<string, string>(i.ToString(), vs[i]));
            }
            this.ucCombox1.Source = lstCom;
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
        }


        private void ucCombox1_SelectedChangedEvent(object sender, EventArgs e)
        {
            
            textBoxEx1.Text = ucCombox1.SelectedText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxEx1.Text;
            if (new IndustryBLL().SelectDetail(name, out IndustryModel industryModelUI))
            {
                IndustryModel = industryModelUI;
                FormDetail formDetail = new FormDetail(IndustryModel);
                formDetail.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = linkLabel1.Text;
            if (new IndustryBLL().SelectDetail(name, out IndustryModel industryModelUI))
            {
                IndustryModel = industryModelUI;
                FormDetail formDetail = new FormDetail(IndustryModel);
                formDetail.ShowDialog();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = linkLabel2.Text;
            if (new IndustryBLL().SelectDetail(name, out IndustryModel industryModelUI))
            {
                IndustryModel = industryModelUI;
                FormDetail formDetail = new FormDetail(IndustryModel);
                formDetail.ShowDialog();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = linkLabel3.Text;
            if (new IndustryBLL().SelectDetail(name, out IndustryModel industryModelUI))
            {
                IndustryModel = industryModelUI;
                FormDetail formDetail = new FormDetail(IndustryModel);
                formDetail.ShowDialog();
            }
        }
    }
}
