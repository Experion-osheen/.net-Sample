using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReqDto
    {
            public int Rid { get; set; }
            public string empid { get; set; }
            public int pid { get; set; }
            public string cause { get; set; }
            public System.DateTime Fromdate { get; set; }
            public System.DateTime Todate { get; set; }
            public int noDays { get; set; }
            public string source { get; set; }
            public string Destination { get; set; }
            public string mode { get; set; }
    }
}
