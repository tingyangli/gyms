using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMS
{
    public partial class FormUpdate : Form
    {
        PersonModel personModel = new PersonModel();
        public FormUpdate(PersonModel person)
        {
            InitializeComponent();
            personModel = person;
            InitGlobal();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        public void InitGlobal()
        {
            string[] vs = { "普通用户", "管理员" };
            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 2; i++)
            {
                lstCom.Add(new KeyValuePair<string, string>(i.ToString(), vs[i]));
            }

            this.ucCombox1.Source = lstCom;
            this.ucCombox1.SelectedIndex = 0;
            if (personModel.Id != 0)
            {
                ucTextBoxEx1.InputText = personModel.Name;
                ucTextBoxEx2.InputText = personModel.Password;
                ucTextBoxEx3.InputText = personModel.Password;
                ucTextBoxEx2.Enabled = false;
                ucTextBoxEx3.Enabled = false;
                ucTextBoxEx4.InputText = personModel.Email;
                if (personModel.Gender == 0)
                {
                    ucRadioButton1.Checked = true;
                }
                else
                {
                    ucRadioButton2.Checked = true;
                }
                ucCombox1.SelectedIndex = personModel.Identity;
                ucBtnExt2.Visible = false;
                ucBtnExt3.Visible = true;
            }
            else
            {
                ucBtnExt2.Visible = true;
                ucBtnExt3.Visible = false;
            }
        }
        /// <summary>
        /// 关闭
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
        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            ucTextBoxEx1.InputText = "";
            ucTextBoxEx2.InputText = "";
            ucTextBoxEx3.InputText = "";
            ucTextBoxEx4.InputText = "";
            ucRadioButton1.Checked = true;
            ucCombox1.SelectedIndex = 0;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            PersonModel personModel = new PersonModel();
            personModel.Name = ucTextBoxEx1.InputText.Trim();
            personModel.Password = ucTextBoxEx2.InputText.Trim();
            personModel.Password2 = ucTextBoxEx3.InputText.Trim();
            if (ucRadioButton2.Checked)
            {
                personModel.Gender = 1;
            }
            else
            {
                personModel.Gender = 0;
            }
            personModel.Email = ucTextBoxEx4.InputText.Trim();
            personModel.Identity = ucCombox1.SelectedIndex;
            PersonBLL personBLL = new PersonBLL();
            if (personBLL.Insert(personModel, out string messageStr) == true)
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
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            PersonModel personModelNew = new PersonModel();
            personModelNew.Id = personModel.Id;
            personModelNew.Name = ucTextBoxEx1.InputText.Trim();
            personModelNew.Password = ucTextBoxEx2.InputText.Trim();
            personModelNew.Password2 = ucTextBoxEx3.InputText.Trim();
            personModelNew.Email = ucTextBoxEx4.InputText.Trim();
            personModelNew.Avatar = personModel.Avatar;
            if (ucRadioButton1.Checked)
            {
                personModelNew.Gender = 0;
            }
            else
            {
                personModelNew.Gender = 1;
            }
            personModelNew.Identity = ucCombox1.SelectedIndex;
            //获取更新的数据
            PersonBLL personBLL = new PersonBLL();
            if (personBLL.ReviseByM(personModelNew, out string messagestr) == true)
            {
                MessageBox.Show(messagestr);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(messagestr);
            }
        }
    }
}
