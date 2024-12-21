using System;

namespace Demo
{
    internal class Program
    {
        // Method to demonstrate basic operations with error handling
        static void DoSomeCode()
        {
            int X, Y, Z;
            try
            {
                // Input parsing
                X = int.Parse(Console.ReadLine());
                Y = int.Parse(Console.ReadLine());

                // Division by zero handling
                Z = X / Y;

                // Array handling
                int[] Arr = { 1, 2, 3 };

                // Attempting to assign value to an out-of-bounds index
                Arr[99] = 10;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: Array index out of bounds.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid input format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                // This block will always execute
                Console.WriteLine("Execution of code completed (finally block).");
            }
        }

        // Method with input validation and division logic
        static void DoSomeProtectiveCode()
        {
            int X, Y, Z;
            bool Flag;

            try
            {
                // Get valid input for X
                do
                {
                    Console.Write("Enter First Number: ");
                    Flag = int.TryParse(Console.ReadLine(), out X); // Corrected TryParse syntax
                    if (!Flag)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                } while (Flag == false);

                // Get valid input for Y
                do
                {
                    Console.Write("Enter Second Number: ");
                    Flag = int.TryParse(Console.ReadLine(), out Y); // Corrected TryParse syntax
                    if (!Flag)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                } while (Flag == false);

                // You can now use X and Y safely for further logic
                Console.WriteLine($"You entered X: {X}, Y: {Y}");

                // Example of division to possibly raise an exception (e.g., DivideByZeroException)
                Z = X / Y;
                Console.WriteLine($"Result of division: {Z}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                // This block will always execute, useful for cleanup or final messages
                Console.WriteLine("Execution completed.");
            }
        }

        // Enum representing days of the week
        enum WeekDay
        {
            Saturday,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        // Enum representing seasons with byte underlying type
        enum Season : byte
        {
            Spring = 10,
            Winter = 100,
            Summer = 200,
            Autumn = 300
        }

        // Enum representing Gender
        enum Gender
        {
            M,
            F
        }

        // Enum representing Permissions using Flags
        [Flags]
        enum Permissions
        {
            Read = 8,
            Write = 4,
            Execute = 2,
            Delete = 1
        }

        // Class to represent an Employee
        class Employee
        {
            private int id;
            private Gender G;
        }

        static void Main(string[] args)
        {
            #region Boxing & Unboxing
            // Boxing and UnBoxing
            // Boxing: Casting From ValueType To ReferenceType
            // UnBoxing: Casting From ReferenceType To ValueType

            object obj;

            // Boxing
            obj = 1; // int to object
            obj = "Ahmed"; // string to object
            obj = 3; // int to object
            obj = 1.5; // double to object
            obj = 'A'; // char to object
            obj = true; // bool to object
            obj = new DateTime(); // DateTime to object

            int x = 5;
            object boxedX = x; // Implicit Casting (int to object) => Boxing

            // UnBoxing Example
            object boxedObj = 3; // Boxing
            int unboxedX = (int)boxedObj; // Explicit Casting (object to int) => UnBoxing
            #endregion

            #region Nullable Value Types
            // Nullable Types

            int? age = 20;
            age = null;

            double? salary = 4000.5;
            salary = null;

            // Implicit Casting to Nullable
            int xValue = 5;
            int? yNullable = xValue; // Nullable<int>

            // Explicit Casting from Nullable to Non-Nullable
            int? xNullable = 5;
            xNullable = null;

            int yValue;

            // Defensive Code for UnBoxing
            if (xNullable is not null)
                yValue = (int)xNullable;
            else
                yValue = 0;

            Console.WriteLine(yValue);

            // Using Null Coalescing Operator ??
            yValue = xNullable ?? 0; // Default to 0 if null
            Console.WriteLine(yValue);
            #endregion

            #region Nullable Reference Type [C# 10.0 .NET 6.0]
            // Nullable Reference Type [C# 10.0 .NET 6.0]
            string? Message02 = null;
            Console.WriteLine(Message02); // Allows null
            #endregion

            #region Null Propagation and Null Safety
            // Null Propagation Operator and Best Practices

            int[] Arr = default; // null

            // Using null safety checks before accessing the array
            if (Arr is not null)
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    Console.WriteLine(Arr[i]);
                }
            }
            else
            {
                Console.WriteLine("Array is null.");
            }

            // Using null propagation operator for safe access
            int? arrayLength = Arr?.Length;
            int safeLength = arrayLength ?? -1; // Default to -1 if null
            Console.WriteLine($"Array Length: {safeLength}");
            #endregion

            #region Exception Handling
            // Exception types
            // SystemException
            // 1.1 FormatException
            // 1.2 IndexOutOfRangeException
            // 1.3 NullReferenceException
            // 1.4 ArithmeticException
            // 1.4.1 OverflowException
            // 1.4.2 DivideByZeroException
            // 2. ApplicationException
            #endregion

            #region Access Modifiers & Class Structure
            // Access Modifiers: C# Keywords Indicate Accessibility Scope
            // 1. private
            // 2. private protected
            // 3. protected
            // 4. internal
            // 5. internal protected
            // 6. public

            // What Can Be Written Inside The Namespace?
            // 1. Class
            // 2. Struct
            // 3. Interface
            // 4. Enum

            // Access Modifiers Inside The Namespace:
            // 1. internal Inside The Same Project
            // 2. public : Everywhere
            // Default Access Modifier Inside The Namespace "Internal"

            // Access Modifiers Inside The Class:
            // 1. private
            // 2. private protected
            // 3. protected
            // 4. internal
            // 5. internal protected
            // 6. public

            // Default Access Modifier Inside The Class "private"

            // What Can Be Written Inside The Interface?
            // 1. Signature Of Methods [Return Type Name Parameter]
            // 2. Signature Of Property
            // 3. Default Implemented Methods [C# 8.0 .NET Core 3.1]
            // All Access Modifiers Except "private"
            // Default Access Modifier Inside The Interface "public"
            #endregion

            #region Enum Usage Example
            // Enum: Value Types
            Season S01 = Season.Autumn;
            S01 = Season.Summer;
            Console.WriteLine(S01);

            // Gender Example
            Gender G01 = Gender.M;
            Console.WriteLine(G01);
            #endregion

            #region Permissions Example
            Permissions Per01 = Permissions.Read | Permissions.Delete;
            Console.WriteLine(Per01); // Delete, Read

            // Toggling permissions
            Per01 ^= Permissions.Delete; // Toggle Delete
            Console.WriteLine(Per01); // Read

            // Checking if a permission exists
            if ((Per01 & Permissions.Delete) == Permissions.Delete)
            {
                Console.WriteLine("Delete permission exists.");
            }
            else
            {
                Console.WriteLine("Delete permission does not exist.");
            }
            #endregion
        }
    }
}
