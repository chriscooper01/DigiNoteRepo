using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoryProject
{
    class PopulateElements
    {
        public static void SetPrimaryDayTitle(ref WebBrowser page, Model.DiarySDF.Tables.RecordTable result, ref string dayInFocus)
        {
            if (!result.DateTimeCreated.DayOfWeek.ToString().Equals(dayInFocus))
            {
                page.Document.Write("<br><br><b><u>");
                page.Document.Write(String.Format("{0} - {1} ", result.DateTimeCreated.DayOfWeek.ToString(), result.DateTimeCreated.ToString("dd/MM/yyyy")));
                page.Document.Write("</u></b>");
                dayInFocus = result.DateTimeCreated.DayOfWeek.ToString();
            }
        }

        public static void SetTimeSubTitle(ref WebBrowser page, Model.DiarySDF.Tables.RecordTable result)
        {
            page.Document.Write("<br><b><u>");
            page.Document.Write(result.DateTimeCreated.ToString("hh:mm:ss"));
            page.Document.Write("</u></b><br>");

        }

        public static string SetCodeElement(string body, string colour, string element, string title)
        {
            StringBuilder e = new StringBuilder();
            int startIndex = 0;
            int EndIndex = 0;
            int lastEnd = 0;
            while (startIndex >= 0)
            {

                startIndex = body.IndexOf(String.Format("[{0}]", element), EndIndex, StringComparison.CurrentCulture);
                if (startIndex >= 0)
                {
                    EndIndex = body.IndexOf(String.Format("[/{0}]", element), startIndex, StringComparison.CurrentCulture);
                    if (startIndex <= EndIndex)
                    {
                        string altered = String.Format("<br><div style='background-color: {0}; margin: auto; max-width:50px; border: 3px, solid: #73AD21;'><div><b>{1}:</b></div>{2}</div>", colour, title + startIndex.ToString() + " " + EndIndex.ToString(), body.Substring(startIndex, EndIndex - startIndex));
                        altered = altered.Replace(String.Format("[{0}]", element), "").Replace(String.Format("[/{0}]", element), "");
                        string orignal = body.Substring(startIndex, EndIndex - startIndex);
                        body = body.Replace(orignal, altered);

                    }
                    else
                        break;


                }
                else
                    break;

            }

            return body.Replace(String.Format("[{0}]", element), "").Replace(String.Format("[/{0}]", element), "");

        }
    }
}
