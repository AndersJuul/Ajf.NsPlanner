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

        public string Name => _counselor.Name;
        public string Email => _counselor.Email;
        public string Phone => _counselor.Phone;
        public Guid Id => _counselor.Id;
        public Counselor Model => _counselor;
    }
}