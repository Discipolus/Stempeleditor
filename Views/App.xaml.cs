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
        }
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registrieren Sie Ihre Dienste und ViewModels. Transient wird erstellt, wenn es angefordert wird. Scoped wird einmal pro Anforderung erstellt. Singleton wird einmal erstellt.
            services.AddSingleton<IStempelEditierenViewModel, StempelEditierenViewModel>();
            services.AddTransient<IUebersichtViewModel, UebersichtViewModel>();
            services.AddTransient<IStempelViewModel, StempelViewModel>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
