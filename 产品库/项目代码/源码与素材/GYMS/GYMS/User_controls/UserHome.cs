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
    public partial class UserHome : UserControl
    {
        public UserHome()
        {
            InitializeComponent();
        }
        private void LoadChart()
        {
            var r = new Random();
            var canvas = new Bunifu.DataViz.Canvas();
            var datapoint = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_splineArea);

            datapoint.addLabely("SUN", r.Next(0, 100).ToString());
            datapoint.addLabely("MON", r.Next(0, 100).ToString());
            datapoint.addLabely("TUE", r.Next(0, 100).ToString());
            datapoint.addLabely("WED", r.Next(0, 100).ToString());
            datapoint.addLabely("THU", r.Next(0, 100).ToString());
            datapoint.addLabely("FRI", r.Next(0, 100).ToString());
            datapoint.addLabely("SAT", r.Next(0, 100).ToString());

            // Add data sets to canvas   
            canvas.addData(datapoint);
            //render canvas   
            bunifuDataViz1.colorSet.Add(Color.Red);
            bunifuDataViz1.Render(canvas);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
