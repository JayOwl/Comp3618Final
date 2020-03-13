using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NumbersOfPi
{
    public partial class PiCalc : Form
    {
        class PIObject
        {
            public string calculatedValue {get;set;}
            public int num { get; set; }
            public int prog { get; set; }
        }

        PIObject pi;
        

        public PiCalc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.calcBtn.Text == "Calculate")
            {
                timer1.Start();
                //Add stopwatch for timer
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                // Just a simple object to hold some values to be accessed globally
                pi = new PIObject
                {
                    calculatedValue = "",
                    num = (int)_digits.Value,
                    prog = 0
                };
                backgroundWorker1.RunWorkerAsync(pi);
                progressBar1.Maximum = pi.num - 1;
                calcBtn.Text = "Cancel";

                stopWatch.Stop();       
                TimeSpan ts = stopWatch.Elapsed;
                txtBox_StopWatch.Text = ts.ToString() ;
                //calcBtn.Text = "Completed";
            }
            else
            {
                timer1.Stop();
                                
                backgroundWorker1.CancelAsync();
            
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Tick(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PIObject piObj = e.Argument as PIObject;
            BackgroundWorker bw = sender as BackgroundWorker;
            StringBuilder pi = new StringBuilder("3", piObj.num + 2);

            if (piObj.num > 0)
            {
                pi.Append(".");

                for (int i = 0; i < piObj.num; i += 9)
                {
                    if (!this.backgroundWorker1.CancellationPending)
                    {
                        int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
                        int digitCount = Math.Min(piObj.num - i, 9);
                        String ds = String.Format("{0:D9}", nineDigits);
                        pi.Append(ds.Substring(0, digitCount));
                        piObj.calculatedValue = pi.ToString();
                        piObj.prog = i + 1;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBoxPi.Text = pi.calculatedValue;
            progressBar1.Value = pi.prog;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.calcBtn.Text = "Complete.";

            if (e.Cancelled)
            {
                this.txtBoxPi.Text = pi.calculatedValue + " <<cancelled>>";
               // this.calcBtn.Text = "Canceled.";
            }
            //else
            //{
            //    this.calcBtn.Text = "Completed.";
            //}

            //    e.Result = pi.calculatedValue
        }

        private void PiCalc_Load(object sender, EventArgs e)
        {

        }
    }
}
