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
using System.Timers;
using System.ComponentModel;
using System.Windows.Threading;

namespace Clock
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer(1);
        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            Dispatcher.Invoke(() =>
            {
                CC.SecondsAngle = ClockConfiguration.GetSecondsAngle();
                CC.MinutesAngle = ClockConfiguration.GetMinutesAngle();
                CC.HoursAngle = ClockConfiguration.GetHoursAngle();
                //double secondsAngle = (SecondsHand.RenderTransform as TransformGroup).Children.OfType<RotateTransform>().First().Angle;
            });
            timer.Start();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
