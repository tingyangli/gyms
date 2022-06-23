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
    public partial class FormChat : Form
    {
        RelatedModel relatedModel = new RelatedModel();
        PersonModel personModel = new PersonModel();
        public FormChat(PersonModel _personModel)
        {
            InitializeComponent();
            personModel = _personModel;
            InitGlobal();
        }
        public void InitGlobal()
        {
            label4.Text = personModel.Name;
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
            ucTextBoxEx2.InputText = "";
            ucTextBoxEx3.InputText = "";
        }
        /// <summary>
        /// 发布内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            relatedModel.person_id = personModel.Id;
            relatedModel.person_name = personModel.Name;
            relatedModel.info_name = ucTextBoxEx2.InputText;
            relatedModel.message = ucTextBoxEx3.InputText;
            if(new RelatedBLL().Insert(relatedModel,out string messageStr))
            {
                MessageBox.Show(messageStr);
                DialogResult = DialogResult.OK;//发布成功，关闭界面
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
    }
}
