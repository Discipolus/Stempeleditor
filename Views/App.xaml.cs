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
        public IServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceProvider = ConfigureServices()!;
            //ServiceCollection services = new ServiceCollection();
            //services.AddScoped<MainWindowView>();
            //services.AddScoped<StempelEditierenView>();
            //services.AddScoped<UebersichtView>();
            //services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            //services.AddScoped<IUebersichtViewModel, UebersichtViewModel>();
            //services.AddScoped<IStempelEditierenViewModel, StempelEditierenViewModel>();

            //ServiceProvider provider = services.BuildServiceProvider();
            //MainWindowView mw = provider.GetService<MainWindowView>()!;
            //mw.Show();
        }
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registrieren Sie Ihre Dienste und ViewModels
            services.AddTransient<IStempelEditierenViewModel, StempelEditierenViewModel>();
            services.AddTransient<IUebersichtViewModel, UebersichtViewModel>();
            services.AddTransient<IStempelViewModel, StempelViewModel>();
            services.AddTransient<MainWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
