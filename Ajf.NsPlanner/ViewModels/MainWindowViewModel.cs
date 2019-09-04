using System.ComponentModel;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.CommandHandlers;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands;
using Ajf.NsPlanner.UI.Services;
using ICommand = System.Windows.Input.ICommand;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class MainWindowViewModel : ViewModel, IMainWindowViewModel
    {
        private readonly IGoogleFileService _googleFileService;
        private readonly IRawRequestRepository _rawRequestRepository;
        private readonly IRepository _repository;
        private ICommand _exitCommand;
        private ICommand _getLatestRawCommand;
        private RequestedDialog _requestedDialog;

        public MainWindowViewModel(IPeriodSelectionViewModel periodSelectionViewModel,
            IAssignmentsViewModel assignmentsViewModel,
            IRepository repository, IImportLatestRawCommand importLatestRawCommand,
            IStartAssignmentCounselorCommand startAssignmentCounselorCommand, IDispatcher dispatcher,
            IEditDatesViewModel editDatesViewModel,
            IStatsAcceptedRejectedViewModel statsAcceptedRejectedViewModel, IStatsEmailAddressesViewModel statsEmailAddressesViewModel, IStatsSchoolsViewModel statsSchoolsViewModel,
            ISetMarkerCommand setMarkerCommand)
        {
            _repository = repository;
            ImportLatestRawCommand = importLatestRawCommand;
            StartAssignmentCounselorCommand = startAssignmentCounselorCommand;
            EditDatesViewModel = editDatesViewModel;
            StatsAcceptedRejectedViewModel = statsAcceptedRejectedViewModel;
            StatsEmailAddressesViewModel = statsEmailAddressesViewModel;
            StatsSchoolsViewModel = statsSchoolsViewModel;
            SetMarkerCommand = setMarkerCommand;
            PeriodSelectionViewModel = periodSelectionViewModel;

            PeriodSelectionViewModel.PropertyChanged += PeriodSelectionViewModel_PropertyChanged;
            AssignmentsViewModel = assignmentsViewModel;

            var periods1 = dispatcher.Dispatch(new FindPeriodsQuery());
            PeriodSelectionViewModel.SetPeriods(periods1);
        }

        public string Title => "NS Planner -- " + (PeriodSelectionViewModel.SelectedPeriod == null
                                   ? "Ingen periode valgt"
                                   : PeriodSelectionViewModel.SelectedPeriod.DateRange.ToString());

        public ICommand GetLatestRawCommand => null;

        //_getLatestRawCommand ?? (_getLatestRawCommand = new RelayCommand(GetLatestRaw));
        public IImportLatestRawCommand ImportLatestRawCommand { get; }
        public IStartAssignmentCounselorCommand StartAssignmentCounselorCommand { get; }
        public ICommand ExitCommand => null; //_exitCommand ?? (_exitCommand = new RelayCommand(Exit));

        public IStatsAcceptedRejectedViewModel StatsAcceptedRejectedViewModel { get; }
        public IStatsEmailAddressesViewModel StatsEmailAddressesViewModel { get; }
        public IStatsSchoolsViewModel StatsSchoolsViewModel { get; }
        public ISetMarkerCommand SetMarkerCommand { get; }

        public IEditDatesViewModel EditDatesViewModel { get; }

        public RequestedDialog RequestedDialog
        {
            get => _requestedDialog;
            set
            {
                _requestedDialog = value;
                OnPropertyChanged();
            }
        }

        public void OnLoaded()
        {
            WindowManager.OpenWindowsLastOpened();
        }

        public IAssignmentsViewModel AssignmentsViewModel { get; }

        public IPeriodSelectionViewModel PeriodSelectionViewModel { get; set; }

        public void Handle(AssignmentCreatedEvent domainEvent)
        {
            //this.AssignmentsViewModel.Items
            //throw new NotImplementedException();
        }

        public void Handle(EventRequestUpdatedEvent domainEvent)
        {
            //throw new NotImplementedException();
        }

        private void PeriodSelectionViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Title");

            if (e.PropertyName == nameof(PeriodSelectionViewModel.SelectedPeriod))
            {
                AssignmentsViewModel.Target = PeriodSelectionViewModel?.SelectedPeriod?.Target;
                EditDatesViewModel.SelectedPeriod = PeriodSelectionViewModel?.SelectedPeriod;
                StatsAcceptedRejectedViewModel.SelectedPeriod = PeriodSelectionViewModel?.SelectedPeriod;
                StatsEmailAddressesViewModel.SelectedPeriod = PeriodSelectionViewModel?.SelectedPeriod;
                StatsSchoolsViewModel.SelectedPeriod = PeriodSelectionViewModel?.SelectedPeriod;
            }
        }

        private void GetLatestRaw(object o)
        {
            //_googleFileService.DownloadFile(_nsPlannerSettings.RequestFileId,
            //    _nsPlannerSettings.DataFileRawRequestFile);

            //var all = _rawRequestRepository.GetAll();
        }
    }
}