using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaTengForm
{
    //-----------------------------------------------------------------------------------------------------
    public partial class MainPage : Form
    {
        //-----------------------------------------------------------------------------------------------------
        public MainPage()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 绘制窗体大小
        /// </summary>

        private Size m_szInit;//初始窗体大小
        private Dictionary<Control, Rectangle> m_dicSize
        = new Dictionary<Control, Rectangle>();

        //-----------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            m_szInit = this.Size;//获取初始大小
            this.GetInitSize(this);
            base.OnLoad(e);
        }

        //-----------------------------------------------------------------------------------------------------
        private void GetInitSize(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                m_dicSize.Add(c, new Rectangle(c.Location, c.Size));
                this.GetInitSize(c);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            //计算当前大小和初始大小的比例
            float fx = (float)this.Width / m_szInit.Width;
            float fy = (float)this.Height / m_szInit.Height;
            foreach (var v in m_dicSize)
            {
                v.Key.Left = (int)(v.Value.Left * fx);
                v.Key.Top = (int)(v.Value.Top * fy);
                v.Key.Width = (int)(v.Value.Width * fx);
                v.Key.Height = (int)(v.Value.Height * fy);
            }
            base.OnResize(e);
        }

        //-----------------------------------------------------------------------------------------------------
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------------
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private SpeedTest speedtest;
        private RunStatus runstatus;

        //-----------------------------------------------------------------------------------------------------
        private void MainPage_Load(object sender, EventArgs e)
        {
            showf1();
            label1.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        //-----------------------------------------------------------------------------------------------------
        private void 运行报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closefall();
            showf2();
        }

        //-----------------------------------------------------------------------------------------------------
        private void 性能测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closefall();
            showf1();

        }

        //-----------------------------------------------------------------------------------------------------
        private void closefall()
        {
            try
            {
                speedtest.Close();
                runstatus.Close();
            }
            catch (Exception)
            {
                //throw;
            }
            GC.Collect();
        }

        //-----------------------------------------------------------------------------------------------------
        private void showf1()
        {
            speedtest = new SpeedTest
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                Parent = panel1,
                ControlBox = false,
                FormBorderStyle = FormBorderStyle.None
            };
            speedtest.Show();

        }

        //-----------------------------------------------------------------------------------------------------
        private void showf2()
        {
            runstatus = new RunStatus
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                Parent = panel1,
                ControlBox = false,
                FormBorderStyle = FormBorderStyle.None
            };
            runstatus.Show();
        }

        //-----------------------------------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

    }
}


