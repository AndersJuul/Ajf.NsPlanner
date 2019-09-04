namespace Ajf.NsPlanner.Domain.Queries
{
    public class Column
    {
        public string Description { get; }
        public string Field { get; }

        public Column(string description, string field)
        {
            Description = description;
            Field = field;
        }
    }
}