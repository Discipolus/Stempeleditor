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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModelsInterfaces;

namespace Views
{
    /// <summary>
    /// Interaktionslogik für StempelEditierenView.xaml
    /// </summary>
    public partial class StempelEditierenView : UserControl
    {
        public StempelEditierenView()
        {
            InitializeComponent();
            IStempelEditierenViewModel stempelEditierenViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<IStempelEditierenViewModel>();

            // Setzen Sie den DataContext
            this.DataContext = stempelEditierenViewModel;
        }
    }
}
