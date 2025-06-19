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
using WaferMapv2.Model;

namespace WaferMapv2.View
{
    /// <summary>
    /// WaferMapView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WaferMapView : UserControl
    {
        public WaferMapView()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rect && rect.DataContext is Die die)
            {
                MessageBox.Show($"Die clicked:\nX: {die.X}\nY: {die.Y}\nStatus: {die.Status}", "Die Info");
            }
        }
    }
}
