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

namespace Views.StempelElemente
{
    /// <summary>
    /// Interaktionslogik für StempelListItem.xaml
    /// </summary>
    public partial class StempelListItem : UserControl
    {
        public StempelListItem()
        {
            InitializeComponent();
            IStempelListItemViewModel stempelListItemViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<IStempelListItemViewModel>();

            // Setzen Sie den DataContext
            this.DataContext = stempelListItemViewModel;
        }
    }
}
