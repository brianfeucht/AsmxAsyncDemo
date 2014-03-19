using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace AsmxAsync
{
    /// <summary>
    /// Summary description for HelloWorld
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HelloWorld : System.Web.Services.WebService
    {

        [WebMethod]
        public string Sync()
        {
            return "Hello World";
        }

        /// <summary>
        /// Doesn't work!  ASP thread doesn't wait 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public async Task<string> Tap()
        {
            await Task.Delay(1000);

            return "Hello World Async";
        }

        [WebMethod]
        public IAsyncResult BeginApm(AsyncCallback cb, object state)
        {
            var apm = new ApmHelloWorld();
            return apm.BeginApm(cb, state);
        }

        [WebMethod]
        public string EndApm(IAsyncResult result)
        {
            return ApmHelloWorld.EndApm(result);
        }

        [WebMethod]
        public IAsyncResult BeginTapToApm(AsyncCallback cb, object state)
        {
            var tapToApm = new TapToApmHelloWorld();
            return tapToApm.BeginTapToApm(cb, state);
        }

        [WebMethod]
        public string EndTapToApm(IAsyncResult result)
        {
            return TapToApmHelloWorld.EndTapToApm(result);
        }

        [WebMethod]
        public IAsyncResult BeginTapToApmException(AsyncCallback cb, object state)
        {
            var tapToApm = new TapToApmHelloWorld();
            return tapToApm.BeginTapToApmException(cb, state);
        }

        [WebMethod]
        public string EndTapToApmException(IAsyncResult result)
        {
            return TapToApmHelloWorld.EndTapToApm(result);
        }
    }
}
