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
using IXMLConverter;
using XMLConverter;
using IStorage;
using SQLDatabaseConnection;

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
            services.AddSingleton<IUebersichtViewModel, UebersichtViewModel>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddTransient<IStempelListItemViewModel, StempelListItemViewModel>();
            services.AddSingleton<IXMLConverter.IXMLConverter, XMLConverter.XMLConverter>();
            services.AddSingleton<IStorageService, DummyDatabase>();
            return services.BuildServiceProvider();
        }
    }
}