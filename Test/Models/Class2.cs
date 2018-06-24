using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace Test.Models
{
    public class Params
    {
        public IList<object> args { get; set; }
        public string method { get; set; }
        public string service { get; set; }
        public class EmailDetails
        {
            public String emailId { get; set; }
        }
       
    }



    public class ERPRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        [JsonProperty("params")]
        public Params params2 { get; set; }
       
}
}