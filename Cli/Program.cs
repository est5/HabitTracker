using Cli.util;
using TimeLoggerLib;

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
                    System.Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                System.Console.WriteLine($@"
{user.Name} tracked habit:
Habit name: {user.UserHabit.Name}
Habit quantity: {user.UserHabit.Quantity}
Habit discription: {user.UserHabit.Discription}
                ");
                break;
            case 2:
                db.AddHabit(UserInput.EnterNewHabit());
                break;
            case 3:
                System.Console.WriteLine("Not implemented ");
                break;
            case 4:
                System.Console.WriteLine("Not implemented ");
                break;

        }
    }
    catch (System.Exception e)
    {
        System.Console.WriteLine("Enter number from 0 to 4");
        System.Console.WriteLine(e.Message);
    };


}
