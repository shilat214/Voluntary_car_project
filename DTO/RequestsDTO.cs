using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RequestsDTO
    {
        public int IdRequest { get; set; }
        public string IdRequester { get; set; }
        public string IdService { get; set; }
        public string RequestText { get; set; }
        public string RequestStatus { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public Nullable<int> RequestedHours { get; set; }

    }
}
