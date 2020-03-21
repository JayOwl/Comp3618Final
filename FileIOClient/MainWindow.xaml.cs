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

            //watcher.Path = "C:\\finaltest";
            string workingDirectory = Environment.CurrentDirectory;

            watcher.Path = Directory.GetParent(workingDirectory).Parent.FullName + "\\finaltest";

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

        private int GetFileLength(string path) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string text = File.ReadAllText(path);
            sw.Stop();
            Debug.WriteLine(text.Length + " " + sw.ElapsedMilliseconds);
            return text.Length;
        }

        private void TaskButton_Click(object sender, RoutedEventArgs e) {
            Thread test = new Thread(GetFileLengthTask);

            test.Start();
        }

        private void GetFileLengthTask() {
            Task.Run(async () => {
                Stopwatch sw = new Stopwatch();
                List<Thread> threads = new List<Thread>();
                sw.Start();

                foreach (string path in paths) {
                    Thread thread = new Thread(() => GetFileLength(path));
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

        private void ParaForButton_Click(object sender, RoutedEventArgs e) {
            Thread thread = new Thread(() => {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Parallel.For(0, paths.Count, i => {
                    GetFileLength(paths[i]);
                });
                sw.Stop();
                lbPerformance.Dispatcher.InvokeAsync(() => lbPerformance.Content = sw.ElapsedMilliseconds + "ms");
            });
            thread.Start();
        }
    }
}
