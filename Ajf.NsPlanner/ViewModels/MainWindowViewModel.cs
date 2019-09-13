using System.ComponentModel;
using Ajf.NsPlanner.Application.Abstractions;
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
        private string _close;
        private ICommand _exitCommand;
        private RequestedDialog _requestedDialog;

        public MainWindowViewModel(IPeriodSelectionViewModel periodSelectionViewModel,
            IAssignmentsViewModel assignmentsViewModel, IImportLatestRawCommand importLatestRawCommand,
            IStartAssignmentCounselorCommand startAssignmentCounselorCommand, IDispatcher dispatcher,
            IEditDatesViewModel editDatesViewModel,
            IStatsAcceptedRejectedViewModel statsAcceptedRejectedViewModel,
            IStatsEmailAddressesViewModel statsEmailAddressesViewModel, IStatsSchoolsViewModel statsSchoolsViewModel,
            ISetMarkerCommand setMarkerCommand, IEditCounselorsViewModel editCounselorsViewModel,
            IEditPlacesViewModel editPlacesViewModel, IEditAssignmentViewModel editAssignmentViewModel)
        {
            ImportLatestRawCommand = importLatestRawCommand;
            StartAssignmentCounselorCommand = startAssignmentCounselorCommand;
            EditDatesViewModel = editDatesViewModel;
            StatsAcceptedRejectedViewModel = statsAcceptedRejectedViewModel;
            StatsEmailAddressesViewModel = statsEmailAddressesViewModel;
            StatsSchoolsViewModel = statsSchoolsViewModel;
            SetMarkerCommand = setMarkerCommand;
            EditCounselorsViewModel = editCounselorsViewModel;
            EditPlacesViewModel = editPlacesViewModel;
            EditAssignmentViewModel = editAssignmentViewModel;
            PeriodSelectionViewModel = periodSelectionViewModel;

            PeriodSelectionViewModel.PropertyChanged += PeriodSelectionViewModel_PropertyChanged;
            AssignmentsViewModel = assignmentsViewModel;

            var periods1 = dispatcher.Dispatch(new FindPeriodsQuery());
            PeriodSelectionViewModel.SetPeriods(periods1);

            var counselors = dispatcher.Dispatch(new ListCounselorsQuery());
            EditCounselorsViewModel.SetCounselors(counselors);

            var places = dispatcher.Dispatch(new ListPlacesQuery());
            EditPlacesViewModel.SetPlaces(places);
        }

        public string Title => "NS Planner -- " + (PeriodSelectionViewModel.SelectedPeriod == null
                                   ? "Ingen periode valgt"
                                   : PeriodSelectionViewModel.SelectedPeriod.DateRange.ToString());


        public IImportLatestRawCommand ImportLatestRawCommand { get; }
        public IStartAssignmentCounselorCommand StartAssignmentCounselorCommand { get; }
        public ICommand ExitCommand => _exitCommand ??= new RelayCommand(Exit);

        public IStatsAcceptedRejectedViewModel StatsAcceptedRejectedViewModel { get; }
        public IStatsEmailAddressesViewModel StatsEmailAddressesViewModel { get; }
        public IStatsSchoolsViewModel StatsSchoolsViewModel { get; }
        public ISetMarkerCommand SetMarkerCommand { get; }
        public IEditCounselorsViewModel EditCounselorsViewModel { get; }
        public IEditPlacesViewModel EditPlacesViewModel { get; }

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

        public IEditAssignmentViewModel EditAssignmentViewModel { get; }

        public void OnLoaded()
        {
            WindowManager.OpenWindowsLastOpened();
        }

        public IAssignmentsViewModel AssignmentsViewModel { get; }

        public IPeriodSelectionViewModel PeriodSelectionViewModel { get; }

        public void Handle(AssignmentCreatedEvent domainEvent)
        {
            //this.AssignmentsViewModel.Items
            //throw new NotImplementedException();
        }

        public void Handle(EventRequestUpdatedEvent domainEvent)
        {
            //throw new NotImplementedException();
        }

        public string Close
        {
            get => _close;
            set
            {
                _close = value;
                OnPropertyChanged();
            }
        }

        private void Exit(object obj)
        {
            Close = "Close window";
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
    }
}