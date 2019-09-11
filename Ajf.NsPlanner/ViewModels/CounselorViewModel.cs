using System;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class CounselorViewModel
    {
        private readonly Counselor _counselor;

        public CounselorViewModel(Counselor counselor)
        {
            _counselor = counselor;
        }

        public string Name
        {
            get => _counselor.Name;
            set => _counselor.Name = value;
        }

        public string Email
        {
            get => _counselor.Email;
            set => _counselor.Email = value;
        }

        public string Phone
        {
            get => _counselor.Phone;
            set => _counselor.Phone = value;
        }

        public Guid Id => _counselor.Id;
        public Counselor Model => _counselor;
    }
}