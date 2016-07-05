using Jil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDocumentMaker.Utility
{
    static class Common
    {

        /// <summary>
        /// Deeps the clone via json.
        /// </summary>
        /// <typeparam name="T">Target class</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static T DeepCloneViaJson<T>(this T source)
        {

            if (source != null)
            {
                var serializedObj = JSON.Serialize(source);
                return JSON.Deserialize<T>(serializedObj);
            }
            else
            { return default(T); }

        }


        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToTitleCase(this string input)
        {
            var txtInfo = new CultureInfo("en-US", false).TextInfo;
            return txtInfo.ToTitleCase(input.ToLower());
        }
    }
}
