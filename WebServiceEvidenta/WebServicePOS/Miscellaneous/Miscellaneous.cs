using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceEvidenta.Miscellaneous
{
    public class Miscellaneous
    {
        public static String ConvertDateStringToFoxDate(String baseDate)
        {
            String[] DateElements = baseDate.Split('.').ToArray();
            return DateElements.Count() > 2 ? "{^" +
                (DateElements[2].Trim().Substring(0, 4) ?? "2021") +
                "-" +
                (DateElements[1].Trim().PadLeft(2, '0').Substring(0, 2) ?? "01") +
                "-" +
                (DateElements[0].Trim().PadLeft(2, '0').Substring(0, 2) ?? "01") + 
                "}" : ConvertDateStringToFoxDate(DateTime.Now.ToString("dd.MM.yyyy"));
        }
    }
}