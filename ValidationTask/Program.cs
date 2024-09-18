namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "", lastName = "", username = "", password = "", emailAddress = "";
            int age = 0;

            // get the user inputs until all are valid.
            // The username should only be output once
            while (!ValidName(firstName))
            {

             Console.Write("Enter first name: ");
             firstName = Console.ReadLine();

            }
            while (!ValidName(lastName))
            {
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
            }
            while (!ValidAge(age))
            { 
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                
            }
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            Console.Write("Enter email address: ");
            emailAddress = Console.ReadLine();


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
               string character[i] = name.Substring(i, 1);
                int code = Convert.ToByte(character[i]);
                if (code < 65 || code > 121 || (90 < code && code < 97) )
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
            // Check password is at least 8 characters in length
            if (password.Length < 8) { return false; }


            // Check password contains a mix of lower case, upper case and non letter characters
            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid


            // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
            // AAbbdd!2 = valid (only 2 consecutive letters A and B and only 2 repeating of each)
            // abC461*+ = not valid (abC are 3 consecutive letters)
            // 987poiq! = not valid (987 are consecutive)



        }
        static bool validEmail(string email)
        {
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
