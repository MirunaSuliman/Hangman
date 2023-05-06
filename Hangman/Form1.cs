namespace Hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int nr = 0;
        public static string solutie()
        {
            
            FileStream fs = null; StreamReader sr = null;
            fs = new FileStream("cuvinte.txt", FileMode.Open);
            sr = new StreamReader(fs);

            List<string> cuvinte = new List<string>();

            for (; ; )
            {
                string linie = sr.ReadLine();
                if (linie == null) break;
                cuvinte.Add(linie);
            }

            sr.Close();
            fs.Close();

            int index = new Random().Next(cuvinte.Count);
           
           return cuvinte[index];
        }

        public void drawUnderlines(int n)
        {
            Graphics g = p.CreateGraphics();
            Point a = new Point(305, 210);
            Point b = new Point(325,210);
            
            while (n!=0)
            {
                g.DrawLine(new Pen(Color.Black, 5), a, b);
                a.Offset(25, 0);
                b.X = a.X + 20;
                n--;

            }

        }

        string solutia=solutie();

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = p.CreateGraphics();
            Pen Br = new Pen(Color.Brown, 3);

            drawUnderlines(solutia.Length);

            Point[] points = new Point[] {
                new Point(125,100),
                new Point(125,50),
                new Point(5,50),
                new Point(5,350)};
            g.DrawLines(Br, points);
            g.DrawLine(Br, new Point(0, 350), new Point(20, 350));

        }

        int l = 0, k = 0;
        public void sol_KeyDown(object sender, KeyEventArgs e)
        {
            Pen B = new Pen(Color.Black, 3);
          
            if (e.KeyCode == Keys.Enter)
            {

                Font f = new Font("Times New Roman", 20);
                Graphics g = p.CreateGraphics();

                int ok = 0;
                int nr_incercari = nr;
                string litera = sol.Text;
                sol.Clear();

                Point a = new Point(300, 174);

                for (int i = 0; i < solutia.Length; i++)
                {
                    if (litera.CompareTo(Convert.ToString(solutia[i])) == 0 && ok == 0) 
                    {
                        g.DrawString(litera, f, Brushes.Blue, a);
                        l++;
                        ok = 1;
                        for (int j = i + 1; j < solutia.Length; j++)
                        {
                            a.Offset(25, 0);
                            if (litera.CompareTo(Convert.ToString(solutia[j])) == 0)
                            {
                                g.DrawString(litera, f, Brushes.Blue, a);
                                l++;
                            }
                        }
                    }
                    else
                    {
                        a.Offset(25, 0);
                        g.DrawString(" ", f, Brushes.Blue, a);

                    }
                }

                if (ok == 0)
                {
                    k++;
                    if (k == 1) g.DrawEllipse(B, 100, 100, 50, 50);
                    if (k == 2) g.DrawLine(B, new Point(125, 150), new Point(125, 175));
                    if (k == 3) g.DrawEllipse(B, 100, 175, 50, 100);
                    if (k == 4) g.DrawLine(B, new Point(150, 200), new Point(200, 180));
                    if (k == 5) g.DrawLine(B, new Point(100, 200), new Point(50, 180));
                    if (k == 6) g.DrawLine(B, new Point(110, 275), new Point(50, 300));
                    if (k == 7) g.DrawLine(B, new Point(140, 275), new Point(200, 300));
                }

                DialogResult r = 0;

                if (k == 7)
                    r= MessageBox.Show("Ai epuizat toate incercarile! Solutia era: "+solutia, ":(", MessageBoxButtons.OK);
            
                if (l == solutia.Length)
                   r = MessageBox.Show("Felicitari! Ai castigat!", ":)"); 
            
                if (r == DialogResult.OK)
                    Application.Exit();

            }           

        }

    }
}

       



      
        

