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
using NumbersOfPi;
using System.Diagnostics;
using System.Threading;

namespace PiClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly BackgroundWorker bgWorker = new BackgroundWorker();
        public MainWindow() {
            InitializeComponent();
            Loaded += piClient_loaded;
        }

        private void piClient_loaded(object sender, RoutedEventArgs e) {
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            
        }

        private void calcPi(int digits) {
            //StringBuilder pi = new StringBuilder("3", digits + 2);
            if (digits > 0) {
                //pi.Append(".");
                for (int i = 0; i < digits; i += 9) {

                    //int nineDigits = 
                    NineDigitsOfPi.StartingAt(i + 1);
                    //int digitCount = 
                    Math.Min(digits - i, 9);
                    //string ds = string.Format("{0:D9}", nineDigits);
                    //pi.Append(ds.Substring(0, digitCount));

                }
            }
        }

        #region BackgroundWorker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            int digits = (int)e.Argument;
            calcPi(digits);

            stopwatch.Stop();
            e.Result = stopwatch.ElapsedMilliseconds;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            lbPerformance.Content = "Performance: " + e.Result + "ms";
        }

        private void btnBgWorker_Click(object sender, RoutedEventArgs e) {
            if (!bgWorker.IsBusy) {
                bgWorker.RunWorkerAsync(int.Parse(txDigits.Text));
            }
        }
        #endregion

        #region Task
        private void btnTask_Click(object sender, RoutedEventArgs e) {
            int digits = int.Parse(txDigits.Text);

            Task.Run(async () => {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                calcPi(digits);
                stopwatch.Stop();
                await lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = stopwatch.ElapsedMilliseconds);
            });

        }
        #endregion

        private void test(object sender, RoutedEventArgs e) {
            Thread test = new Thread(paraTest);
            test.Start(int.Parse(txDigits.Text));
        }

        private void paraTest(object arg) {

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Parallel.For(0, 1, i => {
                calcPi((int)arg);
                sw.Stop();
                lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = sw.ElapsedMilliseconds);
                // Should the sw.Stop() and performance data not occur outside the for loop? The code inside may be run in parallel, and we only want it to stop once.
                // I haven't tested/debugged it though
            });
        }

    }
}
