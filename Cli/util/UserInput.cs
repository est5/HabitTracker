using HabitTrackerLib;

namespace Cli.util
{
    public static class UserInput
    {

        public static User CreateUser()
        {

            Console.Write("Enter name:");
            string input = Console.ReadLine()!;
            var user = new User();

            while (true)
            {
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Enter valid name:");
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
            Console.WriteLine("Select option...");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - View habit");
            Console.WriteLine("2 - Add habit");
            Console.WriteLine("3 - Delete habit");
            Console.WriteLine("4 - Update habit");
            Console.WriteLine("---");
        }

        public static Habit EnterNewHabit()
        {
            string habitName;
            int habitQuantity;
            string habitMeasurement;
            while (true)
            {
                Console.WriteLine("Enter the habit name: ");
                var input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Habit must have a name, plz try again");
                    continue;
                }
                habitName = input;

                Console.WriteLine("Enter a habit measurement(for example reps): ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Habit must have a measurement, plz try again");
                    continue;
                }
                habitMeasurement = input;
                break;
            }

            while (true)
            {

                Console.WriteLine("Enter a habit quantity(for example 10 push ups rep): ");
                try
                {
                    habitQuantity = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Enter an integer");
                    continue;
                }
                break;
            }

            Console.WriteLine("Enter a habit discription(can be empty): ");
            string? habitDiscription = Console.ReadLine();

            var habit = new Habit(habitQuantity, habitName, habitDiscription, habitMeasurement);
            return habit;
        }

    }
}
