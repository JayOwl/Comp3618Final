using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FileIOClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private FileSystemWatcher watcher = new FileSystemWatcher();
        private List<String> paths = new List<string>();
        
        public MainWindow() {
            InitializeComponent();
            Loaded += OnLoad;
        }

        private void OnLoad(object sender, RoutedEventArgs e) {
            ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount * 2);
            Thread.CurrentThread.Name = "UI Thread";

            watcher.Path = "C:\\finaltest";
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
            watcher.Changed += FswOnChanged;
            watcher.Created += FswOnChanged;
            watcher.EnableRaisingEvents = true;
        }

        private void FswOnChanged(object source, FileSystemEventArgs e) {
            //filesystemwatcher events can fire multiple times for the same file, so this checks for dupes before adding
            if (!paths.Contains(e.FullPath)) { 
                paths.Add(e.FullPath);
                System.Diagnostics.Debug.Print(e.FullPath + " added");
            }
        }



        private void test2() {
            Task.Run(async () => {
                Stopwatch sw = new Stopwatch();
                List<Thread> threads = new List<Thread>();
                sw.Start();


                foreach (string path in paths) {
                    Thread thread = new Thread(() => test3(path));
                    threads.Add(thread);
                    thread.Start();
                }

                foreach (var thread in threads) {
                    thread.Join();
                }
                sw.Stop();
                await lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = sw.ElapsedMilliseconds + "ms");
            });


        }

        private int test3(string path) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string text = File.ReadAllText(path);
            sw.Stop();
            Debug.WriteLine(text.Length + " " + sw.ElapsedMilliseconds);
            return text.Length;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Thread test = new Thread(test2);

            test.Start();
        }
    }
}
