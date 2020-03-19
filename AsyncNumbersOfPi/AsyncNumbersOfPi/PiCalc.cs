using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace AsyncNumbersOfPi
{
    public partial class PiCalc : Form
    {
        private static bool IsCalculating { get; set; }
        private Stopwatch StopWatch { get; set; }

        // Ctor
        public PiCalc()
        {
            InitializeComponent();
            IsCalculating = false;
            _digits.Value = 1; //initial value
            InstantiateWorkerThread();
            StopWatch = new Stopwatch();
        }

        // Calculate/cancel button
        private void _calcButton_Click(object sender, EventArgs e)
        {
            if (IsCalculating)
            {
                IsCalculating = false;                
                WorkerThread.CancelAsync();
                StopWatch.Stop();                
                TimeInfo.Text = StopWatch.ElapsedMilliseconds.ToString() + " ms before operation cancelled";
                StopWatch.Reset();
            }
            else
            {
                IsCalculating = true;
                _calcButton.Text = "Cancel (Async)";
                TimeInfo.Clear();
                StopWatch.Start();
                WorkerThread.RunWorkerAsync();
            }
        }

        // Instantiate worker and set worker behaviour
        private void InstantiateWorkerThread()
        {
            WorkerThread = new BackgroundWorker();
            WorkerThread.ProgressChanged += WorkerThread_ProgressChanged;
            WorkerThread.DoWork += WorkerThread_DoWork;
            WorkerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
            WorkerThread.WorkerReportsProgress = true;
            WorkerThread.WorkerSupportsCancellation = true;          
        }

        // Main do work method
        private void WorkerThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int digitsOfPi = (int)_digits.Value;
            StringBuilder pi = new StringBuilder("3", digitsOfPi + 2);
            if (digitsOfPi > 0)
            {
                pi.Append(".");
                for (int i = 0; i < digitsOfPi && !WorkerThread.CancellationPending; i += 9)
                {
                    int nineDigits = PiCalculator.StartingAt(i + 1);
                    int digitCount = Math.Min(digitsOfPi - i, 9);
                    string ds = string.Format("{0:D9}", nineDigits);
                    pi.Append(ds.Substring(0, digitCount));

                    object piSoFar = pi.ToString();
                    WorkerThread.ReportProgress(((i+1) * 100/ digitsOfPi), piSoFar);
                }                
                WorkerThread.ReportProgress(100);
            }
        }

        // If worker is stopped
        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsCalculating = false;
            _calcButton.Text = "Calculate (Async)";
            StopWatch.Stop();
            TimeInfo.Text = StopWatch.ElapsedMilliseconds.ToString() + " ms elapsed. Operation complete.";
            StopWatch.Reset();
        }

        // Update the progress bar and calcualted value so far
        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _piProgress.Value = e.ProgressPercentage;
            if (null != e.UserState)
            {
                _pi.Text = e.UserState.ToString();
            }
        }
    }
}
