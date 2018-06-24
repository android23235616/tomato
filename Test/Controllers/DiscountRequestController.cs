using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{

    public class DiscountRequestController : ApiController
    {

        Employee[] employees = new Employee[]{
         new Employee { ID = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Employee { ID = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Employee { ID = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
      };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("api/DiscountRequest/test")]
        public async Task<String> test(RootObject s)
        {
            // return s.Content.ReadAsStringAsync().Result;
            // RootObject ss = s.Content.ReadAs().Result;
            // RootObject jo = JObject.Parse(ss);      
            var r = JsonConvert.DeserializeObject<RootObject>(JsonConvert.SerializeObject(s));
            return r.abc;


        }
        [HttpPost]
        [Route("api/DiscountRequest/test2")]
        public async Task<ERPResponse> test2()
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            ERPRequest req = new ERPRequest();
            req.jsonrpc = "2.0";
            req.method = "call";
            Params p = new Params();
            p.method = "execute";
            p.service = "object";
            List<Object> args = new List<Object>();
            args.Add("NowFloatsV10");
            args.Add(7976);
            args.Add("ERPapi123");
            args.Add("nf.api");
            args.Add("getLeadDetails");
            Params.EmailDetails em = new Params.EmailDetails();
            em.emailId = "tanmay.majumdar@nowfloats.com";
            args.Add(em);
            p.args = args;
            req.params2 = p;

            var json = JsonConvert.SerializeObject(req);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        String r = await client.PostAsync("http://erp.nowfloats.com/jsonrpc", byteContent).Result.Content.ReadAsStringAsync();


            ERPResponse rr = JsonConvert.DeserializeObject<ERPResponse>(r);

            return rr;
           
        }



    }
}

