using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanNotesApp
{
    internal class Utils
    {
    }

    class Format
    {
        public static string FormatDate(string input, string inputFormat, string outputFormat)
        {
            DateTime date = DateTime.ParseExact(input, inputFormat, CultureInfo.InvariantCulture);
            return date.ToString(outputFormat);
        }
    }
}
