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
        int x = 50, y = 550, p=0, v=0, t=0, xdr=700, ysus=50, adi;
        Pen rosu, negru, verde, albastru, portocaliu, galben;
        int[] izobare;
        int nrizobare=0, nrizocore = 0, mx = 10, nrizoterme=0, nradiabate;
        int[] izocore;
        int[] adiabate;
        double R = 8.310, n = 2, ga = 1.65;
        bool izobara = false, izocora = false, izoterma = false, adiabata = false;

        private void button4_Click(object sender, EventArgs e)
        {
            izobara = false; izocora = false; izoterma = false; adiabata = false;
            if (nradiabate < mx)
            {
                adiabata = true;
                nradiabate++;
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            izobara = false; izocora = false; izoterma = false; adiabata = false;
            if (nrizoterme < mx)
            {
                izoterma = true;
                nrizoterme++;
            }
        }

        int[] izoterme;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            izobara = false; izocora = false; izoterma = false; adiabata = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            izobara = false; izocora = false; izoterma = false; adiabata = false;
            if (nrizocore < mx) 
            {
                nrizocore++;
                izocora = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nrizocore = 0;
            nrizobare = 0;
            nrizoterme = 0;
            nradiabate = 0;
            this.Invalidate();
        }

        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= x && e.X <= xdr && e.Y >= ysus && e.Y <= y)
            {
                p = y - e.Y;
                v = e.X - x;
                t = (int)( 1.0*p *v/(n*R) );
                adi = (int)(p * Math.Pow(v, ga));
                PVT.Text = "P= " + p.ToString() + " V= " + v.ToString()+" T="+t.ToString();
                if (izobara) izobare[nrizobare] = e.Y;
                if (izocora) izocore[nrizocore] = e.X;
                if (izoterma) izoterme[nrizoterme] = t;
                if (adiabata) adiabate[nradiabate] = adi;
                if (izobara || izocora || izoterma || adiabata)
                    this.Invalidate();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /// desen grafic
            dVector(x, y, 90, y-ysus, negru, e);
            dVector(x, y, 0, xdr-x, negru, e);
            for (int i = 1; i <= nrizobare; i++)
                dIzobara(izobare[i], albastru, e);
            for(int i=1; i<=nrizocore; i++)
                dIzocora(izocore[i], verde, e);
            for (int i = 1; i <= nrizoterme; i++)
                dIzoterma(izoterme[i], rosu, e);
            for (int i = 1; i <= nradiabate; i++)
                dAdiabata(adiabate[i], portocaliu, e);
        }

        

        public Form1()
        {
            InitializeComponent();
            negru = new Pen(Color.Black, 2);
            rosu = new Pen(Color.Red, 1);
            verde = new Pen(Color.Green, 1);
            albastru = new Pen(Color.Blue, 1);
            galben = new Pen(Color.Yellow, 1);
            portocaliu = new Pen(Color.Orange, 1);
            izobare = new int[mx + 1];
            izocore = new int[mx + 1];
            izoterme = new int[mx + 1];
            adiabate = new int[mx + 1];

        }

        void dIzobara(int p, Pen cul, PaintEventArgs e)
        {
            e.Graphics.DrawLine(cul, x + 10, p, x + 500, p);
        }
        void dIzocora(int p, Pen cul, PaintEventArgs e)
        {
            e.Graphics.DrawLine(cul, p, y , p, 50);
        }
        void dAdiabata(int adi, Pen cul, PaintEventArgs e)
        {
            int yn, yv=adi, i;
            for(i=3; i<=xdr-x;i+=2)
            {
                yn = (int)(adi / Math.Pow(i, ga));
                e.Graphics.DrawLine(cul, x + i - 2, y - yv, x + i, y - yn);
                yv = yn;
            }
        }
        void dIzoterma(int t, Pen cul, PaintEventArgs e)
        {
            int yv = (int)(n *R * t) , yn;
            for(int i =2; i<xdr-x; i+=2)
            {
                yn =(int) (n * R * t / i);
                e.Graphics.DrawLine(cul, x+i - 1, y-yv, x+i, y-yn);
                yv = yn;
            }
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

       

        private void button1_Click(object sender, EventArgs e)
        {
            izobara = false; izocora = false; izoterma = false; adiabata = false;
            if (nrizobare < mx)
            {
                izobara = true;
                nrizobare++;
            }

        }
    }
}
