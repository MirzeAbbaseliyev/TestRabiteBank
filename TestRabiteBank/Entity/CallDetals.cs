using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRabiteBank.Entity
{
    public class CallDetals
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public DateTime InsertDate { get; set; }
        public string Value { get; set; }
    }
}
