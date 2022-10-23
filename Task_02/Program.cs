using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы заменить все предлоги на слово «ГАВ!». 
             */

            string text = "Когда человек сознательно или интуитивно выбирает себе в жизни какую-то цель, жизненную задачу, он невольно дает себе оценку. По тому, ради чего человек живет, можно судить и о его самооценке - низкой или высокой.";
            string pattern = @"\b[а-я]{1,3}\b";
            
            string result = Regex.Replace(text, pattern, "ГАВ!");


            Console.WriteLine(result);

            // Задержка.
            Console.ReadKey();

        }
    }
}
