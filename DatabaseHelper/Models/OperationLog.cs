using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Models
{
    public class OperationLog
    {
        public Guid LogId { get; set; }
        public Guid UserId { get; set; }
        public Guid RecordId { get; set; }
        public string OperationType { get; set; }
        public string OperationDetails { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
