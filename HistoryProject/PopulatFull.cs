using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoryProject
{
    public class PopulatFull
    {

        private static string dayInFocus;

        public static void Populate(ref WebBrowser page, int category, int subCategory)
        {
         //   page = new WebBrowser();
       //     page.Text = String.Empty;            
            decimal totalTime = 0;
            dayInFocus = String.Empty; ;
            var fontDate = new System.Drawing.Font(page.Font, FontStyle.Bold | FontStyle.Underline);
            var fontTime = new System.Drawing.Font(page.Font, FontStyle.Bold);
            var fontNormal = page.Font;
            
            page.DocumentText = "0";            
            page.Document.Write("<html><body>");
            foreach (var result in Model.DiarySDF.Queries.RecordQuery.List(subCategory, category))
            {
                if (result != null)
                    totalTime += result.TimeSpent;

                PopulateElements.SetPrimaryDayTitle(ref page,result, ref dayInFocus);

                PopulateElements.SetTimeSubTitle(ref page, result);

                string body = PopulateElements.SetCodeElement(result.Body.ToString(), "lightBlue", "CODE", "Code");
                body = PopulateElements.SetCodeElement(body, "lightBlue", "Code", "Code");
                body = PopulateElements.SetCodeElement(body, "red", "ERROR", "Error");
                body = PopulateElements.SetCodeElement(body, "grey", "url", "Url");
                body = PopulateElements.SetCodeElement(body, "grey", "URL", "Url");
                body = body.Replace(Environment.NewLine, "<br><br>");
                body = body.Replace("/n", "<br>");
                body = body.Replace("\n", "<br>");
                page.Document.Write(body.Replace(Environment.NewLine, "<br><br>"));
                page.Document.Write("<br><br>");
            }

            double t = 0;
            double.TryParse(totalTime.ToString(), out t);
            var time = TimeSpan.FromMilliseconds(t);
            page.Refresh();
        }
    }
}
