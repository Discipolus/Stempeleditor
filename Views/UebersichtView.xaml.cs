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
    /// Interaktionslogik für UebersichtView.xaml
    /// </summary>
    public partial class UebersichtView : UserControl
    {
        public UebersichtView()
        {
            InitializeComponent();
            IUebersichtViewModel uebersichtViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<IUebersichtViewModel>();

            // Setzen Sie den DataContext
            this.DataContext = uebersichtViewModel;
        }
    }
}
