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
namespace GYMS
{
    public partial class FormSignup : FormFatherPro
    {
        public FormSignup()
        {
            InitializeComponent();
            InitGlobal();
        }
        public void InitGlobal()
        {
            string[] vs = { "普通用户", "管理员" };
            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
            for(int i = 0; i < 2; i++)
{
                lstCom.Add(new KeyValuePair<string, string>(i.ToString(), vs[i]));
            }

            this.ucCombox1.Source = lstCom;
            this.ucCombox1.SelectedIndex = 0;
        }
        /*
        private void skinButton1_Click(object sender, EventArgs e)
        {
            PersonModel personModel = new PersonModel();
            personModel.Name = skinTextBoxName.Text.Trim();
            personModel.Password = skinTextBoxPassword.Text.Trim();
            personModel.Password2 = skinTextBoxPassword2.Text.Trim();
            if (radioButton2.Checked)
            {
                personModel.Gender = 1;
            }
            else
            {
                personModel.Gender = 0;
            }
            personModel.Email = skinTextBoxEmail.Text.Trim();
            PersonBLL personBLL = new PersonBLL();
            if(personBLL.Insert(personModel,out string messageStr) == true)
            {
                MessageBox.Show(messageStr);
                DialogResult = DialogResult.OK;//注册成功，关闭界面
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }*/
        /*
        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        */
        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
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

    }
}
