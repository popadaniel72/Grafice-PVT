using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafice_PVT
{
    public partial class Form1 : Form
    {
        int x = 50, y = 550;
        Pen rosu, negru, verde, albastru, portocaliu, galben;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /// desen grafic
            dVector(x, y, 90, 500, negru, e);
            dVector(x, y, 0, 800, negru, e);
        }

        

        public Form1()
        {
            InitializeComponent();
            negru = new Pen(Color.Black, 1);
            rosu = new Pen(Color.Red, 1);
            verde = new Pen(Color.Green, 1);
            albastru = new Pen(Color.Blue, 1);
            galben = new Pen(Color.Yellow, 1);
            portocaliu = new Pen(Color.Orange, 1); 

        }
        void dVector(int x, int y, int u, int l, Pen cul, PaintEventArgs e)
        {
            int a = 30, vv = 10; //a = unghiul varfului, vv= lungimea varf
            double dx, dy;
            int xv, yv;
            // desen linie principala
            dx = l * Math.Cos(u * Math.PI / 180);
            dy = l * Math.Sin(u * Math.PI / 180);
            xv = x + (int)dx; // xv, yv - coordonatele varfului
            yv = y - (int)dy;
            e.Graphics.DrawLine(cul, x, y, xv, yv);
            // desen varf
            dx = vv * Math.Cos((u + 180 - a) * Math.PI / 180);
            dy = vv * Math.Sin((u + 180 - a) * Math.PI / 180);
            e.Graphics.DrawLine(cul, xv, yv, xv + (int)dx, yv - (int)dy);
            dx = vv * Math.Cos((u + 180 + a) * Math.PI / 180);
            dy = vv * Math.Sin((u + 180 + a) * Math.PI / 180);
            e.Graphics.DrawLine(cul, xv, yv, xv + (int)dx, yv - (int)dy);

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
