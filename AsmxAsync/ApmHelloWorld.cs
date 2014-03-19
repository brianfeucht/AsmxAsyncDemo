using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsmxAsync
{
    public class ApmHelloWorld
    {
        private static string SleepAndWake()
        {
            System.Threading.Thread.Sleep(1000);

            return "Hello World Apm";
        }

        private delegate string SleepAndWakeApm();

        private class ApmState
        {
            public readonly SleepAndWakeApm AsyncDelegate = new SleepAndWakeApm(SleepAndWake);
        }

        public IAsyncResult BeginApm(AsyncCallback cb, object s)
        {
            var state = new ApmState();

            return state.AsyncDelegate.BeginInvoke(cb, state);
        }

        public static string EndApm(IAsyncResult result)
        {
            var returnDelegate = (ApmState)result.AsyncState;
            return returnDelegate.AsyncDelegate.EndInvoke(result);
        }
    }
}