using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        int mxdff;
        int mxplc;
        int rightlinect = 0;
        int leftlinect = 0;
        int nys = 150;
        int nye = 160;
        int nxtmv;
        int seektime;
        int rightct;
        int Leftct;
        int diff;
        int mindiff;
        int minplace;
        int leftorright;
        int t1, t2, t3, t4, t5, t6, t7, t8, t9;
        Bitmap off;
        Timer tt = new Timer();
        public Form1()
        {

            InitializeComponent();
            this.Paint += Form1_Paint;
            tt.Tick += Tt_Tick;
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            Dbb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Dbb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        void Drawscene(Graphics g)
        {
            g.Clear(Color.White);
            g.DrawLine(Pens.Blue, 0, 150, 199 * 3, 150);
            String s = "zero";
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            g.DrawString(s, drawFont, drawBrush, -5, 130);
            s = "199";
            g.DrawString(s, drawFont, drawBrush, 199 * 3, 130);

        }

        void Dbb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drawscene(g2);
            g.DrawImage(off, 0, 0);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            seektime = 0;

            int[] array = new int[8];
            int o = 0;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 ||
                textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || textBox8.Text.Length == 0
                || textBox9.Text.Length == 0)
            {
                MessageBox.Show("fill all no");
            }

            else if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) ||
                     String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrWhiteSpace(textBox5.Text) || String.IsNullOrWhiteSpace(textBox6.Text) ||
                     String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrWhiteSpace(textBox8.Text) || String.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("no spaces");
            }
            else if (textBox1.Text.All(char.IsLetter) || textBox2.Text.All(char.IsLetter) || textBox3.Text.All(char.IsLetter) ||
                textBox4.Text.All(char.IsLetter) || textBox5.Text.All(char.IsLetter) || textBox6.Text.All(char.IsLetter) ||
                textBox7.Text.All(char.IsLetter) || textBox8.Text.All(char.IsLetter) || textBox9.Text.All(char.IsLetter))
            {
                MessageBox.Show("enter no only");
            }
            else
            {
                t1 = Convert.ToInt32(textBox1.Text);
                t2 = Convert.ToInt32(textBox2.Text);
                t3 = Convert.ToInt32(textBox3.Text);
                t4 = Convert.ToInt32(textBox4.Text);
                t5 = Convert.ToInt32(textBox5.Text);
                t6 = Convert.ToInt32(textBox6.Text);
                t7 = Convert.ToInt32(textBox7.Text);
                t8 = Convert.ToInt32(textBox8.Text);
                t9 = Convert.ToInt32(textBox9.Text);
                array[o] = t1;
                o++;
                array[o] = t2;
                o++;
                array[o] = t3;
                o++;
                array[o] = t4;
                o++;
                array[o] = t5;
                o++;
                array[o] = t6;
                o++;
                array[o] = t7;
                o++;
                array[o] = t8;
                if (t1 < 0 || t1 > 199 || t2 < 0 || t2 > 199 || t3 < 0 || t3 > 199 || t4 < 0 || t4 > 199
                || t5 < 0 || t5 > 199 || t6 < 0 || t6 > 199 || t7 < 0 || t7 > 199 || t8 < 0 || t8 > 199 || t9 < 0 || t9 > 199)
                {
                    MessageBox.Show("enter no between o and 199 only");
                }
                else
                {
                    rightct = 0;
                    Leftct = 0;
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    System.Drawing.Graphics formGraphics;
                    formGraphics = this.CreateGraphics();
                    formGraphics.FillEllipse(Brushes.Red, t1 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t2 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t3 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t4 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t5 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t6 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t7 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Red, t8 * 3, 150, 5, 5);
                    formGraphics.FillEllipse(Brushes.Green, t9 * 3, 150, 5, 5);
                    for (o = 0; o < 8; o++)
                    {
                        if (t9 > array[o])
                        {
                            Leftct++;
                        }
                        else
                        {
                            rightct++;
                        }
                    }
                    if (Leftct > rightct)
                    {
                        leftorright = 1;
                    }
                    else
                    {
                        leftorright = 2;
                    }
                    if (leftorright == 2)//right dir
                    {
                        diff = 0;
                        mindiff = 999;
                        minplace = 0;
                        nxtmv = t9;
                        for (int j = 0; j < 8; j++)
                        {
                            for (o = 0; o < 8; o++)
                            {


                                if (nxtmv < array[o])
                                {
                                    // MessageBox.Show("nxtmv" + nxtmv.ToString()+ "array[o]"+array[o].ToString());
                                    diff = array[o] - nxtmv;
                                    if (diff < mindiff)
                                    {
                                        seektime +=Math.Abs( array[o] - nxtmv);
                                        mindiff = diff;
                                        minplace = array[o];
                                        MessageBox.Show("uu");

                                    }
                                }
                            }
                            if (rightlinect <= rightct)
                            {
                                formGraphics.DrawLine(Pens.Red, nxtmv * 3, nys, minplace * 3, nye);
                                rightlinect++;
                                nxtmv = minplace;
                                nys = nye;
                                nye += 10;
                                mindiff = 999;
                            }
                            else/////return frst
                            {

                                mxdff = -999;
                                mxplc = 0;
                                for (o = 0; o < 8; o++)
                                {


                                    if (nxtmv > array[o])
                                    {
                                        // MessageBox.Show("nxtmv" + nxtmv.ToString()+ "array[o]"+array[o].ToString());
                                        diff = Math.Abs(array[o] - nxtmv);
                                        if (diff > mxdff)
                                        {
                                            seektime += Math.Abs(array[o] - nxtmv);
                                            mxdff = diff;
                                            mxplc = array[o];
                                            MessageBox.Show("yup");

                                        }
                                    }
                                }
                                if (leftlinect <= Leftct)
                                {
                                    formGraphics.DrawLine(Pens.Red, nxtmv * 3, nys, mxplc * 3, nye);
                                    leftlinect++;
                                    nxtmv = mxplc;
                                    nys = nye;
                                    nye += 10;
                                    mindiff = 999;
                                    for (j = 0; j < 8; j++)
                                    {
                                        for (o = 0; o < 8; o++)
                                        {
                                            if (nxtmv < array[o])
                                            {
                                                // MessageBox.Show("nxtmv" + nxtmv.ToString()+ "array[o]"+array[o].ToString());
                                                diff = array[o] - nxtmv;
                                               // seektime += array[o] - nxtmv;
                                                if (diff < mindiff)
                                                {
                                                    seektime += Math.Abs(array[o] - nxtmv);
                                                    mindiff = diff;
                                                    minplace = array[o];
                                                    MessageBox.Show("yes");

                                                }
                                            }
                                        }
                                        if (leftlinect < Leftct)
                                        {
                                            formGraphics.DrawLine(Pens.Red, nxtmv * 3, nys, minplace * 3, nye);
                                            leftlinect++;
                                            nxtmv = minplace;
                                            nys = nye;
                                            nye += 10;
                                            mindiff = 999;
                                        }
                                        if (leftlinect >= Leftct)
                                        {
                                            MessageBox.Show("seek"+seektime.ToString());
                                            break;
                                        }
                                    }

                                }
                            }
                        }

                    }
                    else if (leftorright == 1)//left dir
                    {
                        diff = 0;
                        mindiff = -999;
                        minplace = 0;
                        nxtmv = t9;
                        for (int j = 0; j < 8; j++)
                        {
                            for (o = 0; o < 8; o++)
                            {


                                if (nxtmv > array[o])
                                {
                                    // MessageBox.Show("nxtmv" + nxtmv.ToString()+ "array[o]"+array[o].ToString());
                                    diff = array[o] - nxtmv;
                                    if (diff > mindiff)
                                    {
                                        seektime +=Math.Abs( array[o] - nxtmv);
                                        mindiff = diff;
                                        minplace = array[o];
                                        //MessageBox.Show("555");

                                    }
                                }
                            }
                            formGraphics.DrawLine(Pens.Red, nxtmv * 3, nys, minplace * 3, nye);
                            nxtmv = minplace;
                            nys = nye;
                            leftlinect++;
                            nye += 10;
                            mindiff = -999;
                            if (leftlinect > Leftct)
                            {
                                break;
                            }
                        }
                        ////////// return to first
                        mxdff = -999;
                        mxplc = 0;
                        nye += 10;
                        for (int j = 0; j < 8; j++)
                        {
                            for (o = 0; o < 8; o++)
                            {
                                if (nxtmv < array[o])
                                {
                                    // MessageBox.Show("nxtmv" + nxtmv.ToString()+ "array[o]"+array[o].ToString());
                                    diff = Math.Abs(array[o] - nxtmv);
                                    if (diff > mxdff)
                                    {
                                        seektime += Math.Abs(array[o] - nxtmv);
                                        mxdff = diff;
                                        mxplc = array[o];
                                        MessageBox.Show("hel");

                                    }
                                }
                            }

                            formGraphics.DrawLine(Pens.Red, nxtmv * 3, nys, mxplc * 3, nye);
                        }
                        ////////////////
                        diff = 0;
                        nxtmv = mxplc;
                        mindiff = -999;
                        minplace = 0;
                        nys = nye;
                        nye += 10;

                        for (int j = 0; j < 8; j++)
                        {
                            for (o = 0; o < 8; o++)
                            {


                                if (nxtmv > array[o])
                                {
                                    // MessageBox.Show("nxtmv" + nxtmv.ToString()+ "array[o]"+array[o].ToString());
                                    diff = array[o] - nxtmv;
                                    if (diff > mindiff)
                                    {
                                        seektime += Math.Abs(array[o] - nxtmv);
                                        mindiff = diff;
                                        minplace = array[o];
                                        //MessageBox.Show("555");

                                    }
                                }
                            }
                            formGraphics.DrawLine(Pens.Red, nxtmv * 3, nys, minplace * 3, nye);
                            nxtmv = minplace;
                            nys = nye;
                            rightlinect++;
                            nye += 10;
                            mindiff = -999;
                            if (rightlinect > rightct)
                            {
                                MessageBox.Show("seek"+seektime.ToString());
                                break;
                            }
                        }
                        /////////////\\\\\
                    }
                }

            }

        }
    }
}