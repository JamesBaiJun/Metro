using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using HandyControl.Controls;
using Window = System.Windows.Window;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : Window
    {
        public ObservableCollectionCore<Process> MyProperty { get; set; }
        public Process SelectedProcess { get; set; }
        public DXWindow1()
        {
            InitializeComponent();
            MyProperty = new ObservableCollectionCore<Process>();
            foreach (var item in (Process.GetProcesses().OrderBy(x=>x.MainWindowTitle).ToList()))
            {
                MyProperty.Add(item);
            }
            MyProperty.OrderBy(x => x.MainWindowTitle);
            DataContext = this;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProcess!=null)
            SelectedProcess.Kill();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_Ani(object sender, RoutedEventArgs e)
        {
            var MyDoubleAni = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                Duration = new Duration(TimeSpan.Parse("00:00:04"))
            };
            MyDoubleAni.EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut };
            ButtonRotate1.BeginAnimation(RotateTransform.AngleProperty, MyDoubleAni);
        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                MyProperty.Clear();
                foreach (var item in (Process.GetProcesses().OrderBy(x => x.MainWindowTitle).ToList()))
                {
                    MyProperty.Add(item);
                }
            }));
        }
    }
}
