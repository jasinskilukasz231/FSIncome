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
using FSIncome.Core;

namespace FSIncome.Windows
{
    public partial class MainWindow : Window
    {
        //objects
        SystemClass system { get; set; } = new SystemClass();

        public MainWindow()
        {
            system.InitComponents();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }

}
