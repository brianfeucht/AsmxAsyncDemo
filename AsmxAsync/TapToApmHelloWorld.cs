using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AsmxAsync
{
    public class TapToApmHelloWorld
    {


        public IAsyncResult BeginTapToApm(AsyncCallback cb, object s)
        {
            return HellowWorldAsync().ToApm(cb, s);
        }

        public static string EndTapToApm(IAsyncResult result)
        {
            return ((Task<string>) result).Result;
        }

        public IAsyncResult BeginTapToApmException(AsyncCallback cb, object s)
        {
            return HellowWorldExceptionAsync().ToApm(cb, s);
        }

        private async Task<string> HellowWorldAsync()
        {
            await Task.Delay(1000);

            return "Hello World Async via APM wrapper";
        }

        private async Task<string> HellowWorldExceptionAsync()
        {
            var result = await HellowWorldAsync();
            
            throw new Exception("Bleh.  I broke here. " + result);
        }
    }
}