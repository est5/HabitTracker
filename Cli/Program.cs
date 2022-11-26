using Cli.util;
using HabitTrackerLib;
using HabitTrackerLib.DB;

var db = new DBSqlite();
// Goto label from user creation
createUsr: var user = UserInput.CreateUser();

if (!db.IsUserExists(user.Name!))
{
    db.AddUser(user);
}
else
{
    while (true)
    {
        try
        {

            Console.WriteLine("User exists");
            Console.WriteLine($"0 - exit | 1 - create new | 2 - continue with {user.Name}");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 0: return;
                case 1: goto createUsr;
                case 2: goto usrCreated;
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Please input an integer");
            continue;
        }
    }
}

usrCreated:
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
                if (!db.IsHabitExists(user.Name))
                {
                    Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                var usrModel = db.GetUserInfo(user.Name);
                Console.WriteLine($@"
{usrModel.UserName} tracked habit:
Habit name: {usrModel.HabitName}
Habit: {usrModel.Quantity} ({usrModel.Measurement})
Habit discription: {usrModel.Discription}
                ");
                break;
            case 2:
                if (db.IsHabitExists(user.Name))
                {
                    Console.WriteLine($"The habit already exists, you can delete or update the existing one, our supa cool app doesn't support more than 1.");
                    break;
                }
                db.AddHabit(UserInput.EnterNewHabit(), user);
                break;
            case 3:
                if (!db.IsHabitExists(user.Name))
                {
                    Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                db.DeleteHabit(user.Name);
                break;
            case 4:
                if (!db.IsHabitExists(user.Name))
                {
                    Console.WriteLine($"\n~~~No habit for user {user.Name}~~~\n");
                    break;
                }
                var usrEditModel = db.GetUserInfo(user.Name);
                var usrHabit = new Habit((int)usrEditModel.Quantity,
                                         usrEditModel.HabitName,
                                         usrEditModel.Discription,
                                         usrEditModel.Measurement);
                Console.WriteLine($@"
{usrEditModel.UserName} tracked habit:
Habit name: {usrEditModel.HabitName}
Habit: {usrEditModel.Quantity} ({usrEditModel.Measurement})
Habit discription: {usrEditModel.Discription}
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
                            usrHabit.Name = nameInput;
                            db.UpdateHabit(usrHabit, user);
                            break;
                        case 2:
                            Console.WriteLine("Enter new measurement: ");
                            string measurementInput = Console.ReadLine();
                            usrHabit.Measurement = measurementInput;
                            db.UpdateHabit(usrHabit, user);
                            break;
                        case 3:
                            var flag = true;
                            while (flag)
                            {
                                try
                                {
                                    Console.WriteLine("Enter new quantity: ");
                                    int quantityInput = Convert.ToInt32(Console.ReadLine());
                                    usrHabit.Quantity = quantityInput;
                                    db.UpdateHabit(usrHabit, user);
                                    flag = false;
                                }
                                catch (System.Exception)
                                {
                                    Console.WriteLine("Please enter an integer");
                                    continue;
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter new discription: ");
                            string discriptionInput = Console.ReadLine();
                            usrHabit.Discription = discriptionInput;
                            db.UpdateHabit(usrHabit, user);
                            break;
                        case 0:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter number from 0 to 4");
                    System.Console.WriteLine(e.Message);

                }

                break;

        }
    }
    catch (Exception)
    {
        Console.WriteLine("Enter number from 0 to 4");
    };


}
