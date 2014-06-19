using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SigninSignup
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        const string PATH = "d:/data/sign.txt";
        struct Account {
            public string email;
            public string password;
        }

        static void Main(string[] args)
        {
            run();
            Console.ReadKey(false);
        }
        static void run()
        {
            bool booloop = true;
            do
            {
                Console.WriteLine("[C]reate an account or [S]ign in :");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'c':
                    case 'C':
                        signUp();
                        break;
                    case 's':
                    case 'S':
                        signIn();
                        break;
                    case '\u001b':
                        booloop = false;
                        break;
                    default:
                        break;
                }
            }
            while (booloop);

        }

        static void signUp()
        {
            Account acc;
            bool booloop = true;
            string email, password;
            Console.WriteLine("\nSign Up");
            do
            {
                if (displayForm(out email, out  password))
                {
                    if (checkSignUp(email))
                    {
                        acc.email = email;
                        acc.password = password;
                        saveAccount(acc);
                        booloop = false; ;
                    }
                    else
                    {
                        Console.WriteLine("Email already used ...");
                    }
                }
                else
                {
                    Console.WriteLine("Canceled...");
                    booloop = false; ;
                }
            }
            while (booloop);
        }

        static void signIn()
        {
            Account acc;
            bool booloop = true;
            string email,password;
            Console.WriteLine("\nSign In");
            do
            {
                if (displayForm(out email, out password))
                {
                    if (checkSignIn(email, password))
                    {
                        acc.email = email;
                        acc.password = password;
                        booloop = false; ;
                    }
                }
                else
                {
                    Console.WriteLine("Canceled...");
                    booloop = false; ;
                }
            }
            while (booloop);
        }

        static bool displayForm(out string email,out string password)
        {
            email = catchEmail();
            password = catchPassword();

            Console.WriteLine("[V]alidate/[C]ancel");
            return Console.ReadKey(true).KeyChar == 'V' ? true:false;
        }

        static string catchEmail()
        {
            Console.Write("Email : ");
            
            return Console.ReadLine();
        }
        
        static string catchPassword()
        {
            Console.Write("Password : ");

            return Console.ReadLine();
        }

        static bool checkSignIn(string email,string password)
        {
            return checkEmail(email, password);
        }

        static bool checkSignUp(string email)
        {
            return !checkEmail(email);

        }

        static bool checkEmail(string email,string password ="")
        {
            bool find = false;
            StreamReader sr=null;
            string parsedEmail, parsedPassword;
            try
            {
                sr = File.OpenText(PATH);
                while (!find && !sr.EndOfStream)
                {
                    parsedEmail = sr.ReadLine();
                    parsedPassword = sr.ReadLine();
                    if (parsedEmail == email & password == "") find = true;
                    else if (parsedEmail == email && parsedPassword == password) find = true;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Can't find email > No file for registering found at : " + PATH);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString() + " on file : " + PATH);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return find;
        }

        static void saveAccount(Account acc)
        {
            StreamWriter sw = null;
            try
            {
                sw = File.AppendText(PATH);
                sw.WriteLine(acc.email);
                sw.WriteLine(acc.password);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Can't save this account > No storage file found at : " + PATH);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't save this account > " + e.ToString() + " on file : " + PATH);
            }
            finally
            {
                if(sw != null) sw.Close();
            }
        }
        
    }
}
