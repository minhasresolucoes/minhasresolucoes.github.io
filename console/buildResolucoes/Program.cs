using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var basePath = @"C:\Users\sgiraldo\source\minhasresolucoes.github.io\2018\";
            var baseYear = 2018;
            for (int i = 1; i <= 12; i++)
            {
                var daysInMonth = DateTime.DaysInMonth(baseYear, i);
                for (int j = 1; j <= daysInMonth; j++)
                {

                    var fileName = string.Format("{0}{1:00}{2:00}.html", baseYear, i, j);

                    var thisDay = new DateTime(baseYear, i, j);
                    var yesterday = thisDay.AddDays(-1);
                    var tomorrow = thisDay.AddDays(+1);
                    var fileNameYesterday = "";
                    var fileNameTomorrow = "";

                    fileNameYesterday = string.Format("{0}{1:00}{2:00}.html", yesterday.Year, yesterday.Month, yesterday.Day);
                    fileNameTomorrow = string.Format("{0}{1:00}{2:00}.html", tomorrow.Year, tomorrow.Month, tomorrow.Day);

                    var builder = new StringBuilder();

                    builder.AppendLine(@"<!DOCTYPE html>");
                    builder.AppendLine("<html>");
                    builder.AppendLine("<head>");
                    builder.AppendLine("<meta charset='utf-8'>");
                    builder.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"chrome=1\">");

                    builder.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"../../stylesheets/stylesheet.css\" media=\"screen\">");
                    builder.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"../../stylesheets/github-dark.css\" media=\"screen\">");
                    builder.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"../../stylesheets/print.css\" media=\"print\">");
                    builder.AppendLine("</head>");
                    builder.AppendLine("<body>");

                    builder.AppendLine("<header>");
                    builder.AppendLine("<div class=\"container\">");
                    builder.AppendLine("<h1>" + thisDay.ToShortDateString() + "</h1>");
                    builder.AppendLine("</div>");
                    builder.AppendLine("</header>");

                    builder.AppendLine("<div class=\"container\">");
                    builder.AppendLine("<section id=\"main_content\">");

                    builder.AppendLine(@"<p><a href=""index.html""><< " + thisDay.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("pt")) +  "</a><br /></p>");
                    builder.AppendLine("[ ] Rezar uma vez ao dia <br /> <br />");
                    builder.AppendLine("[ ] Família <br /> <br />");
                    builder.AppendLine("[ ] Emagrecer <br /> <br />");
                    builder.AppendLine("[ ] Tese de Mestrado <br /> <br />");

                    if (fileNameYesterday != "" || fileNameTomorrow!= "")
                    {
                        builder.AppendLine(@"<p>");
                        if (fileNameYesterday != "")
                        {
                            if (thisDay.Month != yesterday.Month)
                                builder.AppendLine(string.Format("<a href=\"..\\{0:00}\\{1}\">ant.</a>", yesterday.Month, fileNameYesterday));
                            else
                                builder.AppendLine("<a href=\""  + fileNameYesterday + "\">ant.</a>");
                        }
                        if (fileNameTomorrow != "")
                        {
                            if (fileNameYesterday != "")
                            {
                                builder.AppendLine(" &nbsp;||&nbsp; ");
                            }
                            if (thisDay.Month != tomorrow.Month)
                                builder.AppendLine(string.Format("<a href=\"..\\{0:00}\\{1}\">próx.</a>", tomorrow.Month, fileNameTomorrow));
                            else
                                builder.AppendLine("<a href=\"" + fileNameTomorrow + "\">próx.</a>");
                        }
                        builder.AppendLine(@"</p>");
                    }


                    builder.AppendLine(@"</section></div></body></html>");
                    if (File.Exists(string.Format("{0}{1:00}\\{2}", basePath, i, fileName)))
                        File.Delete(string.Format("{0}{1:00}\\{2}", basePath, i, fileName));
                    Directory.CreateDirectory(string.Format("{0}{1:00}", basePath, i));
                    File.AppendAllText(string.Format("{0}{1:00}\\{2}", basePath, i, fileName), builder.ToString());

                }
            }
            
            /*
            var basePath = @"C:\Users\Sérgio\Source\minhasresolucoes.github.io\2017\";
            var baseYear = 2017;
            for (int i = 1; i <= 12; i++)
			{
                var daysInMonth = DateTime.DaysInMonth(baseYear, i);
                var fullMonthName = new DateTime(baseYear, i, 1).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("pt"));

                var builder = new StringBuilder();

                builder.AppendLine(@"<!DOCTYPE html>");
                builder.AppendLine(@"<html lang=pt-br>");
                builder.AppendLine(@"<meta charset=utf-8>");


                builder.AppendLine(@"<p><a href=""javascript:history.back(-1);"">Voltar</a><br /></p>");
                builder.AppendLine("");

                for (int j = 1; j <= daysInMonth; j++)
                {
                    var fileName = baseYear + String.Format("{0:00}", i) + String.Format("{0:00}", j) + ".html";

                    var fileName2 = new DateTime(baseYear, i, j).ToString("ddd", new System.Globalization.CultureInfo("pt-BR")) + ", " + String.Format("{0:00}", j) + " de " + fullMonthName + " de " + baseYear;

                    builder.AppendLine("<a href=\"" + fileName+ "\">" + fileName2 + "</a><br />");
                }

                builder.AppendLine(@"</html>");

                File.AppendAllText(basePath + String.Format("{0:00}", i) + @"\index.html", builder.ToString());
			}
             */ 
        }
    }
}
