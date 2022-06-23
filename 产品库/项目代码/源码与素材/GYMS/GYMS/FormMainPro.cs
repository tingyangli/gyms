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
using GYMS.User_controls;

namespace GYMS
{
    public partial class FormMainPro : Form
    {
        private PersonModel personModel;
        int PanelWidth;
        bool isCollapsed;
        public FormMainPro(PersonModel _personModel)
        {
            InitializeComponent();
            personModel = _personModel;
            InitGlobal();
            timer2.Start();
            PanelWidth = panel1.Width;
            isCollapsed = false;
            UserHome userHome = new UserHome();
            userHome.Dock = DockStyle.Fill;
            AddcontrolstoPanel(userHome);
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        public void InitGlobal()
        {
            label5.Text = personModel.Name;
            if (personModel.Identity == 0)
            {
                label6.Text = "普通用户";
            }
            else
            {
                label6.Text = "管理员";
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 导航定时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Width = panel1.Width + 10;
                if (panel1.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panel1.Width = panel1.Width - 10;
                if (panel1.Width <= 61)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }
        /// <summary>
        /// 导航按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        /// <summary>
        /// 移动左方panel
        /// </summary>
        /// <param name="btn"></param>
        private void movesidePanel(Control btn)
        {
            panel6.Top = btn.Top;
            panel6.Height = btn.Height;
        }
        private void AddcontrolstoPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel7.Controls.Clear();
            panel7.Controls.Add(c);
        }
             
        private void button1_Click(object sender, EventArgs e)
        {
            movesidePanel(button1);
            UserHome userHome = new UserHome();
            AddcontrolstoPanel(userHome);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            movesidePanel(button2);
            UserInformation userInformation = new UserInformation();
            AddcontrolstoPanel(userInformation);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            movesidePanel(button4);
            User3D user3D = new User3D();
            AddcontrolstoPanel(user3D);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label8.Text = dateTime.ToString("HH:MM:ss");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            movesidePanel(button7);
            UserComunication userComunication = new UserComunication(personModel);
            AddcontrolstoPanel(userComunication);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            movesidePanel(button8);
            UseriDetial useriDetial = new UseriDetial(personModel);
            personModel = useriDetial.PersonModel_revise;
            label5.Text = personModel.Name;
            AddcontrolstoPanel(useriDetial);
        }
    }
}
