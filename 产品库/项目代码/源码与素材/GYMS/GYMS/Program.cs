using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin f = new FormLogin();
            if(f.ShowDialog() == DialogResult.OK)
            {
                if (f.PersonModel.Identity == 1)
                {
                    Application.Run(new FormMainProManage(f.PersonModel));
                }
                else
                {
                    Application.Run(new FormMainPro(f.PersonModel));
                }
            } 
        }
    }
}
