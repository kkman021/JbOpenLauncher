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
using me.joshbennett;

namespace TestGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenLauncher launcherDevice;

        public MainWindow()
        {
            InitializeComponent();
            launcherDevice = new OpenLauncher();
        }

        private void btnCommand_MouseUp(object sender, MouseButtonEventArgs e)
        {
            launcherDevice.commandStop();
        }

        private void btnCommandUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            launcherDevice.commandUp();
        }      
        
        private void btnCommandDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            launcherDevice.commandDown();
        }

        private void btnCommandLeft_MouseDown(object sender, MouseButtonEventArgs e)
        {
            launcherDevice.commandLeft();
        }

        private void btnCommandRight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            launcherDevice.commandRight();
        }

        private void btnCommandLedOff_Click(object sender, RoutedEventArgs e)
        {
            launcherDevice.commandLedOn();
        }

        private void btnCommandLedOn_Click(object sender, RoutedEventArgs e)
        {
            launcherDevice.commandLedOff();
        }

        private void btnCommandFire_Click(object sender, RoutedEventArgs e)
        {
            launcherDevice.commandFire();
        }


        
    }
}
