using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class CounselorViewModel:ViewModel
    {
        private readonly Counselor _counselor;
        private readonly IDispatcher _dispatcher;

        public CounselorViewModel(Counselor counselor, IDispatcher dispatcher)
        {
            _counselor = counselor;
            _dispatcher = dispatcher;
        }

        public string Name
        {
            get => _counselor.Name;
            set
            {
                _counselor.Name = value;
                CommitChanges();
                OnPropertyChanged();
            }
        }
        public void CommitChanges()
        {
            try
            {
                _dispatcher.Dispatch(new UpdateCounselorCommand(_counselor));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string Email
        {
            get => _counselor.Email;
            set
            {
                _counselor.Email = value; 
                CommitChanges();
            }
        }

        public string Phone
        {
            get => _counselor.Phone;
            set
            {
                _counselor.Phone = value; 
                CommitChanges();
            }
        }

        public Guid Id => _counselor.Id;
        public Counselor Model => _counselor;
    }
}