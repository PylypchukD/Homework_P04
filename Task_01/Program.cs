using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Напишите программу, которая бы позволила вам по указанному адресу web-страницы выбирать все ссылки на другие страницы, номера телефонов, почтовые адреса и сохраняла полученный результат в файл. 
             */

            var regexLink = new Regex(@"(https?:\/\/|ftps?:\/\/|www\.)((?![.,?!;:()]*(\s|$))[^\s]){2,}");
            var regexPhone = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

            var file = new FileStream("Homework.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var writer = new StreamWriter(file, Encoding.GetEncoding(1251));


            string text = GetCode("https://rozetka.com.ua/");

            writer.WriteLine("Links: ");
            int count = 0;
            for (Match m = regexLink.Match(text); m.Success; m = m.NextMatch())
            {
                writer.WriteLine(m.Value);
                if (count == 10)
                {
                    break;
                }
                count++;
            }

            writer.WriteLine("Phone: ");
            count = 0;
            for (Match m = regexPhone.Match(text); m.Success; m = m.NextMatch())
            {
                writer.WriteLine(m.Value);
                if (count == 10)
                {
                    break;
                }
                count++;
            }
            writer.Close();
            Console.ReadKey();
        }
        public static String GetCode(string urlAddress)
        {
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            return data;
        }

    }
}
