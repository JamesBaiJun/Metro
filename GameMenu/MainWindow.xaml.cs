using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using System.Xml;

namespace GameMenu
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Games> GamesList { get; set; }
        public Games SelectGame { get; set; }
        
        public MainWindow()
        {
            GamesList = new ObservableCollection<Games>();
            InitializeComponent();
            XmlDocument xml = new XmlDocument();
            xml.Load(Environment.CurrentDirectory + "\\Config.xml");
            foreach (XmlNode item in xml.LastChild.ChildNodes)
            {
                GamesList.Add(
                   new Games() { Name = item.ChildNodes[0].InnerText, ImagePath = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Image\\"+ item.ChildNodes[1].InnerText, UriKind.Absolute)) });
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var s = SelectGame;
        }
    }
}
