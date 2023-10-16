using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModels;
using ViewModelsInterfaces;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<MainWindowView>();
            services.AddScoped<StempelEditierenView>();
            services.AddScoped<UebersichtView>();
            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IUebersichtViewModel, UebersichtViewModel>();
            services.AddScoped<IStempelEditierenViewModel, StempelEditierenViewModel>();

            ServiceProvider provider = services.BuildServiceProvider();
            MainWindowView mw = provider.GetService<MainWindowView>()!;
            mw.Show();
        }
    }
}
