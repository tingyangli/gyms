using MODEL;
using BLL;
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
    public partial class UserGY : UserControl
    {
        List<IndustryModel> industryModels = new List<IndustryModel> { };
        List<IndustryModel> industryModelsNew = new List<IndustryModel> { };
        IndustryModel model = new IndustryModel();
        public UserGY()
        {
            InitializeComponent();
            InitGlobal();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        public void InitGlobal()
        {
            industryLoad();
        }
        public void industryLoad()
        {
            if (new IndustryBLL().SelectAll(out List<IndustryModel> industryModelsUI))
            {
                industryModels = industryModelsUI;
            }
            dataGridView1.DataSource = industryModels;
        }
        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FormGYUpdate f = new FormGYUpdate(new IndustryModel());
            if (f.ShowDialog() == DialogResult.OK)
            {
                industryLoad();
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
            string name = (string)dataGridViewRow.Cells[0].FormattedValue;
            IndustryModel industryModel = industryModels.Find(item => item.Name == name);
            FormGYUpdate f = new FormGYUpdate(industryModel);
            if (f.ShowDialog() == DialogResult.OK)
            {
                industryLoad();
            }
        }
        /// <summary>
        /// 单击获取信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string name="";
            DataGridView dataGridView = sender as DataGridView;
            var dataselect = this.dataGridView1.SelectedRows;
            if (dataselect.Count>0)
            {
                name = Convert.ToString(dataselect[0].Cells["N"].Value);
            }
            IndustryModel industryModel = industryModels.Find(item => item.Name == name);
            model = industryModel;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ///进入BLL删除操作
            if (new IndustryBLL().Delete(model, out string messageStr))
            {
                MessageBox.Show(messageStr);
                industryLoad();
                model = new IndustryModel();
            }
            else
            {
                MessageBox.Show(messageStr);
                model = new IndustryModel();
            }
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            industryLoad();
        }
        /// <summary>
        /// 搜索工业遗产信息（没有模糊搜索）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucTextBoxEx1_SearchClick(object sender, EventArgs e)
        {
            string name = ucTextBoxEx1.InputText;
            IndustryModel industryModel = industryModels.Find(item => item.Name == name);
            industryModelsNew.Add(industryModel);
            dataGridView1.DataSource = industryModelsNew;
            industryModelsNew = new List<IndustryModel>();
        }
    }
}
