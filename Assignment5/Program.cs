namespace Assignment5
{
    internal class Program
    {
        #region Part 2
        // Question 1: Enum for Weekdays
        enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        // Question 2: Enum for Seasons
        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        // Question 3: Enum for Permissions
        [Flags]
        enum Permissions
        {
            None = 0,
            Read = 1,
            Write = 2,
            Delete = 4,
            Execute = 8
        }

        // Question 4: Enum for Colors
        enum Colors
        {
            Red,
            Green,
            Blue
        }

        static void Main(string[] args)
        {
            #region Question 1: Printing all days of the week
            Console.WriteLine("Days of the week:");
            foreach (var day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }
            #endregion

            #region Question 2: Season and corresponding month range
            Console.WriteLine("\nEnter a season (Spring, Summer, Autumn, Winter):");
            string seasonInput = Console.ReadLine();
            if (Enum.TryParse(seasonInput, true, out Season selectedSeason))
            {
                switch (selectedSeason)
                {
                    case Season.Spring:
                        Console.WriteLine("Spring: March to May");
                        break;
                    case Season.Summer:
                        Console.WriteLine("Summer: June to August");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("Autumn: September to November");
                        break;
                    case Season.Winter:
                        Console.WriteLine("Winter: December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season entered.");
            }
            #endregion

            #region Question 3: Permissions management
            Permissions userPermissions = Permissions.Read | Permissions.Write;
            Console.WriteLine("\nCurrent Permissions: " + userPermissions);

            // Adding a permission
            userPermissions |= Permissions.Execute;
            Console.WriteLine("After adding Execute: " + userPermissions);

            // Removing a permission
            userPermissions &= ~Permissions.Write;
            Console.WriteLine("After removing Write: " + userPermissions);

            // Checking for a specific permission
            bool hasDeletePermission = (userPermissions & Permissions.Delete) == Permissions.Delete;
            Console.WriteLine("Has Delete Permission: " + hasDeletePermission);
            #endregion

            #region Question 4: Checking if a color is primary
            Console.WriteLine("\nEnter a color (Red, Green, Blue):");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out Colors selectedColor))
            {
                Console.WriteLine($"{selectedColor} is a primary color.");
            }
            else
            {
                Console.WriteLine("The entered color is not a primary color.");
            }
            #endregion
        }
        #endregion


    }
}
