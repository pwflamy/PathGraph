using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chast1
{
    public partial class Form1 : Form
    {
        struct ver
        {
            public float x, y;
        }
        struct dug
        {
            public float x1, y1, x2, y2;
            public int dlina;
        }        
        ver[] vershinu = new ver[201];
        dug[] dugi = new dug[200];
        int[,] matrixSmej = new int[200, 200];
        int kolvo = 0;
        int kolvoDug = 0;
        public int DialogRes; 
        bool firstClick = true;
        int firstChecked = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
                for (int j = 0; j < 200; j++)
                    matrixSmej[i, j] = 0;
            for (int i = 0; i < spisok.Length; i++)
            {
                spisok[i] = new List<string>();
            }
         //   int[,] a = new int[5, 5]
         //   {
         //       {0,1,0,0,3  },
         //       {0,0,8,7,1  },
         //       {0,0,0,1,-5 },
         //       {0,0,2,0,0  },
         //       {0,0,0,4,0  },
         //   };
         //   for (int i = 0; i < 5; i++)
         //       for (int j = 0; j < 5; j++)
         //           matrixSmej[i, j] = a[i, j];
         //   kolvo = 5;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Graphics g = panel1.CreateGraphics();
            dialogDlina subForm = new dialogDlina(this);
            if (btnSetVersh.Checked)
            {
                bool prov = false;
                for (int i = 0; i < kolvo; i++)
                {
                    float a = Math.Abs(vershinu[i].x - (float)(e.X)) * Math.Abs(vershinu[i].x - (float)(e.X)) + Math.Abs(vershinu[i].y - (float)(e.Y)) * Math.Abs(vershinu[i].y - (float)(e.Y));
                    double dal = Math.Sqrt(a);
                    if (dal <= 31)
                        prov = true;
                }
                if (!prov)
                {
                    kolvo++;
                    vershinu[kolvo - 1].x = (float)e.X;
                    vershinu[kolvo - 1].y = (float)e.Y;
                    g.DrawEllipse(Pens.Black, new RectangleF((float)(e.X - 15), (float)(e.Y - 15), 30, 30));
                    g.DrawString("x" + (kolvo - 1).ToString(), drawFont, drawBrush, new PointF((float)(e.X - 9.5), (float)(e.Y - 7.5)));
                }
            }
            if (btnSetLink.Checked)
            {
                if (firstClick)
                {
                    for (int i = 0; i < kolvo; i++)
                    {
                        float a = Math.Abs(vershinu[i].x - (float)(e.X)) * Math.Abs(vershinu[i].x - (float)(e.X)) + Math.Abs(vershinu[i].y - (float)(e.Y)) * Math.Abs(vershinu[i].y - (float)(e.Y));
                        double dal = Math.Sqrt(a);
                        if (dal <= 15)
                        {
                            firstClick = false;
                            g.DrawEllipse(Pens.Red, new RectangleF(vershinu[i].x - 15, vershinu[i].y - 15, 30, 30));
                            firstChecked = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < kolvo; i++)
                    {
                        float a = Math.Abs(vershinu[i].x - (float)(e.X)) * Math.Abs(vershinu[i].x - (float)(e.X)) + Math.Abs(vershinu[i].y - (float)(e.Y)) * Math.Abs(vershinu[i].y - (float)(e.Y));
                        double dal = Math.Sqrt(a);
                        if (dal <= 15 & i != firstChecked)
                        {
                           subForm.ShowDialog();
                           if (subForm.DialogResult == DialogResult.OK)
                            {
                                firstClick = true;
                                g.DrawEllipse(Pens.Black, new RectangleF(vershinu[firstChecked].x - 15, vershinu[firstChecked].y - 15, 30, 30));
                                float x2 = vershinu[i].x, y2 = vershinu[i].y, x1 = vershinu[firstChecked].x, y1 = vershinu[firstChecked].y;
                                double rast = Math.Sqrt(((vershinu[i].x - vershinu[firstChecked].x) * (vershinu[i].x - vershinu[firstChecked].x)) + (vershinu[i].y - vershinu[firstChecked].y) * (vershinu[i].y - vershinu[firstChecked].y));
                                double cosTangle = Math.Abs(vershinu[i].x - vershinu[firstChecked].x) / rast;
                                if (vershinu[i].x > vershinu[firstChecked].x)
                                {
                                    x1 += (float)(cosTangle * 15);
                                    x2 -= (float)(cosTangle * 15);
                                }
                                else
                                {
                                    x1 -= (float)(cosTangle * 15);
                                    x2 += (float)(cosTangle * 15);
                                }
                                if (vershinu[i].y > vershinu[firstChecked].y)
                                {
                                    y1 += (float)(Math.Sqrt(1 - cosTangle * cosTangle) * 15);
                                    y2 -= (float)(Math.Sqrt(1 - cosTangle * cosTangle) * 15);
                                }
                                else
                                {
                                    y1 -= (float)(Math.Sqrt(1 - cosTangle * cosTangle) * 15);
                                    y2 += (float)(Math.Sqrt(1 - cosTangle * cosTangle) * 15);
                                }
                                g.DrawLine(new Pen(Color.Black), new PointF(x1, y1), new PointF(x2, y2));
                                kolvoDug++;
                                dugi[kolvoDug - 1].x1 = x1;
                                dugi[kolvoDug - 1].x2 = x2;
                                dugi[kolvoDug - 1].y1 = y1;
                                dugi[kolvoDug - 1].y2 = y2;
                                 dugi[kolvoDug - 1].dlina = DialogRes;
                                 matrixSmej[firstChecked, i] = DialogRes; 
                                // dugi[kolvoDug - 1].dlina = 1;
                                // matrixSmej[firstChecked, i] = 1; 
                                DrawArrow(x2, y2, x1, y1, DialogRes);
                                firstChecked = 0;
                                break;
                            }
                        }
                        else
                        {
                            firstClick = true;
                            g.DrawEllipse(Pens.Black, new RectangleF(vershinu[firstChecked].x - 15, vershinu[firstChecked].y - 15, 30, 30));
                        }
                    }
                }
            }
        }

        private void DrawArrow(float x2, float y2, float x1, float y1, int ves)
        {
            Graphics g = panel1.CreateGraphics();
            g.TranslateTransform(x2, y2);
            float angle;
            double rast = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            if (y1 > y2)
                if (x1 > x2)
                {
                    double cosAngle = Math.Abs(x2 - x1) / rast;
                    angle = (90 - (float)Math.Acos(cosAngle) * 180 / (float)Math.PI) * (-1);
                }
                else
                {
                    double cosAngle = Math.Abs(x2 - x1) / rast;
                    angle = 90 - (float)Math.Acos(cosAngle) * 180 / (float)Math.PI;
                }
            else
                if (x1 > x2)
                {
                    double cosAngle = Math.Abs(y2 - y1) / rast;
                    angle = ((90 - (float)Math.Acos(cosAngle) * 180 / (float)Math.PI) + 90) * (-1);
                }                 
                else
                {
                    double cosAngle = Math.Abs(y2 - y1) / rast;
                    angle = 90 + 90 - (float)Math.Acos(cosAngle) * 180 / (float)Math.PI;
                }
            g.RotateTransform(angle);
            g.FillPolygon(Brushes.Black, new Point[] { new Point(0, 0), new Point(4, 9), new Point(-4, 9) });
            if (angle > 0 & angle < 180)
            {
                g.RotateTransform(-90);
                g.DrawString(ves.ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF((float)(-rast / 2), 3));
            }
            else
            {
                g.RotateTransform(90);
                g.DrawString(ves.ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), new PointF((float)(rast / 2), 3));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSetLink.Checked)
                btnSetVersh.Checked = false;
        }

        private void btnSetVersh_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSetVersh.Checked)
                btnSetLink.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Form.DefaultBackColor);
            for (int i = 0; i <= kolvo; i++)
            {
                vershinu[i].x = 0;
                vershinu[i].y = 0;
            }
            kolvo = 0;
            for (int i = 0; i <= kolvoDug; i++)
            {
                dugi[i].dlina = 0;
                dugi[i].x1 = 0;
                dugi[i].x2= 0;
                dugi[i].y1 = 0;
                dugi[i].y2 = 0;
            }
            kolvoDug = 0;
            for (int i = 0; i < 200; i++)
                for (int j = 0; j < 200; j++)
                    matrixSmej[i, j] = 0;
        }

        private void FindAllPath_Click(object sender, EventArgs e)
        {
            if (firstClick)
                MessageBox.Show("Сначала выберите вершину!");
            else
            {
                for (int i = 0; i < kolvo; i++)
                {
                    graf[i] = 0;
                }
                for (int i = 0; i < kolvo; i++)
                {
                    if (i != firstChecked)
                    {
                        rez[1] = firstChecked;
                        graf[firstChecked] = 1;
                        wtf2(firstChecked, i, 2);
                        for (int j = 0; j < 10; j++)
                            rez[i] = 0;
                    }
                }
                label1.Text = "";
                for (int i = 0; i < spisok.Length; i++)
                {
                    string path = i.ToString() + ": ";
                    foreach (string p in spisok[i])
                        label1.Text = label1.Text + path + p + '\n';
                }               
            }
        }

        List<string>[] spisok = new List<string>[10];
        int[] rez = new int[10];
        int[] graf = new int[10];
        private void wtf2(int start, int finish, int p)
        {
            if (start == finish)
            {
                string path = "";
                for (int i = 1; i < p; i++)
                    path += rez[i];
                bool vsoj = false;
                for (int i = 0; i < spisok[rez[p - 1]].Count; i++)
                    if (spisok[rez[p - 1]][i] == path)
                        { vsoj = true; break; }
                if (!vsoj)
                    spisok[rez[p - 1]].Add(path);
            }
            else
            {
                for (int i = 1; i < kolvo; i++)
                {
                    if ((graf[i] == 0) && (matrixSmej[start, i] != 0))
                    {
                        rez[p] = i;
                        graf[i] = 1;
                        wtf2(i,finish,p+1);
                        graf[i] = 0;
                        rez[p] = 0;
                    }
                }
            }
        }
        private void Ford_belman(int start)
        {
            const int INF = 100000000;
            int[,] matrixVes = new int[200, 200];
            matrixVes = matrixSmej;
            for (int i = 0; i < 200; i++)
                for (int j = 0; j < 200; j++)
                    if (matrixVes[i, j] == 0)
                    {
                        matrixVes[i, j] = INF;
                    }
            int[] d = new int[kolvo];
            int[] temp = new int[kolvo];
            for (int i = 0; i < kolvo; i++)
            {
                if (i != start)
                    d[i] = INF;
                else
                    d[i] = 0;
            }
            int[] predok = new int[kolvo];
            predok[start] = INF;    
            for (int i = 0; i < kolvo - 1; i++)   // количество итераций k
            {
                for (int j = 0; j < kolvo; j++)  // обходим все d 
                {
                    if (j != start)
                    {
                        int min = d[0] + matrixVes[0, j]; // поиск минимального среди 
                        int vershina = 0;
                        for (int z = 0; z < kolvo - 1; z++)
                        {
                            if (min > d[z + 1] + matrixVes[z + 1, j])
                            {
                                min = d[z + 1] + matrixVes[z + 1, j];
                                vershina = z + 1;
                            }
                        }
                        temp[j] = min;
                        if (temp[j] < d[j])
                            predok[j] = vershina;
                    }
                    else
                    {
                        temp[j] = 0;
                    }
                }
                for (int k = 0; k < kolvo; k++)
                {
                    d[k] = temp[k];
                }
            }
            label1.Text = "";
            for (int i = 0; i< kolvo; i++)
            {
                if (i != start)
                {
                    string s = "";
                    int j = i;
                    while (predok[j] != INF)
                    {
                        s += j.ToString();
                        j = predok[j];
                    }
                    s += start.ToString();
                    char[] promej = s.ToArray<char>();
                    Array.Reverse(promej);
                    s = String.Concat<char>(promej);
                    label1.Text = label1.Text + "от " + start.ToString() + " до " + i.ToString() + " кратчайший путь - " + s + " растояние = " + d[i].ToString() + '\n';
                }
            }
        }

        private void FordBelman_Click(object sender, EventArgs e)
        {
            if (firstClick)
                MessageBox.Show("Сначала выберите вершину!");
            else
                Ford_belman(firstChecked);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
