using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Application.Commands
{
    public class SetMarkerOnAssignmentCommand : ICommand
    {
        public string Marker { get; }
        public Guid AssignmentId { get; }

        public SetMarkerOnAssignmentCommand(string marker, Guid assignmentId)
        {
            Marker = marker;
            AssignmentId = assignmentId;
        }
    }
}