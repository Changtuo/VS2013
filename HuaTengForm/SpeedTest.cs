using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic.PowerPacks;

namespace HuaTengForm
{
    //-----------------------------------------------------------------------------------------------------
    public partial class SpeedTest : Form
    {
        //-----------------------------------------------------------------------------------------------------
        public SpeedTest()
        {
            InitializeComponent();
            InitMyShape();
        }

        const int k = 32;
        RectangleShape[] theShapes;
        Point[] points;
        Circlepoints cp;
        private bool run = false;

        //-----------------------------------------------------------------------------------------------------
        private void InitMyShape()
        {
            int r = this.ovalShape1.Size.Width/2 + 20;
            Point middlepoint = new Point(this.ovalShape1.Location.X + r - 20 - 10,
                this.ovalShape1.Location.Y + r - 20 - 10);
            theShapes = new RectangleShape[k];
            points = new Point[k];
            cp = new Circlepoints(k, r, middlepoint);
        }

        //创建一个Shape型数组

        //-----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Shaple类读写索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        //public RectangleShape this[int index]
        //{
        //    get
        //    {
        //        if (index < 0 || index >= 1)
        //        {
        //            return null;
        //        }
        //        return theShapes[index];
        //    }
        //    set
        //    {
        //        if (index < 0 || index >= 1)
        //        {
        //            return;
        //        }
        //        theShapes[index] = value;

        //    }
        //}

        void SPD_Paint()
        {
            //theShapes[1].Visible = false;
            //int x = this.ClientSize.Height / 2;
            //int y = this.ClientSize.Width / 2;

            //Point point = new Point(200, 200);
            //Size size = new Size(300, 300);

            //Graphics g = this.CreateGraphics(); //创建画板,这里的画板是由Form提供的.
            //Pen p = new Pen(Color.Black, 1);//定义了一个蓝色,宽度为的画笔
            //Rectangle rect = new Rectangle(point, size);
            //g.DrawEllipse(p, rect);

            //SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            //g.FillEllipse(mySolidBrush, 200, 200, 50, 50);
        }

        //-----------------------------------------------------------------------------------------------------
        private void SpeedTest_Load(object sender, EventArgs e)
        {
            btnclasstest.Visible = false;
            //OvalShape oval3 = new OvalShape();
            //oval3.Location = new Point(50, 50);
            //oval3.Name = "oval3";
            //oval3.Size = new Size(30, 30);

            // To draw an oval, substitute
            // OvalShape for RectangleShape.
            ShapeContainer canvas = new ShapeContainer();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the Shape.
            for (var i = 0; i < k; i++)
            {
                theShapes[i] = new RectangleShape();
            }

            cp.calpoints(out points);

            int ptx = 0;

            foreach (var rc in theShapes)
            {
                rc.Parent = canvas;
                rc.Size = new System.Drawing.Size(20, 20);
                rc.CornerRadius = 30; //画圆也可以用个方形设置下圆角代替orz
                //
                rc.BackStyle = BackStyle.Opaque;
                rc.BackColor = Color.White;
                rc.Location = points[ptx];
                ptx++;
            }

            //Lb_Date.Text = DateTime.Now.ToString();

            this.MaximizeBox = false;
            // Set the location of the shape.
            // To draw a rounded rectangle, add the following code:
            btnstep.BackColor = Color.Yellow;
            button1.BackColor = Color.LightGreen;
            textBox1.Text = "100";

        }

        //-----------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //SPD_Paint();
            timer1.Enabled = !timer1.Enabled;
            run = !run;
            if (run)
            {
                button1.Text = "Stop";
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.Text = "Run";
                button1.BackColor = Color.LightGreen;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void ovalShape3_Click(object sender, EventArgs e)
        {

        }

        private int lightnumb = 0;
        private int clearnumber = 0;
        //-----------------------------------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            //button1.Text = Convert.ToString((rd.Next(10)));
            int ttime = 0;
            try
            {
                ttime = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception)
            {

                ttime = 100;
            }
            if (ttime <20)
            {
                timer1.Interval = 20;              
            }
            else
            {
                timer1.Interval = ttime;
            }          
            if (run)
            {
                Random rd = new Random();
                if (lightnumb == 0)
                {
                    clearnumber = k - 1;
                }
                else
                {
                    clearnumber = lightnumb - 1;
                }

                theShapes[lightnumb].BackColor = Color.GreenYellow;
                theShapes[clearnumber].BackColor = Color.White;
                lightnumb++;
                if (lightnumb >= k)
                {
                    lightnumb = 0;
                }
            }

        }

        //-----------------------------------------------------------------------------------------------------
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Lb_Date.Text = DateTime.Now.ToString();
        }

        //-----------------------------------------------------------------------------------------------------
        private void btnclasstest_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------------
        private void btnstep_MouseDown(object sender, MouseEventArgs e)
        {
            timer3.Enabled = !timer3.Enabled;
            button1.Text = "Run";
            button1.BackColor = Color.LightGreen;
            timer1.Enabled = true;
            run = true;
        }

        //-----------------------------------------------------------------------------------------------------
        private void btnstep_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Enabled = false;
            timer1.Enabled = false;
            run = false;
        }

        //-----------------------------------------------------------------------------------------------------
        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        //-----------------------------------------------------------------------------------------------------
        private void Lb_Date_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------------
        private void 运行状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            GC.Collect();
            Form runstatus = new RunStatus();
            runstatus.Show();
            //this.Opacity = 100;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }  

        }

    }
}


