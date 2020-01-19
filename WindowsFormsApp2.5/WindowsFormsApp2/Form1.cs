using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;//stopWatch

namespace WindowsFormsApp2
{
    public class point2start
    {
        public double x, y, t;
        public Color color;
        public int forsedState;
        public point2start(double xin, double yin, int state = -1, double tin = 0)
        {
            color = Color.Black;
            x = xin;
            y = yin;
            forsedState = state;
            t = tin;
        }
        public point2start(double xin, double yin, Color col, int state = -1, double tin = 0)
        {
            color = col;
            x = xin;
            y = yin;
            forsedState = state;
            t = tin;
        }
    }
    public partial class Form1 : Form
    {
        #region color
        Color[] colors =
        {
        Color.FromArgb(255, 255, 128, 128),
        Color.FromArgb(255, 255, 192, 128),
        Color.FromArgb(255, 255, 255, 128),
        Color.FromArgb(255, 128, 255, 128),
        Color.FromArgb(255, 128, 255, 255),
        Color.FromArgb(255, 128, 128, 255),
        Color.FromArgb(255, 255, 128, 255),
        Color.Silver,
        Color.Red,
        Color.FromArgb(255, 255, 128, 0),
        Color.Yellow,
        Color.Lime,
        Color.Cyan,
        Color.Blue,
        Color.Fuchsia,
        Color.Gray,
        Color.FromArgb(255, 192, 0, 0),
        Color.FromArgb(255, 192, 64, 0),
        Color.FromArgb(255, 192, 192, 0),
        Color.FromArgb(255, 0, 192, 0),
        Color.FromArgb(255, 0, 192, 192),
        Color.FromArgb(255, 0, 0, 192),
        Color.FromArgb(255, 192, 0, 192),
        Color.FromArgb(255, 64, 64, 64),
        Color.Maroon,
        Color.FromArgb(255, 128, 64, 0),
        Color.Olive,
        Color.Green,
        Color.Teal,
        Color.Navy,
        Color.Purple,
        Color.Black,
        Color.FromArgb(255, 64, 0, 0),
        Color.FromArgb(255, 128, 64, 64),
        Color.FromArgb(255, 64, 64, 0),
        Color.FromArgb(255, 0, 64, 0),
        Color.FromArgb(255, 0, 64, 64),
        Color.FromArgb(255, 0, 0, 64),
        Color.FromArgb(255, 64, 0, 64)};
        #endregion

        double x0 = 10, y0 = -20, scale = 1, e = 0.1, dt0 = 0.05;
        double[] kx = new double[4], ky = new double[4];//
        double x, y, px, py, t = 0;
        public bool butwork = false;
        bool backIsWhite = true, whiteBitmapReady = false, paramChanged = true, AddEnabled = false, critical = false;
        double gK = -1, k = 0.7, alpha = 200, h = 20, a = 10, stp = 0.1, xMin, pxMin, xMax, pxMax, iaSaved = 0, alphaAdd = 200, hAdd = 20, gArgK = 1, stFplus = 0, stFminus = 0, gConst = 0;
        long ia = 0;//, iaSaved = 0;
        int Hmid, Wmid, scaleStep = -1, ySign, pySign, Fsign, pFsign, Fplus = 0, Fminus = 0, sFplus = 0, sFminus = 0, GTypeSelected = -1, GArgSelected = -1, tFplus = 0, tFminus = 0;
        int counterBackStarts = 0;
        List<double> xStart = new List<double>(), yStart = new List<double>(), xCheck = new List<double>(), yCheck = new List<double>(), tCheck = new List<double>();
        List<point2start> Starts = new List<point2start>();

        private void button2_Click(object sender, EventArgs e)
        {
            frame = picOut.Image;
            gr = Graphics.FromImage(frame);
            backIsWhite = false;

            critical = true;
            //m-gK
            //gConst-g
            #region criticalMin
            double m = Math.Abs(gK);
            double gConstCritical = m * (alpha - h / 2);//ck
            double constCritical = m * Math.Pow((Math.Sign(gConstCritical) * alpha - gConstCritical / m), 2) / (1 + m * k * k);

            double dx = 1 / scale;
            double px2 = -Math.Sqrt(constCritical / m) + gConstCritical / m;
            double x2 = px2, py2 = 0, y2 = 0, x2max = Math.Sqrt(constCritical / m) + gConstCritical / m;
            while (x2 <= x2max)
            {
                x2 += dx;
                y2 = constCritical - m * Math.Pow(x2 - gConstCritical / m, 2);
                if (y2 > 0)
                    y2 = Math.Sqrt(y2);
                else
                    continue;

                if (((Math.Abs(x2 - px2) + Math.Abs(y2 - py2)) * scale > 2))
                {
                    gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(-py2 * scale), Wmid + Convert.ToSingle(x2 * scale), Hmid + Convert.ToSingle(-y2 * scale));

                    gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(py2 * scale), Wmid + Convert.ToSingle(x2 * scale), Hmid + Convert.ToSingle(y2 * scale));
                    px2 = x2;
                    py2 = y2;
                }
            }

            gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(-py2 * scale), Wmid + Convert.ToSingle(x2max * scale), Hmid);

            gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(py2 * scale), Wmid + Convert.ToSingle(x2max * scale), Hmid);


            #endregion
            #region critical
            if (gConst == 0)
            {
                constCritical = alpha * alpha;
            }
            else
            {
                double kl = (alphaAdd + gConst / m) / (alpha - gConst / m);
                if (kl > 1)
                {
                    constCritical = Math.Pow((Math.Sign(gConst) * alpha - gConst / m), 2);
                }
                else
                {
                    constCritical = Math.Pow((Math.Sign(gConst) * alphaAdd - gConst / m), 2);
                }
            }
            constCritical *= m / (1 + m * k * k);

            px2 = -Math.Sqrt(constCritical / m) + gConst / m;
            x2 = px2; py2 = 0; y2 = 0; x2max = Math.Sqrt(constCritical / m) + gConst / m;
            //Int16 pFvalA = F(px2, py2), pFvalB=F(px2, -py2), FvalA=0, FvalB=0;

            while (x2 <= x2max)
            {
                //pFvalA = FvalA;
                //pFvalB = FvalB;
                x2 += dx;
                y2 = constCritical - m * Math.Pow(x2 - gConst / m, 2);
                if (y2 > 0)
                    y2 = Math.Sqrt(y2);
                else
                    continue;

                if (((Math.Abs(x2 - px2) + Math.Abs(y2 - py2)) * scale > 2))
                {
                    gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(-py2 * scale), Wmid + Convert.ToSingle(x2 * scale), Hmid + Convert.ToSingle(-y2 * scale));

                    gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(py2 * scale), Wmid + Convert.ToSingle(x2 * scale), Hmid + Convert.ToSingle(y2 * scale));
                    px2 = x2;
                    py2 = y2;
                }
            }

            gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(-py2 * scale), Wmid + Convert.ToSingle(x2max * scale), Hmid);

            gr.DrawLine(mpen, Wmid + Convert.ToSingle(px2 * scale), Hmid + Convert.ToSingle(py2 * scale), Wmid + Convert.ToSingle(x2max * scale), Hmid);

            px2 = constCritical + 2 * gConst * (alpha - h) - gConst * gConst / m - m * (Math.Pow(alpha - h, 2) - constCritical * k * k);
            if (px2 >= 0)
            {
                px2 = px2 == 0 ? 0 : Math.Sqrt(px2);

                x2 = (k * px2 + (gConst * k * k + alpha - h)) / (m * k * k + 1);//++B2
                y2 = constCritical - m * Math.Pow(x2 - gConst / m, 2);
                if (y2 > 0)
                {
                    xStart.Add(x2);
                    //yStart.Add(-Math.Sqrt(y2));//!!! брать из уравнения прямой !!!
                    yStart.Add((alpha - h - x2) / k);
                    Starts.Add(new point2start(x2, (alpha - h - x2) / k, colors[0]));
                }

                x2 = -(k * px2 - (gConst * k * k + alpha - h)) / (m * k * k + 1);//--A2
                y2 = constCritical - m * Math.Pow(x2 - gConst / m, 2);
                if (y2 > 0)
                {
                    xStart.Add(x2);
                    //yStart.Add(Math.Sqrt(y2));
                    yStart.Add((alpha - h - x2) / k);
                    Starts.Add(new point2start(x2, (alpha - h - x2) / k, colors[1]));
                }
            }

            px2 = constCritical - 2 * gConst * (alphaAdd - hAdd) - gConst * gConst / m - m * (Math.Pow(alphaAdd - hAdd, 2) - constCritical * k * k);
            if (px2 >= 0)
            {
                px2 = px2 == 0 ? 0 : Math.Sqrt(px2);

                x2 = (k * px2 + (gConst * k * k - alphaAdd + hAdd)) / (m * k * k + 1);//++A4
                y2 = constCritical - m * Math.Pow(x2 - gConst / m, 2);
                if (y2 > 0)
                {
                    xStart.Add(x2);
                    //yStart.Add(Math.Sqrt(y2));
                    yStart.Add((hAdd - alphaAdd - x2) / k);
                    Starts.Add(new point2start(x2, (hAdd - alphaAdd - x2) / k, colors[2]));
                }

                x2 = -(k * px2 - (gConst * k * k - alphaAdd + hAdd)) / (m * k * k + 1);//--B4
                y2 = constCritical - m * Math.Pow(x2 - gConst / m, 2);
                if (y2 > 0)
                {
                    xStart.Add(x2);
                    //yStart.Add(-Math.Sqrt(y2));
                    yStart.Add((hAdd - alphaAdd - x2) / k);
                    Starts.Add(new point2start(x2, (hAdd - alphaAdd - x2) / k, colors[3]));
                }
            }

            //xStart.Add(() / (m * k * k + 1));

            #endregion
            picOut.Image = frame;

            listBoxGType.SelectedIndex = listBoxGType.Items.Count - 1;
            listBoxGArg.SelectedIndex = 0;
            printImageReverse(-dt0 / 2);

            /*
            if (xStart.Count != 0)
            {
                x0 = xStart[0];
                y0 = yStart[0];
                xStart.RemoveAt(0);
                yStart.RemoveAt(0);
                dt0 = -dt0;
                listBoxGType.SelectedIndex = listBoxGType.Items.Count-1;
                //timerPrint.Start();
                button1_Click(sender, e);
            }*/

        }

        private void textBoxGConst_TextChanged(object sender, EventArgs e)
        {
            double pgConst = gConst;
            bool ist = Double.TryParse(textBoxGConst.Text, out gConst);
            if (!(ist))
            {
                textBoxGConst.BackColor = Color.Red;
                button1.Enabled = false;
            }
            else
            {
                if (CheckAll())
                {
                    textBoxGConst.BackColor = Color.White;
                    button1.Enabled = true;
                }
                else
                {
                    textBoxGConst.BackColor = Color.Red;
                    button1.Enabled = false;
                    gConst = pgConst;
                }

            }
        }

        double rangeX, rangeY;
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            timerPrint.Start();
            printImage(dt0);
        }

        private void textBoxT_TextChanged(object sender, EventArgs e)
        {
            if (textBoxT.Enabled)
            {
                double pt = t;
                bool ist = Double.TryParse(textBoxT.Text, out t);
                if (!(ist))
                {
                    textBoxT.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxT.BackColor = Color.White;
                        button1.Enabled = true;
                    }
                    else
                    {
                        textBoxT.BackColor = Color.Red;
                        button1.Enabled = false;
                        t = pt;
                    }

                }
            }
        }

        private void textBoxDT0_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDT0.Enabled)
            {
                double pdt0 = dt0;
                bool isDt0 = Double.TryParse(textBoxDT0.Text, out dt0);
                if (!(isDt0))
                {
                    textBoxDT0.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxDT0.BackColor = Color.White;
                        button1.Enabled = true;
                    }
                    else
                    {
                        textBoxDT0.BackColor = Color.Red;
                        button1.Enabled = false;
                        dt0 = pdt0;
                    }

                }
            }
        }

        private void textBoxGArgK_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGArgK.Enabled)
            {
                double pgArgK = gArgK;
                bool isGArgK = Double.TryParse(textBoxGArgK.Text, out gArgK);
                if (!(isGArgK))
                {
                    textBoxGArgK.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxGArgK.BackColor = Color.White;
                        button1.Enabled = true;
                    }
                    else
                    {
                        textBoxGArgK.BackColor = Color.Red;
                        button1.Enabled = false;
                        gArgK = pgArgK;
                    }

                }
            }
        }

        private void listBoxGArg_SelectedIndexChanged(object sender, EventArgs e)
        {
            GArgSelected = listBoxGArg.SelectedIndex;

        }

        private void listBoxGType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GTypeSelected = listBoxGType.SelectedIndex;
            if (GTypeSelected > 0)
            {
                listBoxGArg.Visible = true;
                textBoxGArgK.Visible = true;
            }
            else
            {
                listBoxGArg.Visible = false;
                textBoxGArgK.Visible = false;
            }
        }

        private void textBoxHAdd_TextChanged(object sender, EventArgs e)
        {
            if (textBoxH.Enabled)
            {
                double phAdd = hAdd;
                bool isHAdd = Double.TryParse(textBoxHAdd.Text, out hAdd);
                if (!(isHAdd))
                {
                    textBoxHAdd.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxHAdd.BackColor = Color.White;
                        button1.Enabled = true;
                        backIsWhite = false;
                        whiteBitmapReady = false;
                        writeBackground();
                    }
                    else
                    {
                        textBoxHAdd.BackColor = Color.Red;
                        button1.Enabled = false;
                        hAdd = phAdd;
                    }

                }
            }
        }

        private void textBoxAlphaAdd_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAlphaAdd.Enabled)
            {
                double palphaAdd = alphaAdd;
                bool isAAdd = Double.TryParse(textBoxAlphaAdd.Text, out alphaAdd);
                if (!(isAAdd))
                {
                    textBoxAlphaAdd.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxAlphaAdd.BackColor = Color.White;
                        button1.Enabled = true;
                        backIsWhite = false;
                        whiteBitmapReady = false;
                        writeBackground();
                    }
                    else
                    {
                        textBoxAlphaAdd.BackColor = Color.Red;
                        button1.Enabled = false;
                        alphaAdd = palphaAdd;
                    }

                }
            }
        }

        private void checkBoxShowAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAdd.Checked)
            {
                GTypeSelected = listBoxGType.SelectedIndex;
                AddEnabled = true;
                Width += 84;
                labelAlpha.Text = "α+";
                labelH.Text = "h+";
            }
            else
            {
                GTypeSelected = -1;
                AddEnabled = false;
                Width -= 84;
                labelAlpha.Text = "α";
                labelH.Text = "h";
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            whiteBitmapReady = false;
            picOutPoint();
        }

        Stopwatch stopWatchkImax = new Stopwatch();
        Pen mpen = new Pen(Color.Black, 2);
        Bitmap whiteBack, whiteBackPoint;
        Image whiteBackIm, ImPoint, frame;
        Graphics gr;
        private void textBoxX_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxX.Enabled)
            {
                double px0 = x0;
                bool isX = Double.TryParse(textBoxX.Text, out x0);
                if (!(isX))
                {
                    textBoxX.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxX.BackColor = Color.White;
                        button1.Enabled = true;
                        picOutPoint();
                    }
                    else
                    {
                        textBoxX.BackColor = Color.Red;
                        button1.Enabled = false;
                        x0 = px0;
                    }

                }
            }
        }

        private void picOut_MouseEnter(object sender, EventArgs e)
        {
            picOut.Focus();
        }

        private void textBoxG_TextChanged(object sender, EventArgs e)
        {
            if (textBoxG.Enabled)
            {
                double pgK = gK;
                bool isGK = Double.TryParse(textBoxG.Text, out gK);
                if (!(isGK))
                {
                    textBoxG.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxG.BackColor = Color.White;
                        button1.Enabled = true;
                    }
                    else
                    {
                        textBoxG.BackColor = Color.Red;
                        button1.Enabled = false;
                        gK = pgK;
                    }

                }
            }
        }

        private void textBoxAlpha_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAlpha.Enabled)
            {
                double palpha = alpha;
                bool isA = Double.TryParse(textBoxAlpha.Text, out alpha);
                if (!(isA))
                {
                    textBoxAlpha.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxAlpha.BackColor = Color.White;
                        button1.Enabled = true;
                        backIsWhite = false;
                        whiteBitmapReady = false;
                        writeBackground();
                    }
                    else
                    {
                        textBoxAlpha.BackColor = Color.Red;
                        button1.Enabled = false;
                        alpha = palpha;
                    }

                }
            }
        }

        private void textBoxH_TextChanged(object sender, EventArgs e)
        {
            if (textBoxH.Enabled)
            {
                double ph = h;
                bool isH = Double.TryParse(textBoxH.Text, out h);
                if (!(isH))
                {
                    textBoxH.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxH.BackColor = Color.White;
                        button1.Enabled = true;
                        backIsWhite = false;
                        whiteBitmapReady = false;
                        writeBackground();
                    }
                    else
                    {
                        textBoxH.BackColor = Color.Red;
                        button1.Enabled = false;
                        h = ph;
                    }

                }
            }
        }

        private void textBoxK_TextChanged(object sender, EventArgs e)
        {
            if (textBoxK.Enabled)
            {
                double pk = k;
                bool isK = Double.TryParse(textBoxK.Text, out k);
                if (!(isK))
                {
                    textBoxK.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxK.BackColor = Color.White;
                        button1.Enabled = true;
                        backIsWhite = false;
                        whiteBitmapReady = false;
                        writeBackground();
                    }
                    else
                    {
                        textBoxK.BackColor = Color.Red;
                        button1.Enabled = false;
                        k = pk;
                    }

                }
            }
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            if (textBoxA.Enabled)
            {
                double pa = a;
                bool isA = Double.TryParse(textBoxA.Text, out a);
                if (!(isA))
                {
                    textBoxA.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxA.BackColor = Color.White;
                        button1.Enabled = true;
                    }
                    else
                    {
                        textBoxA.BackColor = Color.Red;
                        button1.Enabled = false;
                        a = pa;
                    }

                }
            }
        }

        private void picOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBoxX.Enabled)
            {
                if (!backIsWhite) writeBackground();
                textBoxX.Enabled = false;
                textBoxY.Enabled = false;
                x0 = (e.X - Wmid) / scale;
                y0 = (-e.Y + Hmid) / scale;
                CheckAll();
                textBoxX.Text = Convert.ToString(x0);
                textBoxY.Text = Convert.ToString(y0);
                picOutPoint();
                textBoxX.Enabled = true;
                textBoxY.Enabled = true;
            }
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            if (textBoxY.Enabled)
            {
                double py0 = y0;
                bool isY = Double.TryParse(textBoxY.Text, out y0);
                if (!(isY))
                {
                    textBoxY.BackColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    if (CheckAll())
                    {
                        textBoxY.BackColor = Color.White;
                        button1.Enabled = true;
                        picOutPoint();
                    }
                    else
                    {
                        textBoxY.BackColor = Color.Red;
                        button1.Enabled = false;
                        y0 = py0;
                    }

                }
            }
        }

        private void scaleHide(object sender, EventArgs e)
        {
            labelScale.Visible = false;
            timerScaleShow.Enabled = false;
        }

        Int16 F(double ix, double iy)
        {
            double sigma = ix + k * iy;
            if (sigma >= alpha)
                return 1;
            if (sigma <= -alphaAdd)
                return -1;

            if (sigma >= alpha - h)
                return 2;
            if (sigma <= -alphaAdd + hAdd)
                return -2;
            return 0;

        }

        Int16 F(double ix, double iy, double px, double py)
        {
            double sigma = ix + k * iy;
            if (sigma >= alpha)
                return 1;
            else if (sigma <= -alphaAdd)
                return -1;
            else
            {
                //canonical version - based just at sigma sign. Doesn't work correct with negative dt.

                double psigma = px + k * py;
                if ((sigma <= hAdd - alphaAdd) && (sigma >= psigma))
                    return -1;
                else if ((sigma >= alpha - h) && (sigma <= psigma))
                    return 1;
                else return 0;


                //new version - based on logic of system and, therefore, signum of iy. px and py are ignoring. May cause mistakes.
                /*
                if (sigma >= alpha - h)
                    if (iy > 0)
                        return 0;
                    else
                        return 1;
                if (sigma <= hAdd - alphaAdd)
                    if (iy > 0)
                        return -1;
                    else
                        return 0;*/
            }
            return 0;//never used, just to be sure, that function would return something anyway.
        }

        double g(double ix, double iy, double it)
        {
            if (GTypeSelected == 0)
                return gK + gConst;
            else
                if (GTypeSelected == 1)
            {
                if (GArgSelected == 0)
                    return gK * Math.Sin(ix * gArgK) + gConst;
                else if (GArgSelected == 1)
                    return gK * Math.Sin(iy * gArgK) + gConst;
                else
                    return gK * Math.Sin(it * gArgK) + gConst;
            }
            else
                if (GTypeSelected == 2)
            {
                if (GArgSelected == 0)
                    return gK * Math.Cos(ix * gArgK) + gConst;
                else if (GArgSelected == 1)
                    return gK * Math.Cos(iy * gArgK) + gConst;
                else
                    return gK * Math.Cos(it * gArgK) + gConst;
            }
            else
                if (GTypeSelected == 3)
            {
                if (GArgSelected == 0)
                    return gK * Math.Pow(Math.Sin(ix * gArgK), 2) + gConst;
                else if (GArgSelected == 1)
                    return gK * Math.Pow(Math.Sin(iy * gArgK), 2) + gConst;
                else
                    return gK * Math.Pow(Math.Sin(it * gArgK), 2) + gConst;
            }
            else
                if (GTypeSelected == 4)
            {
                if (GArgSelected == 0)
                    return gK * Math.Pow(Math.Cos(ix * gArgK), 2) + gConst;
                else if (GArgSelected == 1)
                    return gK * Math.Pow(Math.Cos(iy * gArgK), 2) + gConst;
                else
                    return gK * Math.Pow(Math.Cos(it * gArgK), 2) + gConst;
            }

            else
                if (true)
            {
                if (GArgSelected == 0)
                    return gK * ix * gArgK + gConst;
                else if (GArgSelected == 1)
                    return gK * iy * gArgK + gConst;
                else
                    return gK * it * gArgK + gConst;
            }
        }

        void writeBackground()
        {
            if (!AddEnabled)
            {
                hAdd = h;
                alphaAdd = alpha;
            }

            if (!whiteBitmapReady)
            {
                Hmid = Convert.ToInt32(picOut.Size.Height / 2);
                Wmid = Convert.ToInt32(picOut.Size.Width / 2);

                rangeX = 10 * Wmid / scale;
                rangeY = 10 * Hmid / scale;

                if (whiteBack != null)
                {
                    whiteBack.Dispose();
                }
                whiteBack = new Bitmap(picOut.Size.Width, picOut.Size.Height);

                int pi = 0, pj = 0;
                double sigma = 0;
                for (int i = 0; i < whiteBack.Width; i++)
                    for (int j = 0; j < whiteBack.Height; j++)
                    {
                        if ((j == Hmid) || (i == Wmid)) whiteBack.SetPixel(i, j, Color.Black); //axes printing at the middle
                        else
                        {
                            sigma = ((i - Wmid) + k * (Hmid - j)) / scale;
                            if (((sigma <= alpha) && (sigma >= alpha - h)) || ((sigma >= -alphaAdd) && (sigma <= hAdd - alphaAdd)))
                            {
                                whiteBack.SetPixel(i, j, Color.FromArgb(0x78D5ECD8));
                            }
                            else
                            //if (F((i - Wmid) / scale, (Hmid - j) / scale, (pi - Wmid) / scale, (Hmid - pj) / scale) == 0) whiteBack.SetPixel(i, j, Color.White);
                            if ((sigma < alpha) && (sigma > -alphaAdd)) whiteBack.SetPixel(i, j, Color.White);
                            else whiteBack.SetPixel(i, j, Color.FromArgb(0x78EED8D8));
                        }
                        pi = i;
                        pj = j;
                    }
                whiteBitmapReady = true;
                whiteBackIm = whiteBack;
            }
            picOut.Image = whiteBackIm;
            backIsWhite = true;
        }
        void picOutPoint()
        {
            if (whiteBackPoint != null)
            {
                whiteBackPoint.Dispose();
            }
            ImPoint = whiteBackIm;
            //Bitmap whiteBackPoint = whiteBack;
            whiteBackPoint = new Bitmap(ImPoint);
            int i = Convert.ToInt32(x0 * scale) + Wmid, j = Hmid - Convert.ToInt32(y0 * scale);
            //whiteBackPoint.SetPixel(i, j, Color.Red);
            if ((i - 2 >= 0) && (j - 2 >= 0) && (j + 2 <= whiteBackPoint.Height) && (i + 2 <= whiteBackPoint.Width))
            {
                /*
                whiteBackPoint.SetPixel(i - 1, j, Color.FromArgb(whiteBackPoint.GetPixel(i - 1, j).ToArgb() + 0x100094FF));
                whiteBackPoint.SetPixel(i + 1, j, Color.FromArgb(whiteBackPoint.GetPixel(i + 1, j).ToArgb() + 0x100094FF));
                whiteBackPoint.SetPixel(i, j + 1, Color.FromArgb(whiteBackPoint.GetPixel(i, j + 1).ToArgb() + 0x100094FF));
                whiteBackPoint.SetPixel(i, j - 1, Color.FromArgb(whiteBackPoint.GetPixel(i, j - 1).ToArgb() + 0x100094FF));

                whiteBackPoint.SetPixel(i - 1, j - 1, Color.FromArgb(whiteBackPoint.GetPixel(i - 1, j - 1).ToArgb() + 0x300094FF));
                whiteBackPoint.SetPixel(i + 1, j + 1, Color.FromArgb(whiteBackPoint.GetPixel(i + 1, j + 1).ToArgb() + 0x300094FF));
                whiteBackPoint.SetPixel(i - 1, j + 1, Color.FromArgb(whiteBackPoint.GetPixel(i - 1, j + 1).ToArgb() + 0x300094FF));
                whiteBackPoint.SetPixel(i + 1, j - 1, Color.FromArgb(whiteBackPoint.GetPixel(i + 1, j - 1).ToArgb() + 0x300094FF));


                whiteBackPoint.SetPixel(i - 2, j - 1, Color.FromArgb(whiteBackPoint.GetPixel(i - 2, j - 1).ToArgb() + 0x500094FF));
                whiteBackPoint.SetPixel(i - 2, j + 1, Color.FromArgb(whiteBackPoint.GetPixel(i - 2, j + 1).ToArgb() + 0x500094FF));
                whiteBackPoint.SetPixel(i + 2, j - 1, Color.FromArgb(whiteBackPoint.GetPixel(i + 2, j - 1).ToArgb() + 0x500094FF));
                whiteBackPoint.SetPixel(i + 2, j + 1, Color.FromArgb(whiteBackPoint.GetPixel(i + 2, j + 1).ToArgb() + 0x500094FF));

                whiteBackPoint.SetPixel(i - 1, j - 2, Color.FromArgb(whiteBackPoint.GetPixel(i - 1, j - 2).ToArgb() + 0x500094FF));
                whiteBackPoint.SetPixel(i - 1, j + 2, Color.FromArgb(whiteBackPoint.GetPixel(i - 2, j + 2).ToArgb() + 0x500094FF));
                whiteBackPoint.SetPixel(i + 1, j - 2, Color.FromArgb(whiteBackPoint.GetPixel(i + 1, j - 2).ToArgb() + 0x500094FF));
                whiteBackPoint.SetPixel(i + 1, j + 2, Color.FromArgb(whiteBackPoint.GetPixel(i + 1, j + 2).ToArgb() + 0x500094FF));

                whiteBackPoint.SetPixel(i - 2, j, Color.FromArgb(0x780094FF));
                whiteBackPoint.SetPixel(i + 2, j, Color.FromArgb(0x780094FF));
                whiteBackPoint.SetPixel(i, j - 2, Color.FromArgb(0x780094FF));
                whiteBackPoint.SetPixel(i, j + 2, Color.FromArgb(0x780094FF));
                */
                whiteBackPoint.SetPixel(i - 1, j, Color.FromArgb(0x100094FF));
                whiteBackPoint.SetPixel(i + 1, j, Color.FromArgb(0x100094FF));
                whiteBackPoint.SetPixel(i, j + 1, Color.FromArgb(0x100094FF));
                whiteBackPoint.SetPixel(i, j - 1, Color.FromArgb(0x100094FF));

                whiteBackPoint.SetPixel(i - 1, j - 1, Color.FromArgb(0x300094FF));
                whiteBackPoint.SetPixel(i + 1, j + 1, Color.FromArgb(0x300094FF));
                whiteBackPoint.SetPixel(i - 1, j + 1, Color.FromArgb(0x300094FF));
                whiteBackPoint.SetPixel(i + 1, j - 1, Color.FromArgb(0x300094FF));


                whiteBackPoint.SetPixel(i - 2, j - 1, Color.FromArgb(0x500094FF));
                whiteBackPoint.SetPixel(i - 2, j + 1, Color.FromArgb(0x500094FF));
                whiteBackPoint.SetPixel(i + 2, j - 1, Color.FromArgb(0x500094FF));
                whiteBackPoint.SetPixel(i + 2, j + 1, Color.FromArgb(0x500094FF));

                whiteBackPoint.SetPixel(i - 1, j - 2, Color.FromArgb(0x500094FF));
                whiteBackPoint.SetPixel(i - 1, j + 2, Color.FromArgb(0x500094FF));
                whiteBackPoint.SetPixel(i + 1, j - 2, Color.FromArgb(0x500094FF));
                whiteBackPoint.SetPixel(i + 1, j + 2, Color.FromArgb(0x500094FF));

                whiteBackPoint.SetPixel(i - 2, j, Color.FromArgb(0x780094FF));
                whiteBackPoint.SetPixel(i + 2, j, Color.FromArgb(0x780094FF));
                whiteBackPoint.SetPixel(i, j - 2, Color.FromArgb(0x780094FF));
                whiteBackPoint.SetPixel(i, j + 2, Color.FromArgb(0x780094FF));
            }
            picOut.Image = whiteBackPoint;
            backIsWhite = false;
        }
        public Form1()
        {
            InitializeComponent();
            //
            writeBackground();
            picOutPoint();
            picOut.MouseWheel += new MouseEventHandler(picOut_MouseWheel);
        }
        //picOut.MouseWheel+= new MouseEventHandler(picOut_MouseWheel);
        private void picOut_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale + stp >= 10 * stp))
                {
                    scaleStep++;
                    stp = Math.Pow(10, scaleStep);
                    scale = stp;
                }
                else
                    scale += stp;
            }
            else
            {
                if (scale - stp <= stp)
                {
                    scaleStep--;
                    stp = Math.Pow(10, scaleStep);
                    scale = 9 * stp;
                }
                else
                    scale -= stp;
            }

            whiteBitmapReady = false;
            writeBackground();
            scaleShow();
        }

        void scaleShow()
        {
            labelScale.Text = String.Concat("x", Convert.ToString(scale));
            labelScale.Visible = true;
            timerScaleShow.Enabled = false;
            timerScaleShow.Start();
        }

        public void printImageReverse(double dt)
        {
            frame = picOut.Image;
            gr = Graphics.FromImage(frame);
            Pen mpen = new Pen(colors[xStart.Count], 1);
            int isChecking;
            int state;
            while (Starts.Count != 0)
            {
                counterBackStarts++;
                List<point2start> PossiblyStarts = new List<point2start>();
                mpen.Color = Starts[0].color;
                x = Starts[0].x;
                y = Starts[0].y;
                state = Starts[0].forsedState;

                Fsign = Math.Sign(F(x, y));
                t = Starts[0].t;

                //y +=dt* (g(x, y, t) - a * Fsign);
                x0 = x;
                y0 = y;
                if (Starts[0].forsedState == -1)
                {
                    isChecking = 1;
                    xCheck.Clear();
                    yCheck.Clear();
                    xCheck.Add(x);
                    yCheck.Add(y);
                    tCheck.Add(t);
                }
                else
                {
                    isChecking = 0;
                    Fsign = Starts[0].forsedState;
                }

                Starts.RemoveAt(0);

                if (stopWatchkImax.IsRunning)
                    stopWatchkImax.Restart();
                else
                    stopWatchkImax.Start();

                while (stopWatchkImax.ElapsedMilliseconds < 1000)
                {
                    ia++;
                    //integrating with just Eulers method
                    kx[0] = dt * y;
                    ky[0] = dt * (g(x, y, t) - a * Fsign);

                    t += dt;

                    x += kx[0];
                    y += ky[0];

                    // checking for out of printable range
                    if ((rangeX < Math.Abs(x)) && (rangeY < Math.Abs(y)))
                        break;

                    if (state != -1)
                    {
                        Fsign = F(x, y);
                        if (Fsign == 2 || Fsign == -2)
                        {
                            Fsign *= state;
                            xCheck.Add(x);
                            yCheck.Add(y);
                            tCheck.Add(t);
                        }
                        else
                            if (state != Fsign)
                        {
                            xCheck.Clear();
                            yCheck.Clear();
                            tCheck.Clear();
                            break;
                        }
                        else
                        {
                            state = -1;
                            for (int i = 0; i < xCheck.Count - 1; i++)
                            {
                                gr.DrawLine(mpen, Wmid + Convert.ToSingle(xCheck[i] * scale), Hmid + Convert.ToSingle(-yCheck[i] * scale), Wmid + Convert.ToSingle(xCheck[i + 1] * scale), Hmid + Convert.ToSingle(-yCheck[i + 1] * scale));
                            }
                            Starts.AddRange(PossiblyStarts);
                        }

                        if ((F(x, y) != F(x - kx[0], y - ky[0])) && (Math.Abs(F(x, y)) == 1))
                        {
                            if (PossiblyStarts.Count < 10 && Starts.Count < 100 && counterBackStarts < 150)
                                PossiblyStarts.Add(new point2start(x - kx[0], y - ky[0], mpen.Color, 0, t));
                        }

                    }
                    else
                    if (isChecking != 0)
                    {
                        Fsign = F(x, y);

                        if (Fsign == 2 || Fsign == -2)
                        {
                            //first way to check - if 2 or -2 is to set it as +-1
                            Fsign = isChecking == 1 ? Math.Sign(Fsign) : 0; //just continue checking

                        }
                        else
                        {
                            if (Fsign == 0)
                            {
                                if (isChecking == 1)
                                {
                                    //but system can't come from 1 or -1 directly to 0, so, it's wrong way

                                    isChecking = 2;//second way - 2 and -2 are used as 0

                                    x = xCheck[0];
                                    y = yCheck[0];
                                    t = tCheck[0];
                                    x0 = x;
                                    y0 = y;
                                    //if checking is false - 2 and -2 would be converted to 1 and -1

                                    kx[0] = dt * y;
                                    ky[0] = dt * g(x, y, t);

                                    pFsign = Math.Sign(F(x + kx[0], y + ky[0]));

                                }
                                else
                                {
                                    isChecking = 0;
                                }
                            }
                            else
                            {//+-1 - way 1 were correct
                                if (isChecking == 1)
                                {
                                    isChecking = 0;
                                    //first way was right, should draw all lines
                                    Starts.AddRange(PossiblyStarts);
                                    for (int i = 0; i < xCheck.Count - 1; i++)
                                    {
                                        gr.DrawLine(mpen, Wmid + Convert.ToSingle(xCheck[i] * scale), Hmid + Convert.ToSingle(-yCheck[i] * scale), Wmid + Convert.ToSingle(xCheck[i + 1] * scale), Hmid + Convert.ToSingle(-yCheck[i + 1] * scale));
                                    }
                                }
                                else
                                {
                                    //it's, obviously, error :c
                                }
                            }
                            xCheck.Clear();
                            yCheck.Clear();
                        }

                        if ((F(x, y) != F(x - kx[0], y - ky[0])) && (Math.Abs(F(x, y)) == 1))
                        {
                            if (PossiblyStarts.Count < 10 && Starts.Count<100 && counterBackStarts<150)
                                PossiblyStarts.Add(new point2start(x - kx[0], y - ky[0], mpen.Color, 0, t));
                        }
                    }
                    else
                    {
                        //no checking, no forced state
                        Fsign = Math.Sign(F(x, y));

                        if ((Fsign != pFsign) && (pFsign == 0))
                        {
                            if (xCheck.Count != 0)
                            {
                                xCheck.Clear();
                                yCheck.Clear();
                            }
                            xCheck.Add(x);
                            yCheck.Add(y);
                            tCheck.Add(t);
                            isChecking = 1;
                        }

                        if ((F(x, y) != F(x - kx[0], y - ky[0])) && (Math.Abs(F(x, y)) == 1))
                        {
                            if(Starts.Count<100 && counterBackStarts < 150)
                            Starts.Add(new point2start(x - kx[0], y - ky[0], mpen.Color, 0, t));
                        }
                    }



                    if (((Math.Abs(x - x0) + Math.Abs(y - y0)) * scale > 3))
                    {
                        if (isChecking == 1 || state != -1)
                        {
                            xCheck.Add(x);
                            yCheck.Add(y);
                            tCheck.Add(t);
                        }
                        else
                        {
                            gr.DrawLine(mpen, Wmid + Convert.ToSingle(x0 * scale), Hmid + Convert.ToSingle(-y0 * scale), Wmid + Convert.ToSingle(x * scale), Hmid + Convert.ToSingle(-y * scale));
                        }
                        x0 = x;
                        y0 = y;
                    }

                    px = x;
                    py = y;
                    pFsign = Fsign;
                }

            }
            picOut.Image = frame;

        }

        public void printImage(double dt)
        {
            if (stopWatchkImax.IsRunning)
                stopWatchkImax.Restart();
            else
                stopWatchkImax.Start();
            //Bitmap Axes = new Bitmap(picOut.Size.Width, picOut.Size.Height);
            //double x = x0, y = y0, px = x0, py = y0;
            x = x0;
            y = y0;
            px = x0;
            py = y0;
            frame = picOut.Image;
            gr = Graphics.FromImage(frame);
            //gr.DrawLine(mpen, Wmid + Convert.ToSingle(x0), Hmid+ Convert.ToSingle(y0), Wmid+ Convert.ToSingle(x), Hmid+ Convert.ToSingle(y));

            while (stopWatchkImax.ElapsedMilliseconds < 33)
            {
                ia++;
                //integrating with Runge-Kutti 4-th order
                kx[0] = dt * y;
                //ky[0] = dt * (g - a * F(x, y, px, py));
                ky[0] = dt * (g(x, y, t) - a * Fsign);
                kx[1] = dt * (y + ky[0] / 2);
                ky[1] = dt * (g(x + kx[0] / 2, y + ky[0] / 2, t + dt / 2) - a * F(x + kx[0] / 2, y + ky[0] / 2, px, py));
                kx[2] = dt * (y + ky[1] / 2);
                ky[2] = dt * (g(x + kx[1] / 2, y + ky[1] / 2, t + dt / 2) - a * F(x + kx[1] / 2, y + ky[1] / 2, px, py));
                kx[3] = dt * (y + ky[2]);


                t += dt;

                ky[3] = dt * (g(x + kx[2], y + ky[2], t) - a * F(x + kx[2], y + ky[2], px, py));

                x += (kx[0] + 2 * (kx[1] + kx[2]) + kx[3]) / 6;
                y += (ky[0] + 2 * (ky[1] + ky[2]) + ky[3]) / 6;

                // checking for out of printable range
                if ((rangeX < Math.Abs(x)) && (rangeY < Math.Abs(y)))
                    break;

                Fsign = Math.Sign(F(x, y, px, py));

                if (Fsign == 1)
                    tFplus++;
                else
                if (Fsign == -1)
                    tFminus++;

                if (Fsign != pFsign)
                {
                    if (Fsign == 1)
                        Fplus++;
                    else if (Fsign == -1)
                        Fminus++;
                }

                if (((Math.Abs(x - x0) + Math.Abs(y - y0)) * scale > 3))
                {
                    gr.DrawLine(mpen, Wmid + Convert.ToSingle(x0 * scale), Hmid + Convert.ToSingle(-y0 * scale), Wmid + Convert.ToSingle(x * scale), Hmid + Convert.ToSingle(-y * scale));
                    x0 = x;
                    y0 = y;
                }

                ySign = Math.Sign(y);

                if (ySign != pySign)
                {
                    if ((pySign < 0) || (ySign > 0))
                    {
                        //xMin = x;
                        xMin = px - py * (x - px) / (y - py);
                    }
                    else if ((pySign > 0) || (ySign < 0))
                    {
                        //xMax = x;
                        xMax = px - py * (x - px) / (y - py);
                        if ((Math.Abs(xMin - pxMin) + Math.Abs(xMax - pxMax) <= e * (Math.Abs(xMin) + Math.Abs(xMax))))
                        {
                            //iaSaved = ia;
                            iaSaved = ia - 1 + py / (py - y);
                            ia = 0;
                            sFplus = Fplus;
                            sFminus = Fminus;
                            Fplus = 0;
                            Fminus = 0;

                            stFminus = tFminus;
                            stFplus = tFplus;
                            tFminus = 0;
                            tFplus = 0;

                            paramChanged = true;
                        }
                        pxMax = xMax;
                        pxMin = xMin;
                    }
                }

                px = x;
                py = y;
                pySign = ySign;
                pFsign = Fsign;
            }
            x0 = x;
            y0 = y;
            textBoxX.Text = Convert.ToString(x0);
            textBoxY.Text = Convert.ToString(y0);
            if (AddEnabled)
                textBoxT.Text = Convert.ToString(t);
            if (paramChanged)
            {
                textBoxIa.Text = Convert.ToString(iaSaved * dt);
                labelPulsesOut.Text = String.Concat("+: ", Convert.ToString(sFplus), " -:", Convert.ToString(sFminus));
                labelPulsesTimes.Text = String.Concat("+t=", Convert.ToString(stFplus * dt), "\n-t=", Convert.ToString(stFminus * dt));
                if (AddEnabled)
                    labelPulsesS.Text = String.Concat("+S=", stFplus != 0 ? Convert.ToString(iaSaved / stFplus) : "∞", "\n-S=", stFminus != 0 ? Convert.ToString(iaSaved / stFminus) : "∞");
                paramChanged = false;
            }

            picOut.Image = frame;

            if ((rangeX < Math.Abs(x)) && (rangeY < Math.Abs(y)))
            {
                if (xStart.Count != 0)
                {
                    x0 = xStart[0];
                    y0 = yStart[0];
                    xStart.RemoveAt(0);
                    yStart.RemoveAt(0);
                }
                else
                {
                    stopSimulation("Out of range!");
                }

            }


        }

        bool CheckAll()
        {
            //if ((gK == 0) || (Math.Abs(gK) >= Math.Abs(gK * a)) || (a <= 0) || (alpha + alphaAdd < h) || (alpha + alphaAdd < hAdd) || (h < 0) || ((gArgK == 0) && AddEnabled) || (dt0 <= 0)) return false;
            if ((gK == 0) || (Math.Abs(gK) >= Math.Abs(gK * a)) || (a <= 0) || (alpha + alphaAdd < h) || (alpha + alphaAdd < hAdd) || (h < 0) || ((gArgK == 0) && AddEnabled) || (dt0 == 0)) return false;
            else
            {
                //textBoxX.Text = Convert.ToString(x0);
                //textBoxY.Text = Convert.ToString(y0);
                button1.Text = "Начать";
                if (!backIsWhite)
                {
                    writeBackground();
                    backIsWhite = true;
                }
                return true;
            }
        }

        void setAll(bool value)
        {

            textBoxX.Enabled = value;
            textBoxY.Enabled = value;
            textBoxA.Enabled = value;
            textBoxG.Enabled = value;
            textBoxAlpha.Enabled = value;
            textBoxH.Enabled = value;
            textBoxK.Enabled = value;
            //buttonClean.Enabled = value;
            buttonClean.Visible = value;
            textBoxAlphaAdd.Enabled = value;
            textBoxHAdd.Enabled = value;
            listBoxGArg.Enabled = value;
            listBoxGType.Enabled = value;
            textBoxGArgK.Enabled = value;
            checkBoxShowAdd.Enabled = value;
            textBoxT.Enabled = value;
            textBoxDT0.Enabled = value;

            if (!value)
            {
                if (AddEnabled)
                {
                    textBoxAlphaAdd.Text = Convert.ToString(alphaAdd);
                    textBoxHAdd.Text = Convert.ToString(hAdd);
                    textBoxGArgK.Text = Convert.ToString(gArgK);
                    textBoxT.Text = Convert.ToString(t);
                    textBoxDT0.Text = Convert.ToString(dt0);

                    textBoxAlphaAdd.BackColor = Color.White;
                    textBoxHAdd.BackColor = Color.White;
                    textBoxGArgK.BackColor = Color.White;
                    textBoxT.BackColor = Color.White;
                    textBoxDT0.BackColor = Color.White;
                }
                else
                {
                    alphaAdd = alpha;
                    hAdd = h;
                }

                textBoxA.Text = Convert.ToString(a);
                textBoxG.Text = Convert.ToString(gK);
                textBoxX.Text = Convert.ToString(x0);
                textBoxY.Text = Convert.ToString(y0);
                textBoxAlpha.Text = Convert.ToString(alpha);
                textBoxH.Text = Convert.ToString(h);
                textBoxK.Text = Convert.ToString(k);

                textBoxA.BackColor = Color.White;
                textBoxG.BackColor = Color.White;
                textBoxX.BackColor = Color.White;
                textBoxY.BackColor = Color.White;
                textBoxAlpha.BackColor = Color.White;
                textBoxH.BackColor = Color.White;
                textBoxK.BackColor = Color.White;
            }

        }

        void stopSimulation(string text = "")
        {
            timerPrint.Stop();
            butwork = false;
            button1.Text = "Продолжить";
            textBoxX.Text = Convert.ToString(x0);
            textBoxY.Text = Convert.ToString(y0);
            setAll(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backIsWhite = false;
            //printImage(0.001);
            if (butwork)
            {
                stopSimulation();
            }
            else
            {
                xMax = x0;
                pxMax = x0;
                xMin = x0;
                pxMin = x0;
                pySign = Math.Sign(y0);
                Fsign = Math.Sign(F(x0, y0, x0, y0));
                pFsign = Fsign;

                if (AddEnabled)
                {
                    if (listBoxGType.SelectedIndex == -1)
                        listBoxGType.SelectedIndex = 0;
                    if (listBoxGArg.SelectedIndex == -1)
                        listBoxGArg.SelectedIndex = 0;
                }

                butwork = true;
                button1.Text = "Остановить";
                setAll(false);
                timerPrint.Start();
            }

        }
    }
}