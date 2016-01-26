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
            var basePath = @"C:\Users\sergio.rodrigues\source\minhasresolucoes.github.io\2016\";
            for (int i = 1; i <= 12; i++)
            {
                var daysInMonth = DateTime.DaysInMonth(2016, i);
                for (int j = 1; j <= daysInMonth; j++)
                {

                    var fileName = "2016" + String.Format("{0:00}", i) + String.Format("{0:00}", j) + ".html";
                    
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
                    builder.AppendLine("<div class=\"container\">");
                    builder.AppendLine("<section id=\"main_content\">");

                    builder.AppendLine(@"<p><a href=""javascript:history.back(-1);"">Voltar</a><br /></p>");
                    builder.AppendLine("[ ] Rezar de manhã <br /> <br />");
                    builder.AppendLine("[ ] Rezar de noite <br /> <br />");
                    builder.AppendLine("[ ] Á <br /> <br />");
                    builder.AppendLine("[ ] Exercícios <br /> <br />");
                    builder.AppendLine("[ ] Comer <br /> <br />");

                    builder.AppendLine(@"</section></div></body></html>");
                    File.Delete(basePath + String.Format("{0:00}", i) + @"\" + fileName);
                    File.AppendAllText(basePath + String.Format("{0:00}", i) + @"\" + fileName, builder.ToString());

                }
            }

            /*
            var basePath=@"C:\Users\sergio.rodrigues\source\minhasresolucoes.github.io\2016\";
            for (int i = 1; i <= 12; i++)
			{
                var daysInMonth = DateTime.DaysInMonth(2016, i);
                var fullMonthName = new DateTime(2016, i, 1).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("pt"));

                var builder = new StringBuilder();

                builder.AppendLine(@"<!DOCTYPE html>");
                builder.AppendLine(@"<html lang=pt-br>");
                builder.AppendLine(@"<meta charset=utf-8>");


                builder.AppendLine(@"<p><a href=""javascript:history.back(-1);"">Voltar</a><br /></p>");
                builder.AppendLine("");

                for (int j = 1; j <= daysInMonth; j++)
                {
                    var fileName = "2016" + String.Format("{0:00}", i) + String.Format("{0:00}", j) + ".html";

                    var fileName2 = new DateTime(2016, i, j).ToString("ddd", new System.Globalization.CultureInfo("pt-BR")) + ", " + String.Format("{0:00}", j) + " de " + fullMonthName + " de 2016";

                    builder.AppendLine("<a href=\"" + fileName+ "\">" + fileName2 + "</a><br />");
                }

                builder.AppendLine(@"</html>");

                File.AppendAllText(basePath + String.Format("{0:00}", i) + @"\index.html", builder.ToString());
			}
             */ 
        }
    }
}
