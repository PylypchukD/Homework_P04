using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Напишите консольное приложение, позволяющие пользователю зарегистрироваться под «Логином», состоящем только из символов латинского алфавита, и пароля, состоящего из цифр и символов.
             */

            var regexLogin = new Regex(@"[A-Za-z]");
            var regexPassword = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])");

            Console.WriteLine("Введiть логiн (тiльки латинськi букви): ");
            string login = Console.ReadLine();

            bool successLogin = regexLogin.IsMatch(login);
            if (successLogin)
                Console.WriteLine("Логiн корректний.");
            else
                Console.WriteLine("Логiн не корректний. Ваш логiн User");

            Console.WriteLine("Введiть пароль (тiльки цифри та символи): ");
            string password = Console.ReadLine();

            bool successPassword = regexPassword.IsMatch(password);
            if (successPassword)
                Console.WriteLine("Пароль корректний.");
            else
                Console.WriteLine("Пароль не корректний. Ваш пароль Password123");

            Console.ReadKey();
        }
    }
}
