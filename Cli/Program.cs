using Cli.util;
using HabitTrackerLib;
using HabitTrackerLib.DB;

var user = UserInput.CreateUser();
// swap db (sqlite/inmemory)
IDbOperations db = new DBInMemory(user);

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
                if (!db.IsHabitExists())
                {
                    Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                db.DeleteHabit();
                break;
            case 4:
                if (!db.IsHabitExists())
                {
                    Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                // db.EditHabit(user.UserHabit);
                Console.WriteLine($@"
{user.Name} tracked habit:
Habit name: {user.UserHabit.Name}
Habit: {user.UserHabit.Quantity} ({user.UserHabit.Measurement})
Habit discription: {user.UserHabit.Discription}
0 - exit | 1 - name | 2 - measurement | 3 - quantity | 4 - discription
                ");
                Console.WriteLine("Select field to edit");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Enter new name: ");
                            string nameInput = Console.ReadLine();
                            user.UserHabit.Name = nameInput;
                            db.EditHabit(user.UserHabit);
                            break;
                        case 2:
                            Console.WriteLine("Enter new measurement: ");
                            string measurementInput = Console.ReadLine();
                            user.UserHabit.Measurement = measurementInput;
                            db.EditHabit(user.UserHabit);
                            break;
                        case 3:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Enter new quantity: ");
                                    int quantityInput = Convert.ToInt32(Console.ReadLine());
                                    user.UserHabit.Quantity = quantityInput;
                                    db.EditHabit(user.UserHabit);
                                    return;
                                }
                                catch (System.Exception)
                                {
                                    Console.WriteLine("Please enter an integer");
                                    continue;
                                }
                            }
                        case 4:
                            Console.WriteLine("Enter new discription: ");
                            string discriptionInput = Console.ReadLine();
                            user.UserHabit.Discription = discriptionInput;
                            db.EditHabit(user.UserHabit);
                            break;
                        case 0:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Enter number from 0 to 4");

                }

                break;

        }
    }
    catch (Exception)
    {
        Console.WriteLine("Enter number from 0 to 4");
    };


}
