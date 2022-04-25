using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicBands.Core;
using MusicBands.Core.Abstractions;
using MusicBands.Core.Data;
using MusicBands.Core.UsableStrings;
using MusicBands.DAL;
using MusicBands.DAL.Repositories;
using MusicBands.Services;
using MusicBands.Services.Transfer;
using System;
using System.IO;
using System.Reflection;

namespace MusicBrands
{
    class Program
    {
        public static IConfigurationRoot iconfiguration;
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            string tableName=string.Empty;
            string quantity=string.Empty;
            string pages=string.Empty;
            string procedureName=string.Empty;

            GetAppSettingsFile();

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Console.Write(Messages.Enter);
            tableName = Console.ReadLine();

            MakingImport.ImportingJson(tableName, iconfiguration, procedureName);

            WorkingWithReports.ReportsMaking(iconfiguration);

            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ExportEntityToJsonFile>().ExportJson(tableName,pages,
                quantity, iconfiguration);
            DisposeServices();
            //ExportEntityToJsonFile.ExportJson(tableName, pages, quantity, iconfiguration);
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            iconfiguration = builder.Build();
        }

        public static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IRepositoryArea, DataRepositoryArea>();
            services.AddScoped<IRepositoryArtist, DataRepositoryArtist>();
            services.AddScoped<IRepositoryArtistCredit, DataRepositoryArtistCredit>();
            services.AddScoped<IRepositoryArtistCreditName, DataRepositoryArtistCreditName>();
            services.AddScoped<IRepositoryLabel, DataRepositoryLabel>();
            services.AddScoped<IRepositoryPlace, DataRepositoryPlace>();
            services.AddScoped<IRepositoryRecording, DataRepositoryRecording>();
            services.AddSingleton<IConfigurationRoot>(iconfiguration);
            services.AddTransient<DataFactory>();
            services.AddTransient<ExportGeneric>();
            services.AddTransient<ExportEntityToJsonFile>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        public static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
