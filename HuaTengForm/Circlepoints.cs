using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace HuaTengForm
{
    class Circlepoints
    {
        public Circlepoints()
        {
            ////zhushi
        }
        public Circlepoints(int pointcount,int radius,Point middlepoint)
        {
            this.PointCount = pointcount;
            this.Radius = Convert.ToDouble(radius);
            this.middlepoint = middlepoint;
        }

        private Point middlepoint;

        private double radius;
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        private int pointcount;
        public int PointCount
        {
            get
            {
                return pointcount;
            }
            set
            {
                if (value <= 0)
                {
                    MessageBox.Show("点数不够");
                }
                else
                {
                    pointcount = value;
                }
            }
        }
        public void showpcounts()
        {
            MessageBox.Show("当前点数为" + this.PointCount);
        }
        public void calpoints(out Point[]points)
        {
            //built 数组
            points = new Point[this.PointCount];
            //
            for (int i=0;i<this.PointCount;i++)
            {

                int xlocation = middlepoint.X +
                                Convert.ToInt32(Math.Cos(Convert.ToDouble(i)*2*Math.PI/Convert.ToDouble(pointcount))*
                                                radius);
                int ylocation = middlepoint.Y +
                                Convert.ToInt32(Math.Sin(Convert.ToDouble(i)*2*Math.PI/Convert.ToDouble(pointcount))*
                                                radius);
                points[i] = new Point(xlocation, ylocation);
                // points[i] = new Point(30, 30);


            }
        }
    }
}
