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
    public partial class FormLogin : FormFatherPro
    {
        PersonModel personModel = new PersonModel();
        /// <summary>
        /// 获取当前用户的信息
        /// </summary>
        public PersonModel PersonModel
        {
            get
            {
                return personModel;
            }
        }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmail formEmail = new FormEmail();
            formEmail.ShowDialog();
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            personModel.Name = ucTextBoxEx1.InputText.Trim();
            personModel.Password = ucTextBoxEx3.InputText.Trim();
            if (new PersonBLL().Select(personModel, out string messageStr, out PersonModel personModelUI))
            {
                MessageBox.Show(messageStr);
                DialogResult = DialogResult.OK;
                personModel = personModelUI;
            }
            else
            {
                MessageBox.Show(messageStr);
                //等待用户输入正确的信息
                ucTextBoxEx1.Text = "";
                ucTextBoxEx2.Text = "";
            }
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            FormSignup formSignup = new FormSignup();
            formSignup.ShowDialog();
        }
    }
}
