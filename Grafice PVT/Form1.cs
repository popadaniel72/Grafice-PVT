﻿using System;
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
        int x = 50, y = 550, p=0, v=0;
        Pen rosu, negru, verde, albastru, portocaliu, galben;
        int[] izobare;
        int nrizobare=0, nrizocore = 0, mx = 10;

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
            this.Invalidate();
        }

        int[] izocore;
        bool izobara=false, izocora = false, izoterma = false, adiabata = false;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            p = y - e.Y;
            v = e.X - x;
            PVT.Text = "P= " + p.ToString() + " V= " + v.ToString();
            if(izobara) izobare[nrizobare] = e.Y;
            if (izocora) izocore[nrizocore] = e.X;
            if(izobara || izocora || izoterma || adiabata)
            this.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /// desen grafic
            dVector(x, y, 90, 500, negru, e);
            dVector(x, y, 0, 800, negru, e);
            for (int i = 1; i <= nrizobare; i++)
                dIzobara(izobare[i], albastru, e);
            for(int i=1; i<=nrizocore; i++)
                dIzocora(izocore[i], verde, e);
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

        }

        void dIzobara(int p, Pen cul, PaintEventArgs e)
        {
            e.Graphics.DrawLine(cul, x + 10, p, x + 500, p);
        }
        void dIzocora(int p, Pen cul, PaintEventArgs e)
        {
            e.Graphics.DrawLine(cul, p, y , p, 50);
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
