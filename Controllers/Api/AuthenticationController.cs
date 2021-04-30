using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StudentCrudApp.Controllers.Api
{
    public class AuthenticationController : ApiController
    {

        public HttpResponseMessage Post(STUDENT stud)
        {
            //dynamic JSON = JsonConvert.DeserializeObject<STUDENT>(stud);

            try
            {
                // TODO: Add update logic here
                var context = new ConsortoUniversity1Entities1();
                var students = context.STUDENTS;
                //context.Entry(student).State = EntityState.Modified;
                //context.SaveChanges();
                var result = students.Where(s => s.StudentRSAIDnumber == stud.StudentRSAIDnumber && s.StudentName.ToUpper() == stud.StudentName.ToUpper()).ToList<STUDENT>();
                string idNum = "";
                dynamic response = new JObject();

                foreach (var str in result)
                {
                    idNum = str.StudentRSAIDnumber;
                }

                //response.result = idNum;
                if (idNum != "")
                {
                    //Redirect("https://localhost:44362/Students/Index/");
                    return Request.CreateResponse(HttpStatusCode.OK, idNum);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, stud);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, stud);
            }
        }
         
    }
}
