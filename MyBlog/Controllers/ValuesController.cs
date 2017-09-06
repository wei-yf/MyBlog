using Dapper;
using MyBlog.Help;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyBlog.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        public HttpResponseMessage Get()
        {
            Dictionary<string, string> para = new Dictionary<string, string>();
            foreach(var item in Request.GetQueryNameValuePairs())
            {
                para.Add(item.Key, item.Value);
            }
            string nonce = "";
            string signature="";
            string timestamp="";
            string echostr = "";
            if (para.ContainsKey("nonce"))
            {
                nonce = para["nonce"];
            }
            if (para.ContainsKey("signature"))
            {
                signature = para["signature"];
            }
            if (para.ContainsKey("timestamp"))
            {
                timestamp = para["timestamp"];
            }
            if (para.ContainsKey("echostr"))
            {
                echostr = para["echostr"];
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(echostr)
            };
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
        [Route("dapper/query")]
        public HttpResponseMessage getQuery()
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                Test t = conn.Query<Test>("select * from Test where id=@id", new { id = 10 }).FirstOrDefault();
               return  ReturnHelp.toJson(t);
            }
        }
        [Route("dapper/update")]
        public int getUpdate()
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
               int n= conn.Execute("update test set student=@student where id=@id", new { student = "啊实打实", id = 11 });
                return n;
            }
        }
        [Route("dapper/delete")]
        public int getDelete()
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                int n = conn.Execute("delete from test where id=@id", new { id = 13 });
                return n;
            }
        }
        [Route("dapper/in")]
        public HttpResponseMessage getIn()
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var info = conn.Query<Test>("select * from Test where id in @idlist", new { idlist = new int[3] { 13, 15, 17 } });
                return ReturnHelp.toJson(info);
            }
        }
        [Route("dapper/mul")]
        public HttpResponseMessage getMul(int n=0)
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var sql = "select * from test;select * from testClass";
                var multiReader = conn.QueryMultiple(sql);
                var testList = multiReader.Read<Test>();
                var classList = multiReader.Read<TestClass>();
                if(n==0)
                {
                    return ReturnHelp.toJson(classList);
                }
                return ReturnHelp.toJson(testList);
            }
        }
        [Route("dapper/join")]
        public HttpResponseMessage getJoin(int n)
        {
            
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var sql = @"select t.id,t.student,c.name from test t join testClass c on t.id=c.testid ";
                var res = conn.Query(sql);
                var res1 = conn.Query<Test, TestClass, Test>(sql, (test, cla) =>
                {
                    test.tc = cla;
                    return test;
                },splitOn:"name");//splitOn就是Dapper对DataReader进行”从右到左“的扫描，这样就可以从sequent中获取到一个subsequent，然后遇到设置的splitOn就停止
                if (n==0)
                {
                    return ReturnHelp.toJson(res);
                }
                return ReturnHelp.toJson(res1);
            }
        }

        [Route("dapper/sp")]
        public HttpResponseMessage getSp()
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var result = conn.Query("sp_getTest", new { id = 5 }, commandType: CommandType.StoredProcedure);
                return ReturnHelp.toJson(result);
            }
        }
    }
    public class Test
    {
        public int Id { get; set; }
        public string student { get; set; }
        public string sex { get; set; }
        public TestClass  tc { get; set; }
    }
    public class TestClass
    {
        public int classid { get; set; }
    public string    name { get; set; }
        public string cno { get; set; }
        public int testid { get; set; }
    }
}
