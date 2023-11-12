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
        private void btn_headline1_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(_richTextBox.Selection.Start, _richTextBox.Selection.End);
            if (range.GetPropertyValue(TextElement.FontWeightProperty).Equals(FontWeights.Bold) && range.GetPropertyValue(TextElement.FontSizeProperty).Equals(16.0))
            {
                range.ApplyPropertyValue(TextElement.FontSizeProperty, 12.0);
                range.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);                                
            }
            else
            {
                range.ApplyPropertyValue(TextElement.FontSizeProperty, 16.0);
                range.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
        }
        private void btn_headline2_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(_richTextBox.Selection.Start, _richTextBox.Selection.End);
            if (range.GetPropertyValue(TextElement.FontStyleProperty).Equals(FontStyles.Italic) && range.GetPropertyValue(TextElement.FontSizeProperty).Equals(14.0))
            {
                range.ApplyPropertyValue(TextElement.FontSizeProperty, 12.0);
                range.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
            else
            {
                range.ApplyPropertyValue(TextElement.FontSizeProperty, 14.0);
                range.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
        }
    }
}
