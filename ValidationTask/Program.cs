using System.Xml.Linq;

namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "x", lastName = "x", username = "x", password = "x", emailAddress = "x";
            int age = 0;

            // get the user inputs until all are valid.
            // The username should only be output once
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine() ?? "";
            while (!ValidName(firstName))
            {

             Console.Write("Enter first name: ");
             firstName = Console.ReadLine();

            }
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            while (!ValidName(lastName))
            {
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
            }
            Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
            while (!ValidAge(age))
            { 
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                
            }
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            while (!ValidPassword(password))
            {
             Console.Write("Enter Password: ");
             password = Console.ReadLine();
            }
            Console.Write("Enter email address: ");
            emailAddress = Console.ReadLine();
            while (!ValidEmail(emailAddress))
            {
                Console.Write("Enter email address: ");
                emailAddress = Console.ReadLine();
            }

            username = createUserName(firstName,lastName,age);
            Console.WriteLine($"Username is {username}, you have successfully registered please remember your password");

            //  Test your program with a range of tests to show all validation works
            // Show your evidence in the Readme

        }
        static bool ValidName(string name)
        {
            int i = 0;
            // name must be at least two characters and contain only letters
            for (i = 0; i < name.Length; i++)
            {
               string character = name.Substring(i, 1);
                int code = Convert.ToByte(character);
                if (code < 65 || code > 122 || (90 < code && code < 97) )
                {
                    return false;
                }
            }
            if (name.Length < 2) { return false; }  
            return true;
        }

        static bool ValidAge(int age)
        {
            //age must be between 11 and 18 inclusive
            if (age <= 18 && age >= 11)
            {
                return true;
            } else
            {
                return false;
            }

        }

   
        static bool ValidPassword(string password)
        {
            bool checkUpCase = false;
            bool checkLowCase = false;
            bool checkNonLetter = false;
            // Check password is at least 8 characters in length
            if (password.Length < 8) { return false; }
            for (int i = 0; i < password.Length; i++)
            {
                int code = Convert.ToByte(password.Substring(i, 1));
                if (code >= 65 && code <= 90)
                {
                    checkUpCase = true;
                }
                if (code >= 97 && code <= 122)
                {
                    checkLowCase = true;
                }
                if ((code > 32 && code < 65) || code > 122 || (90 < code && code < 97))
                {
                    checkNonLetter = true;
                }
            }
            if (!checkUpCase || !checkLowCase || !checkNonLetter) 
            {
                return false;
            }

            // Check password contains a mix of lower case, upper case and non letter characters
            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid

            for (int i = 0; i < password.Length - 2 ; i++)
            {
               int a = Convert.ToInt32(Convert.ToByte(password[i]));
               int b = Convert.ToInt32(Convert.ToByte(password[i + 1]));
               int c = Convert.ToInt32(Convert.ToByte(password[i + 2]));
               if ((((a >= 65 && a <= 90) || (a >= 97 && a <= 122)) && ((b >= 65 && b <= 90) || (b >= 97 && b <= 122)) && ((c >= 65 && c <= 90) || (c >= 97 && c <= 122)))
                    && ((a + 1 == b && (b + 1 == c || b + 33 == c || b - 31 == c)) || (a + 33 == b && (b + 1 == c || b - 31 == c)) || (a - 31 == b && (b + 33 == c || b + 1 == c)))
                    || ((a - 1 == b && (b - 1 == c || b + 31 == c || b - 33 == c)) || (a + 31 == b && (b - 1 == c || b - 33 == c)) || (a - 33 == b && (b + 31 == c || b - 1 == c)))
                    || ((a == b && (b == c || b + 32 == c || b - 32 == c)) || (a + 32 == b && (b == c || b - 32 == c)) || (a - 32 == b && (b + 32 == c || b == c))))             
                {
                    return false;
                }
               
               else if (((a >= 48 && a <= 57) && (b >= 48 && b <= 57) && (c >= 48 && c <= 57)) && ((a + 1 == b && b + 1 == c) || (a - 1 == b && b - 1 == c) || (a == b && b == c)))
                {
                    return false;
                }
            }
            return true;
                // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
                // AAbbdd!2 = valid (only 2 consecutive letters A and B and only 2 repeating of each)
                // abC461*+ = not valid (abC are 3 consecutive letters)
                // 987poiq! = not valid (987 are consecutive)



        }
        static bool ValidEmail(string email)
        {
            int positionAt = 0;
            int countDot = 0;
            int countAt = 0;
            int[] positionDots = new int[email.Length - 3];
            for (int i = 0; i < email.Length; i++)
            {
                int c = Convert.ToInt32(Convert.ToByte(email[i]));
                if (c == 64) 
                {
                    countAt++;
                    positionAt = i;
                }
                if (c == 46) 
                {
                    if (countDot < positionDots.Length) 
                    {
                        positionDots[countDot] = i;
                        countDot++;
                    }
                }
                if ((c > 32 && c < 65) || c > 122 || (c > 90 && c < 97) && c != 64 && c!= 46)
                {
                    return false;
                }
            }
            if( countAt != 1 || countDot < 1)
            {
                return false;
            }
            if (positionAt < 2 || positionAt > email.Length - 3)
            {
                return false;
            }
            if ( positionDots[0] < 2 )
            {
                return false;
            }
            for (int i = 0; i < countDot - 1; i++ )
            {
                if (positionDots[i] - positionAt < 3 && positionDots[i] - positionAt > -3)
                {
                    return false;
                }
                if (positionDots[i + 1] - positionDots[i] < 3 && positionDots[i + 1] - positionDots[i] > -3)
                {
                    return false;
                }
            }
            return true;
            // a valid email address
            // has at least 2 characters followed by an @ symbol
            // has at least 2 characters followed by a .
            // has at least 2 characters after the .
            // contains only one @ and any number of .
            // does not contain any other non letter or number characters

        }
        static string createUserName(string firstName, string lastName, int age)
        {
            string username = firstName.Substring( 0 , 2) + lastName.Substring( 0 , 2 ) + Convert.ToString(age);

            return username;

        }

    }
}
