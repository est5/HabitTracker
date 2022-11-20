using Cli.util;
using HabitTrackerLib;

var user = UserInput.CreateUser();
var db = new DBInMemory(user);

while (true)
{
    UserInput.DisplayMenu();
    try
    {
        int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 0: return;
            case 1:
                if (!db.IsHabitExists())
                {
                    Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                Console.WriteLine($@"
{user.Name} tracked habit:
Habit name: {user.UserHabit.Name}
Habit: {user.UserHabit.Quantity} ({user.UserHabit.Measurement})
Habit discription: {user.UserHabit.Discription}
                ");
                break;
            case 2:
                if (db.IsHabitExists())
                {
                    Console.WriteLine($"The habit already exists({user.UserHabit.Name}), you can delete or update the existing one, our supa cool app doesn't support more than 1. YET");
                    break;
                }
                db.AddHabit(UserInput.EnterNewHabit());
                break;
            case 3:
                Console.WriteLine("Not implemented ");
                break;
            case 4:
                Console.WriteLine("Not implemented ");
                break;

        }
    }
    catch (Exception)
    {
        Console.WriteLine("Enter number from 0 to 4");
    };


}
