using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        private static string[] MONTHS = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        private static int[] DAYS = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private static int[] STARTDATE = { 2, 6, 6, 3, 1, 5, 3, 7, 4, 2, 6, 4 }; //start on friday

        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("index.html", false);

            sw.WriteLine("<!DOCTYPE html>\n<html>" + t(1) + "\n" + css() + t(1) + "<body>");
            sw.WriteLine(t(2) + "<table border=\"1\" bordercolor=white>"); //calendar table
            int day, monthLength, nextMonth;

            for (int i = 0; i < MONTHS.Length; i++)
            {
                if (i % 2 == 0 || i == 0)
                    sw.WriteLine(t(3) + "<tr>");
                sw.WriteLine(t(4) + "<td>");
                sw.WriteLine(t(5) + "<div class=\"title\"><p>" + MONTHS[i] + "</p></div>");
                sw.WriteLine(t(5) + "<table border=\"1\">"); //month table
                sw.WriteLine(t(6) + "<tr><th>Fri</th><th>Sat</th><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th></tr>");
                day = STARTDATE[i]; //keep track of date
                monthLength = DAYS[i];

                //month
                while (day <= monthLength)
                {
                    nextMonth = 1;
                    //week
                    sw.Write(t(6) + "<tr>");
                    for (int k = 0; k < 7; k++)
                    {
                        if (day > monthLength) //finished month?
                        {
                            sw.Write("<td>" + nextMonth + "</td>");
                            nextMonth++;
                        }
                        else
                        {
                            sw.Write("<td>" + day + "</td>");
                            day++;
                        }
                    }
                    sw.Write("</tr>\n");
                }
                sw.WriteLine(t(5) + "</table>");
                sw.WriteLine(t(4) + "</td>");
                if (i % 2 != 0) sw.WriteLine(t(3) + "</tr>\n");
            }
            sw.WriteLine(t(2) + "</table>");
            sw.WriteLine(t(1) + "</body>");
            sw.Write("</html>");
            sw.Close();
        }

        private static string t(int n)
        {//formatting
            string ANS = "";
            for (int i = 0; i < n; i++)
            {
                ANS += "   ";
            }
            return ANS;
        }

        private static string css()
        {
            string c = "\n<head>\n" +
            t(1) + "<title>Calendar 2015</title>\n" +
            t(1) + "<style type=\"text/css\">\n\n" +

            //month titles
            t(2) + "div.title {\n" +
            t(3) + "font-family: verdana, sans-serif;\n" +
            t(3) + "text-align: left;\n" +
            t(3) + "font-size: 20px;\n" +
            t(3) + "background-color: white;\n" +
            t(3) + "color: maroon;\n" +
            t(2) + "}\n\n" +

            //tables
            t(2) + "table {\n" +
            t(3) + "table-layout: fixed;\n" +
            t(3) + "border-collapse: collapse;\n" +
            t(2) + "}\n\n" +

            //days of week
            t(2) + "th {\n" +
            t(3) + "font: Verdana, sans-serif;\n" +
            t(3) + "font-size: 16px;\n" +
            t(3) + "width: 30px;\n" +
            t(3) + "padding: 0.6em;\n" +
            t(3) + "text-align: center;\n" +
            t(3) + "background-color: #9d9d9d;\n" +
            t(3) + "color: white;\n" +
            t(2) + "}\n\n" +

            //dates
            t(2) + "td {\n" +
            t(3) + "font: verdana, sans-serif;\n" +
            t(3) + "font-size: 20px;\n" +
            t(3) + "padding: 0.5em;\n" +
            t(3) + "text-align: center;\n" +
            t(3) + "vertical-align: top;\n" +
            t(3) + "color: green;\n" +
            t(3) + "postion: relative;\n" +
            t(2) + "}\n\n" +

            t(1) + "</style>\n" +
            t(1) + "</head>\n";
            return c;
        }
    }
}