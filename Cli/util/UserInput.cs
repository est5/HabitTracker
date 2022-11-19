using TimeLoggerLib;

namespace Cli.util
{
    public static class UserInput
    {

        public static User CreateUser()
        {

            System.Console.Write("Enter name:");
            string input = Console.ReadLine()!;
            var user = new User();

            while (true)
            {
                if (String.IsNullOrWhiteSpace(input))
                {
                    System.Console.WriteLine("Enter valid name:");
                    input = Console.ReadLine()!;
                }
                else
                {
                    user.Name = input;
                    user.UserHabit = null;
                    break;
                }
            }

            return user;


        }

        public static void DisplayMenu()
        {
            System.Console.WriteLine("Select option...");
            System.Console.WriteLine("0 - Exit");
            System.Console.WriteLine("1 - View habit");
            System.Console.WriteLine("2 - Add habit");
            System.Console.WriteLine("3 - Update habit");
            System.Console.WriteLine("4 - Delete habit");
            System.Console.WriteLine("---");
        }

        public static Habit EnterNewHabit()
        {
            string habitName;
            int habitQuantity;
            while (true)
            {
                System.Console.WriteLine("Enter habit name: ");
                var input = System.Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    System.Console.WriteLine("Habit must have name, plz try again");
                    continue;
                }
                habitName = input;
                break;
            }

            while (true)
            {

                System.Console.WriteLine("Enter habit quantity(for example 10 push ups/day): ");
                try
                {
                    habitQuantity = Convert.ToInt32(System.Console.ReadLine());
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Enter integer");
                    continue;
                }
                break;
            }

            System.Console.WriteLine("Enter habit discription(can be empty): ");
            string? habitDiscription = System.Console.ReadLine();

            var habit = new Habit(habitQuantity, habitName, habitDiscription);
            return habit;
        }

    }
}