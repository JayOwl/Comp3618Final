using System;
using System.Collections.Generic;
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
                //System.Diagnostics.Debug.Print(e.FullPath + " added");
            }
        }

    }
}
