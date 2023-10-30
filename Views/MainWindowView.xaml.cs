using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;
using ViewModels;
using ViewModelsInterfaces;

namespace Views
{
    /// <summary>
    /// Interaktionslogik für MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            IMainWindowViewModel mainWindowViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<IMainWindowViewModel>();            
            // Setzen Sie den DataContext
            this.DataContext = mainWindowViewModel;
        }
        //method to close the application
        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
