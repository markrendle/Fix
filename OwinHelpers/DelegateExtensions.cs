﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App = System.Action<System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,object>>, System.Func<byte[]>, System.Action<int, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>, System.Action<System.Action<System.ArraySegment<byte>>, System.Action, System.Action<System.Exception>>>, System.Delegate>;
using ResponseHandler = System.Action<int, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>, System.Action<System.Action<System.ArraySegment<byte>>, System.Action, System.Action<System.Exception>>>;

namespace OwinHelpers
{
    public static class DelegateExtensions
    {
        public static void InvokeAsNextApp(this Delegate @delegate, IEnumerable<KeyValuePair<string,object>> env, Func<byte[]> body,
            ResponseHandler responseHandler)
        {
            var nextApp = @delegate as App;
            if (nextApp != null)
            {
                nextApp(env, body, responseHandler, null);
            }

        }
    }
}
