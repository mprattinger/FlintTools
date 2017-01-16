using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintTools.Contracts.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertRTFToString(this string rtfString)
        {
            string res = rtfString;

            try
            {
                if (isRichText(rtfString))
                {
                    //var basicRtfPattern = "/\{\*?\\[^{}]+;}|[{}]|\\[A-Za-z]+\n?(?:-?\d+)?[]?/g";
                    //var newLineSlashesPattern = "/\\\n/g";
                    //var ctrlCharPattern = "/\n\\f[0 - 9]\s/g";

                    ////Remove RTF Formatting, replace RTF new lines with real line breaks, and remove whitespace
                    //res = rtfString
                    //    .Replace(ctrlCharPattern, "")
                    //    .Replace(basicRtfPattern, "")
                    //    .Replace(newLineSlashesPattern, "\n")
                    //    .Trim();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }

        private static bool isRichText(string testString)
        {
            if ((testString != null) &&
                (testString.Trim().StartsWith("{\\rtf")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
