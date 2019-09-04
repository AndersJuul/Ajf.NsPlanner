using System.Data;
using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Queries;

namespace Ajf.NsPlanner.Application.QueryHandlers
{
    public class EmailAddressesQueryHandler : IQueryHandler<EmailAddressesQuery, SimpleStatTable>
    {
        public SimpleStatTable Handle(EmailAddressesQuery query)
        {
            var summary = (from a in query.Assignments
                orderby a.EventRequest.ContactEmail
                     group a by a.EventRequest.ContactEmail
                into grp
                select new { key = grp.Key, AcceptedCount = grp.Count(x => x.IsAccepted), RejectedCount = grp.Count(x => x.IsRejected), TotalCount = grp.Count() }
                    )
                    .ToArray();

            var dt= new DataTable("SimpleStat");
            dt.Clear();
            dt.Columns.Add("Email");
            dt.Columns.Add("AcceptedCount");
            dt.Columns.Add("RejectedCount");
            dt.Columns.Add("Total");

            foreach (var line in summary)
            {
                dt.Rows.Add(GetDataRow(dt, new object[] { line.key, line.AcceptedCount, line.RejectedCount, line.TotalCount }));
            }

            dt.Rows.Add(GetDataRow(dt, new object[] { "-Ialt-", summary.Sum(x => x.AcceptedCount), summary.Sum(x => x.RejectedCount), summary.Sum(x => x.TotalCount) }));

            return new SimpleStatTable()
            {
                DataTable = dt
            };
        }

        private static DataRow GetDataRow(DataTable dt, object[] values)
        {
            var dataRow = dt.NewRow();
            for (var i = 0; i < values.Length; i++)
            {
                dataRow[i] = values[i];
            }
            return dataRow;
        }
    }
}