using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace PiClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly BackgroundWorker bgWorker = new BackgroundWorker();
        //save these to database later
        public string ElapsedTime { get; set; }
        public string MethodName { get; set; }

        // Calculation in-progress flag
        private bool IsCalculating { get; set; }

        // Ctor
        public MainWindow() {
            InitializeComponent();
            Loaded += piClient_loaded;
            IsCalculating = false;
        }

        // Application loaded event handler
        private void piClient_loaded(object sender, RoutedEventArgs e) {
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
        }

        // Calculate digts of pi using the provided algorithm
        private void calcPi(int digits) {
            StringBuilder pi = new StringBuilder("3", digits + 2);
            if (digits > 0) {
                pi.Append(".");
                for (int i = 0; i < digits; i += 9) {

                    int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
                    int digitCount = Math.Min(digits - i, 9);
                    string ds = string.Format("{0:D9}", nineDigits);
                    pi.Append(ds.Substring(0, digitCount));
                }
            }
        }

        #region BackgroundWorker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int digitsOfPi = (int)e.Argument;
            calcPi(digitsOfPi);

            stopwatch.Stop();
            e.Result = stopwatch.ElapsedMilliseconds;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            lbPerformance.Content = "Performance: " + e.Result + "ms";
            ElapsedTime = e.Result + "ms";
            MethodName = "cpu.BackgroundWorker";
        }

        // Run Async background worker
        private void btnBgWorker_Click(object sender, RoutedEventArgs e) {
            // Validate data first
            int digitsOfPi;
            if (int.TryParse(txDigits.Text, out digitsOfPi)) {
                if (!bgWorker.IsBusy) {
                    bgWorker.RunWorkerAsync(digitsOfPi);
                }
            }
        }
        #endregion

        #region Task
        private void btnTask_Click(object sender, RoutedEventArgs e) {
            int digitsOfPi;

            // Validate input before anything else
            if (int.TryParse(txDigits.Text, out digitsOfPi)) {


                Task.Run(async () => {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    calcPi(digitsOfPi);
                    stopwatch.Stop();
                    ElapsedTime = "Performance: " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
                    await lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = ElapsedTime);
                    MethodName = "cpu.Task";
                });
            }
        }
        #endregion

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine(MethodName + "," + ElapsedTime);
            // Save to Database from here
        }

        private void btnThreadPool_Click(object sender, RoutedEventArgs e) {
            int digitsOfPi;
            int numberOfThreads = 1;        // This is a single-threaded non-parallelizable algorithm
            // Validate input before anything else
            if (int.TryParse(txDigits.Text, out digitsOfPi)) {
                int newint = digitsOfPi;
                Thread thread = new Thread(() => {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    AutoResetEvent done = new AutoResetEvent(false);

                    ThreadPool.QueueUserWorkItem(state => {
                        calcPi(digitsOfPi);
                        if (0 == Interlocked.Decrement(ref numberOfThreads)) {
                            done.Set();
                        }
                    });
                    done.WaitOne();

                    stopwatch.Stop();
                    ElapsedTime = "Performance: " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
                    lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = ElapsedTime);
                    MethodName = "cpu.ThreadPool";
                });
                thread.Start();
            }
        }

        private void btnParallelFor_Click(object sender, RoutedEventArgs e) {

            int digitsOfPi;
            int numberOfThreads = 1;         // This is a single-threaded non-parallelizable algorithm

            // Validate input before anything else
            if (int.TryParse(txDigits.Text, out digitsOfPi)) {
                Thread thread = new Thread(() => { //to prevent blocking ui thread
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Parallel.For(0, numberOfThreads, i => {
                        calcPi(digitsOfPi);
                    });

                    stopwatch.Stop();
                    ElapsedTime = "Performance: " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
                    lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = ElapsedTime);
                    MethodName = "cpu.ParallelFor";
                });
                thread.Start();
            }


        }
    }
}
