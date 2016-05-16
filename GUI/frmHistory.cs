using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHistory : Form
    {
        public bool DayView;
        public int SubjectId;
        public int CategoryId;
        public DateTime Date { get; set; }
        public frmHistory()
        {
            InitializeComponent();
            setCatList();
        }
        
        private void setPrimaryDayTitle(ref WebBrowser page, Model.DiarySDF.Tables.RecordTable result, ref string dayInFocus)
        {
            if (!result.DateTimeCreated.DayOfWeek.ToString().Equals(dayInFocus))
            {
                page.Document.Write("<br><br><b><u>");
                page.Document.Write(String.Format("{0} - {1} ", result.DateTimeCreated.DayOfWeek.ToString(), result.DateTimeCreated.ToString("dd/MM/yyyy")));
                page.Document.Write("</u></b>");
                dayInFocus = result.DateTimeCreated.DayOfWeek.ToString();
            }
        }

        private void setTimeSubTitle(ref WebBrowser page, Model.DiarySDF.Tables.RecordTable result)
        {
            wbHistory.Document.Write("<br><b><u>");
            wbHistory.Document.Write(result.DateTimeCreated.ToString("hh:mm:ss"));
            wbHistory.Document.Write("</u></b><br>");

        }

        private string setCodeElement(string body, string colour, string element, string title)
        {
            StringBuilder e = new StringBuilder();
            int startIndex = 0;
            int EndIndex = 0;
            int lastEnd = 0;
            while (startIndex>=0)
            {
                
                startIndex = body.IndexOf(String.Format("[{0}]",element), EndIndex ,StringComparison.CurrentCulture);
                if (startIndex >=0)
                {
                    EndIndex = body.IndexOf(String.Format("[/{0}]", element), startIndex, StringComparison.CurrentCulture);
                    if (startIndex <= EndIndex)
                    {
                        string altered = String.Format("<br><div style='background-color: {0}; margin: auto; max-width:50px; border: 3px, solid: #73AD21;'><div><b>{1}:</b></div>{2}</div>", colour, title+ startIndex.ToString() +" "+ EndIndex.ToString(), body.Substring(startIndex, EndIndex - startIndex));
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


        private string dayInFocus = String.Empty;
        private void loadHistoryCatandSub()
        {
            rtbHistory.Text = String.Empty;
            setCatList();
            decimal totalTime = 0;
            dayInFocus = String.Empty; ;
            var fontDate = new System.Drawing.Font(rtbHistory.Font, FontStyle.Bold|FontStyle.Underline);
            var fontTime = new System.Drawing.Font(rtbHistory.Font, FontStyle.Bold);
            var fontNormal = rtbHistory.Font;
            int startLine = 0;
            wbHistory.DocumentText = "0";
            //wbHistory.Document.OpenNew(true);
            wbHistory.Document.Write("<html><body>");
            foreach (var result in Model.DiarySDF.Queries.RecordQuery.List(SubjectId, CategoryId))
            {
                if(result !=null)
                totalTime += result.TimeSpent;

                setPrimaryDayTitle(result);

                setTimeSubTitle(result);

                string body = setCodeElement(result.Body.ToString(),"lightBlue","CODE","Code");
                body = setCodeElement(body, "lightBlue", "Code", "Code");
                body = setCodeElement(body, "red", "ERROR", "Error");
                body = setCodeElement(body, "grey", "url", "Url");
                body = setCodeElement(body, "grey", "URL", "Url");
                body = body.Replace(Environment.NewLine, "<br><br>");
                body = body.Replace("/n", "<br>");
                body = body.Replace("\n", "<br>");
                wbHistory.Document.Write(body.Replace(Environment.NewLine, "<br><br>"));
                wbHistory.Document.Write("<br><br>");
            }
            
            double t = 0;
            double.TryParse(totalTime.ToString(), out t);
            var time = TimeSpan.FromMilliseconds(t);
            wbHistory.Refresh();

            
            lblTotalTime.Text = String.Format("Total time taken: {0}:{1}:{2}", time.Hours.ToString(""), time.Minutes.ToString(), time.Seconds.ToString());

        }




        private void loadHistoryCatandSub1()
        {
            rtbHistory.Text = String.Empty;
            setCatList();
            decimal totalTime = 0;
            StringBuilder lines = new StringBuilder();
            string dayInFocus = String.Empty;
            var fontDate = new System.Drawing.Font(rtbHistory.Font, FontStyle.Bold | FontStyle.Underline);
            var fontTime = new System.Drawing.Font(rtbHistory.Font, FontStyle.Bold);
            var fontNormal = rtbHistory.Font;
            int startLine = 0;
            wbHistory.DocumentText = "0";
            wbHistory.Document.OpenNew(true);

            //
            wbHistory.Document.Write("<html><body>");
            foreach (var result in Model.DiarySDF.Queries.RecordQuery.List(SubjectId, CategoryId))
            {
                if (result != null)
                    totalTime += result.TimeSpent;

                if (!result.DateTimeCreated.DayOfWeek.ToString().Equals(dayInFocus))
                {
                    wbHistory.Document.Write("<br><br><b><u>");
                    wbHistory.Document.Write(String.Format("{0} - {1} ", result.DateTimeCreated.DayOfWeek.ToString(), result.DateTimeCreated.ToString("dd/MM/yyyy")));
                    wbHistory.Document.Write("</u></b><br>");
                    dayInFocus = result.DateTimeCreated.DayOfWeek.ToString();
                    rtbHistory.SelectionFont = fontDate;
                    rtbHistory.AppendText(String.Format("{0} - {1} ", result.DateTimeCreated.DayOfWeek.ToString(), result.DateTimeCreated.ToString("dd/MM/yyyy")));
                    //startLine = (rtbHistory.Lines.Length) - 1;
                    //rtbHistory.Select(startLine, rtbHistory.Lines.Length);

                    rtbHistory.AppendText(Environment.NewLine);


                }
                rtbHistory.SelectionFont = fontTime;
                rtbHistory.AppendText(result.DateTimeCreated.ToString("hh:mm:ss"));
                wbHistory.Document.Write("<br><b><u>");
                wbHistory.Document.Write(result.DateTimeCreated.ToString("hh:mm:ss"));
                wbHistory.Document.Write("</u></b><br>");

                rtbHistory.SelectionFont = fontNormal;
                rtbHistory.AppendText(Environment.NewLine);
                rtbHistory.AppendText(result.Body);
                rtbHistory.AppendText(Environment.NewLine);
                rtbHistory.AppendText(Environment.NewLine);

                wbHistory.DocumentText += Environment.NewLine;
                lines.AppendLine(result.Body);
                lines.Append("<br><br>");
                wbHistory.Document.Write(result.Body.ToString().Replace(Environment.NewLine, "<br><br>"));
                wbHistory.Document.Write("<br><br>");
            }
            //wbHistory.Document.Write(String.Format("<html><body>{0}<body></html>", lines.ToString().Replace(Environment.NewLine, "<br><br>")));
            createBodyElement("ERROR", Color.Red);
            createBodyElement("CODE", Color.LightBlue);
            double t = 0;
            double.TryParse(totalTime.ToString(), out t);
            var time = TimeSpan.FromMilliseconds(t);
            rtbHistory.Refresh();
            wbHistory.Refresh();

            //rtbHistory.Text = rtbHistory.Text.Replace(String.Format("[{0}]", "ERROR"), "Error Message");
            //rtbHistory.Text =  rtbHistory.Text.Replace(String.Format("[/{0}]", "ERROR"), String.Empty);
            //rtbHistory.Text =  rtbHistory.Text.Replace(String.Format("[{0}]", "CODE"), "Code Snippet");
            //rtbHistory.Text = rtbHistory.Text.Replace(String.Format("[/{0}]", "CODE"), String.Empty);

            //rtbHistory.Refresh();

            lblTotalTime.Text = String.Format("Total time taken: {0}:{1}:{2}", time.Hours.ToString(""), time.Minutes.ToString(), time.Seconds.ToString());

        }

        private void createBodyElement(string element, Color color)
        {
            if(!String.IsNullOrEmpty(rtbHistory.Text.Trim()))
            {
                bool found = false;
                int lineNumber = 0;
                int il = 0;
                int indexEnd = 0;
                while (il >= 0)
                {
                    string findElement = String.Format("[{0}]", element);
                
                    il = rtbHistory.Find(findElement,il, RichTextBoxFinds.WholeWord);
                    if (il >= 0)
                    {
                        indexEnd = rtbHistory.Find(String.Format("[/{0}]", element), il, RichTextBoxFinds.WholeWord);
                        rtbHistory.Select(il, indexEnd - il);
                        rtbHistory.SelectionFont = new System.Drawing.Font(rtbHistory.Font, FontStyle.Italic);
                        rtbHistory.SelectionBackColor = color;

                    }
                    if (il < 0)
                        break;
                il++;
                }

            }




            //foreach (var line in rtbHistory.Lines)
            //{

            //    if (il >= 0)
            //    {
            //        found = true;
            //    //    rtbHistory.AppendText(line.Replace("[CODE]", String.Empty));

            //    }else if(found && indexEnd >=0)
            //    {
            //        found = false;
            //    }


            //    if(found)
            //    {
            //        rtbHistory.Select(il, indexEnd);
            //        rtbHistory.SelectionFont = new System.Drawing.Font(rtbHistory.Font, FontStyle.Italic);
            //        rtbHistory.SelectionBackColor = Color.Aqua;

            //    }
            //    lineNumber++;
            //}



        }

        private void loadHistoryDay()
        {

            rtbHistory.Text = String.Empty;
            decimal totalTime = 0;
            rtbHistory.Text = String.Empty;
            double t = 0;
            StringBuilder lines = new StringBuilder();
            foreach (var result in Model.DiarySDF.Queries.RecordQuery.List(Date))
            {

                string type = String.Format("({0} {1})",  Model.DiarySDF.Queries.CategoryQuery.Single(result.CategoryId), "{0}");
                type = String.Format(type, Model.DiarySDF.Queries.SubjectQuery.Single(result.SubjectId));
                
                double.TryParse(result.TimeSpent.ToString(), out t);
                var time = TimeSpan.FromMilliseconds(t);

              string timespent = String.Format("Total time taken: {0}:{1}:{2}", time.Hours.ToString(""), time.Minutes.ToString(), time.Seconds.ToString());


                totalTime += result.TimeSpent;
                rtbHistory.Text += String.Format("Day: {0}: {1}- {2} (Timespent: {3})", type, result.DateTimeCreated.DayOfWeek.ToString(), result.DateTimeCreated.ToString("dd/MM/yyyy hh:mm:ss"),timespent);
                rtbHistory.Text += Environment.NewLine;
                rtbHistory.Text += result.Body;
                rtbHistory.Text += Environment.NewLine;
                rtbHistory.Text += Environment.NewLine;


            }

            foreach (string line in rtbHistory.Lines)
            {
                dayHeader(line);
                codeElement(line);
            }
          
            double.TryParse(totalTime.ToString(), out t);
            var time1 = TimeSpan.FromMilliseconds(t);

            lblTotalTime.Text = String.Format("Total time taken: {0}:{1}:{2}", time1.Hours.ToString(""), time1.Minutes.ToString(), time1.Seconds.ToString());

        }

        private void dayHeader(string line)
        {
            if (line.StartsWith("Day:"))
            {
                int srt = rtbHistory.Find(line);
                if (srt > 0)
                {

                    rtbHistory.Select(srt, line.Length);
                    rtbHistory.SelectionFont = new System.Drawing.Font(rtbHistory.Font, FontStyle.Bold);
                }
            }
        }
        private bool bcodeElement;
        private void codeElement(string line)
        {
            if (line.StartsWith("[/CODE]") && bcodeElement)
                bcodeElement = false;

            if (line.StartsWith("[CODE]") || bcodeElement)
            {
                int srt = rtbHistory.Find(line);
                bcodeElement = true;
                if (srt > 0)
                {
                    rtbHistory.Select(srt, line.Length);
                    rtbHistory.SelectionFont = new System.Drawing.Font(rtbHistory.Font, FontStyle.Italic);
                    rtbHistory.BackColor = Color.LightPink;
                }
            }
        }



        private void frmHistory_Load(object sender, EventArgs e)
        {

            if (!DayView)
                loadHistoryCatandSub();
            else
                loadHistoryDay();
            
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cat = (ComboBox)sender;
            var item = (Model.UniversalDataClasses.ListItem)cat.SelectedItem;
            
            if (!item.Id.Equals(CategoryId))
            {
                CategoryId = item.Id;
                setSubjectList();
            }
            setSubjectList();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

            var sub = (ComboBox)sender;
            var item = (Model.UniversalDataClasses.ListItem)sub.SelectedItem;
            if(!item.Id.Equals(SubjectId))
            {
                SubjectId = item.Id;
                loadHistoryCatandSub();
            }
            
        }

        private void setCatList()
        {
            setComboBox(Model.DiarySDF.Queries.CategoryQuery.List(), cmbCategory,CategoryId);
            cmbCategory.SelectedItem = Model.DiarySDF.Queries.CategoryQuery.List().FirstOrDefault(x => x.Id.Equals(CategoryId));
            cmbSubject.Enabled = (CategoryId > 0);
        }

        private void setSubjectList()
        {

            setComboBox(Model.DiarySDF.Queries.SubjectQuery.List(CategoryId), cmbSubject, SubjectId);
            cmbSubject.Enabled = (CategoryId> 0);



        }

        private void setComboBox(List<Model.UniversalDataClasses.ListItem> items, ComboBox controller, int id)
        {
            controller.Items.Clear();
            foreach (var item in items)
            {
                controller.Items.Add(item);
            }
            controller.DisplayMember = "Text";
            controller.ValueMember = "Id";
            var indexFound = items.FirstOrDefault(x => x.Id.Equals(id));
            if (indexFound != null)
                controller.SelectedIndex = controller.Items.IndexOf(indexFound);


        }
    }
}
