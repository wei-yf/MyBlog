using Dapper;
using MyBlog.Help;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlog.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value3" };
        }


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        [Route("dapper/test")]
        public string getTest()
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {  //插入时，sql语句中的属性值要与数据库表中的一致
                var res = conn.Execute("insert into test values(@sex,@student,@id)", new Test { sex = "男", student = "为远方", Id = 2 });

                var testList = Enumerable.Range(0, 10).Select(i => new Test
                {
                    Id = i + 10,
                    sex = "那",
                    student = "test" + i
                });
                var ss = conn.Execute("insert into test values(@student,@sex,@id)", testList);
                return (res + ss).ToString();
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
    public class Test
    {
        public int Id { get; set; }
        public string student { get; set; }
        public string sex { get; set; }
    }
}
