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
namespace GYMS.User_controls
{
    public partial class UserComunication : UserControl
    {
        List<RelatedModel> relatedModels = new List<RelatedModel> { };
        List<RelatedModel> relatedModelsNew = new List<RelatedModel> { };
        RelatedModel model = new RelatedModel();
        PersonModel personModel=new PersonModel();
        public UserComunication(PersonModel _personModel)
        {
            InitializeComponent();
            InitGlobal();
            personModel = _personModel;
        }
        public void InitGlobal()
        {
            RelatedLoad();
        }
        public void RelatedLoad()
        {
            if (new RelatedBLL().SelectAll(out List<RelatedModel> relatedModelsUI))
            {
                relatedModels = relatedModelsUI;
            }
            dataGridView1.DataSource = relatedModels;
        }
        /// <summary>
        /// 发布话题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FormChat f = new FormChat(personModel);
            if (f.ShowDialog() == DialogResult.OK)
            {
                RelatedLoad();
            }
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            RelatedLoad();
        }

        private void ucTextBoxEx1_SearchClick(object sender, EventArgs e)
        {
            string topic = ucTextBoxEx1.InputText;
            var emp = relatedModels.FindAll(item => item.info_name == topic);
            foreach (var item in emp)
            {
                relatedModelsNew.Add(item);
            }
            dataGridView1.DataSource = relatedModelsNew;
            relatedModelsNew = new List<RelatedModel>();
        }
    }
}
