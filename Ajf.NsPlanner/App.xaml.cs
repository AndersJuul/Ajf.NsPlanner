using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using System.Windows;
using Ajf.NsPlanner.Application;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.CommandHandlers;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Application.Dtos;
using Ajf.NsPlanner.Application.QueryHandlers;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.Infrastructure.Data.Data;
using Ajf.NsPlanner.Infrastructure.Data.DomainEvents;
using Ajf.NsPlanner.Infrastructure.Data.QueryHandlers;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands;
using Ajf.NsPlanner.UI.Services;
using Ajf.NsPlanner.UI.ViewModels;
using Ajf.NsPlanner.UI.Views;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DeletePeriodCommand = Ajf.NsPlanner.UI.Commands.DeletePeriodCommand;

namespace Ajf.NsPlanner.UI
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            Configuration = configurationBuilder.Build();


            // Create a service collection and configure our dependencies
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build the our IServiceProvider and set our static reference to it
            ServiceProvider = serviceCollection.BuildServiceProvider();

            using (var serviceScope = ServiceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context1 = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context1.Database.Migrate();
            }

            var mainWindowViewModel = ServiceProvider.GetRequiredService<IMainWindowViewModel>();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = mainWindowViewModel;

            var editDatesWindow = ServiceProvider.GetRequiredService<EditDatesWindow>();
            editDatesWindow.DataContext = ServiceProvider.GetRequiredService<IEditDatesViewModel>();
            
            var simpleStatsWindow = ServiceProvider.GetRequiredService<StatsAcceptedRejectedWindow>();
            simpleStatsWindow.DataContext = ServiceProvider.GetRequiredService<IStatsAcceptedRejectedViewModel>();

            var statsEmailAddressesWindow = ServiceProvider.GetRequiredService<StatsEmailAddressesWindow>();
            statsEmailAddressesWindow.DataContext = ServiceProvider.GetRequiredService<IStatsEmailAddressesViewModel>();

            var statsSchoolWindow = ServiceProvider.GetRequiredService<StatsSchoolWindow>();
            statsSchoolWindow.DataContext = ServiceProvider.GetRequiredService<IStatsSchoolsViewModel>();

            var editCounselorsWindow = ServiceProvider.GetRequiredService<EditCounselorsWindow>();
            editCounselorsWindow.DataContext = ServiceProvider.GetRequiredService<IEditCounselorsViewModel>();

            mainWindow.ShowDialog();

            Current.Shutdown();
            Environment.Exit(0);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            AddDatabaseConnection(services);
            AddViewModels(services);
            AddUiCommands(services);
            AddAutoMapping(services);

            AddDomainEventHandlers(services);

            AddApplicationCommandHandlers(services);
            AddApplicationQueryHandlers(services);

            services.AddSingleton<IRawRequestRepository, RawRequestRepository>();
            services.AddSingleton<IDispatcher, Dispatcher>();

            AddWindows(services);
        }

        private static void AddAutoMapping(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(Assembly.GetExecutingAssembly());
                    cfg.CreateMap<Period, PeriodViewModel>();
                    cfg.CreateMap<RequestDto, EventRequest>();
                    cfg.CreateMap<DateRange, DateRangeViewModel>();
                }
            );

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddWindows(IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(EditDatesWindow));
            services.AddTransient(typeof(StatsAcceptedRejectedWindow));
            services.AddTransient(typeof(StatsEmailAddressesWindow));
            services.AddTransient(typeof(StatsSchoolWindow));
            services.AddTransient(typeof(EditCounselorsWindow));
        }

        private static void AddApplicationQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<FindPeriodsQuery, Period[]>, FindUsersBySearchTextQueryHandler>();
            services
                .AddScoped<IQueryHandler<FindAssignmentsByTargetQuery, Assignment[]>, FindAssignmentsByPeriodQueryHandler>();
            services.AddScoped<IQueryHandler<ListAvailableDatesQuery, AvailableDate[]>, ListAvailableDatesQueryHandler>();
            services.AddScoped<IQueryHandler<AcceptedRejectedQuery, SimpleStatTable>, AcceptedRejectedQueryHandler>();
            services.AddScoped<IQueryHandler<EmailAddressesQuery, SimpleStatTable>, EmailAddressesQueryHandler>();
            services.AddScoped<IQueryHandler<SchoolQuery, SimpleStatTable>, SchoolQueryHandler>();
        }

        private static void AddApplicationCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddPeriodCommand>, AddPeriodCommandHandler>();
            services
                .AddScoped<ICommandHandler<Ajf.NsPlanner.Application.Commands.DeletePeriodCommand>,
                    DeletePeriodCommandHandler>();
            services.AddScoped<ICommandHandler<UpdatePeriodCommand>, UpdatePeriodCommandHandler>();
            services.AddScoped<ICommandHandler<ImportRequestsCommand>, ImportRequestsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateAssignmentCommand>, UpdateAssignmentCommandHandler>();
            services.AddScoped<ICommandHandler<ToggleAvailableDateXCommand>, ToggleAvailableDateXCommandHandler>();
            services.AddScoped<ICommandHandler<AddAvailableDatesCommand>, AddAvailableDatesCommandHandler>();
            services.AddScoped<ICommandHandler<SetMarkerOnAssignmentCommand>, SetMarkerOnAssignmentCommandHandler>();
        }

        private static void AddUiCommands(IServiceCollection services)
        {
            services.AddScoped<INewPeriodCommand, NewPeriodCommand>();
            services.AddScoped<IDeletePeriodCommand, DeletePeriodCommand>();
            services.AddScoped<IImportLatestRawCommand, ImportLatestRawCommand>();
            services.AddScoped<IStartAssignmentCounselorCommand, StartAssignmentCounselorCommand>();
            services.AddScoped<IToggleAvailableDateCommand, ToggleAvailableDateCommand>();
            services.AddScoped<ISetMarkerCommand, SetMarkerCommand>();
        }

        private static void AddDomainEventHandlers(IServiceCollection services)
        {
            services.AddSingleton<IHandle<PeriodCreatedEvent>>(c => c.GetService<IPeriodSelectionViewModel>());
            services.AddSingleton<IHandle<PeriodDeletedEvent>>(c => c.GetService<IPeriodSelectionViewModel>());
            services.AddSingleton<IHandle<PeriodUpdatedEvent>>(c => c.GetService<IPeriodSelectionViewModel>());
            services.AddSingleton<IHandle<AssignmentUpdatedEvent>>(c => c.GetService<IAssignmentsViewModel>());
            services.AddSingleton<IHandle<AssignmentUpdatedEvent>>(c => c.GetService<IStatsAcceptedRejectedViewModel>());
            services.AddSingleton<IHandle<AssignmentUpdatedEvent>>(c => c.GetService<IStatsSchoolsViewModel>());
            services.AddSingleton<IHandle<AvailableDateUpdatedEvent>>(c => c.GetService<IEditDatesViewModel>());

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        }

        private static void AddViewModels(IServiceCollection services)
        {
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<IAssignmentsViewModel, AssignmentsViewModel>();
            services.AddSingleton<IPeriodSelectionViewModel, PeriodSelectionViewModel>();
            services.AddSingleton<IEditDatesViewModel, EditDatesViewModel>();
            services.AddSingleton<IStatsAcceptedRejectedViewModel, StatsAcceptedRejectedViewModel>();
            services.AddSingleton<IStatsEmailAddressesViewModel, StatsEmailAddressesViewModel>();
            services.AddSingleton<IStatsSchoolsViewModel, StatsSchoolsViewModel>();
            services.AddSingleton<IEditCounselorsViewModel, EditCounselorsViewModel>();
        }

        private static void AddDatabaseConnection(IServiceCollection services)
        {
            var dbFilePath = Path.Combine(Globals.NsFolderPath(), "NsPlanner.mdf");
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=nsplanner;AttachDbFilename=" +
                                   dbFilePath + ";Integrated Security=True;Connect Timeout=30";
            services.AddScoped<AppDbContext, AppDbContext>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork>(c => c.GetService<AppDbContext>());
            services.AddScoped<IRepository, EfRepository>();
        }
    }
}