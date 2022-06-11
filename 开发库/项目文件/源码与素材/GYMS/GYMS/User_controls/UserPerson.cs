using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using MODEL;
namespace GYMS.User_controls
{
    public partial class UserPerson : UserControl
    {
        List<PersonModel> personModels=new List<PersonModel> { };
        List<PersonModel> personModelsNew = new List<PersonModel> { };
        PersonModel model = new PersonModel();
        public UserPerson()
        {
            InitializeComponent();
            InitGlobal();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        public void InitGlobal()
        {
            personLoad();
        }
        public void personLoad()
        {
            if (new PersonBLL().SelectAll(out List<PersonModel> personModelsUI))
            {
                personModels = personModelsUI;
            }
            foreach (PersonModel item in personModels)
            {
                item.GenderName = Common.GenderList[item.Gender];
                item.IdentityName = Common.IdentityList[item.Identity];
            }
            dataGridView1.DataSource = personModels;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FormUpdate formUpdate = new FormUpdate(new PersonModel());
            if (formUpdate.ShowDialog() == DialogResult.OK)
            {
                personLoad();
            }
        }
        /// <summary>
        /// 双击修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            DataGridViewRow dataGridViewRow = dataGridView.CurrentRow;
            int number = int.Parse((string)dataGridViewRow.Cells[0].FormattedValue);
            PersonModel personModel= personModels.Find(item => item.Id == number);
            FormUpdate f = new FormUpdate(personModel);
            if (f.ShowDialog() == DialogResult.OK)
            {
                personLoad();
            }
        }
        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ///进入BLL删除操作
            if(new PersonBLL().Delete(model,out string messageStr))
            {
                MessageBox.Show(messageStr);
                personLoad();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            DataGridViewRow dataGridViewRow = dataGridView.CurrentRow;
            int number = int.Parse((string)dataGridViewRow.Cells[0].FormattedValue);
            PersonModel personModel = personModels.Find(item => item.Id == number);
            model = personModel;
        }
        /// <summary>
        /// 根据用户名查询用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucTextBoxEx1_SearchClick(object sender, EventArgs e)
        {
            string name = ucTextBoxEx1.InputText;
            PersonModel personModel = personModels.Find(item => item.Name == name) ;
            personModelsNew.Add(personModel);
            dataGridView1.DataSource = personModelsNew;
            personModelsNew = new List<PersonModel>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            personLoad();
        }
    }
}
