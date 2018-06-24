using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Result
    {
        public object business_category { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public bool c_quotation_created { get; set; }
        public object fptag { get; set; }
        public string mobile { get; set; }
        public object country { get; set; }
        public string street2 { get; set; }
        public int opp_id { get; set; }
        public string pincode { get; set; }
        public object state { get; set; }
        public string street { get; set; }
        public string company_name { get; set; }
        public string type { get; set; }
        public string company_email { get; set; }
    }

    public class ERPResponse
    {
        public string jsonrpc { get; set; }
        public object id { get; set; }
        public IList<Result> result { get; set; }
    }

}