using System;

namespace Part1_Assignment
{
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    enum Gender
    {
        M,
        F
    }

    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        Delete = 8
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Test Case

            // Test Case for Boxing & Unboxing
            object obj = 3; // Boxing
            int unboxedX = (int)obj; // Unboxing
            Console.WriteLine($"Unboxed value (Expected 3): {unboxedX}");

            // Test Case for Nullable Value Types
            int? age = 20;
            int yValue = age ?? 0; // Using null-coalescing operator
            Console.WriteLine($"Nullable Age value (Expected 20): {yValue}");

            // Test Case for Nullable Reference Type
            string? message02 = null;
            Console.WriteLine($"Nullable Message (Expected null): {message02}");

            // Test Case for Null Propagation and Null Safety
            int[] arr = null;
            int? arrayLength = arr?.Length;
            int safeLength = arrayLength ?? -1;
            Console.WriteLine($"Array Length using null propagation (Expected -1): {safeLength}");

            // Test Case for Enum Usage Example
            Season currentSeason = Season.Summer;
            Console.WriteLine($"Current Season (Expected Summer): {currentSeason}");
            Gender currentGender = Gender.M;
            Console.WriteLine($"Gender (Expected M): {currentGender}");

            // Test Case for Permissions Example
            Permissions userPermissions = Permissions.Read | Permissions.Delete;
            Console.WriteLine($"User Permissions (Expected Read, Delete): {userPermissions}");
            userPermissions ^= Permissions.Delete; // Toggle off Delete
            Console.WriteLine($"Updated Permissions (Expected Read): {userPermissions}");
            bool hasDeletePermission = (userPermissions & Permissions.Delete) == Permissions.Delete;
            Console.WriteLine($"Has Delete Permission (Expected False): {hasDeletePermission}");

            // Test Case for Exception Handling (Divide by Zero)
            try
            {
                int result = 10 / 0;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error (Expected 'Attempted to divide by zero.'): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            #endregion

            #region Boxing & Unboxing
            // Boxing and UnBoxing
            // Boxing: Casting From ValueType To ReferenceType
            // UnBoxing: Casting From ReferenceType To ValueType

            object obj2;

            // Boxing (ValueType -> ReferenceType)
            obj2 = 1; // int to object (Boxing)
            obj2 = "Ahmed"; // string to object (Boxing)
            obj2 = 3; // int to object (Boxing)
            obj2 = 1.5; // double to object (Boxing)
            obj2 = 'A'; // char to object (Boxing)
            obj2 = true; // bool to object (Boxing)
            obj2 = new DateTime(); // DateTime to object (Boxing)

            int x = 5;
            object boxedX = x; // Implicit Casting (int to object) => Boxing

            // UnBoxing Example (ReferenceType -> ValueType)
            object boxedObj = 3; // Boxing
            int unboxedX = (int)boxedObj; // Explicit Casting (object to int) => Unboxing

            Console.WriteLine($"Unboxed value: {unboxedX}"); // Output: 3
            #endregion

            #region Nullable Value Types
            // Nullable Types can hold null values
            // int? and double? are nullable types that can store null

            int? ageNullable = 20; // Nullable integer with value 20
            ageNullable = null; // Nullable integer set to null

            double? salaryNullable = 4000.5; // Nullable double with a value
            salaryNullable = null; // Nullable double set to null

            // Implicit Casting to Nullable Types
            int xValue = 5;
            int? yNullable = xValue; // Nullable<int>

            // Explicit Casting from Nullable to Non-Nullable
            int? xNullable = 5;
            xNullable = null;

            int yValue;

            // Defensive Code for UnBoxing (Safe Casting)
            if (xNullable is not null)
                yValue = (int)xNullable; // Unboxing safely
            else
                yValue = 0; // Default value when null

            Console.WriteLine($"yValue after checking nullable: {yValue}");

            // Using Null Coalescing Operator ?? to provide default values
            yValue = xNullable ?? 0; // Default to 0 if null
            Console.WriteLine($"yValue using ?? operator: {yValue}"); // Output: 0
            #endregion

            #region Nullable Reference Type [C# 10.0 .NET 6.0]
            // Nullable Reference Types: Allows reference types to be nullable explicitly.
            // In C# 8.0+, nullable reference types feature ensures better null safety.

            string? message02Test = null; // Nullable reference type (string can be null)
            Console.WriteLine($"Message02: {message02Test}"); // Output: null
            #endregion

            #region Null Propagation and Null Safety
            // Null Propagation Operator (?.) allows safe access to properties/methods that might be null
            // Null safety checks help prevent NullReferenceException.

            int[] arrTest = null; // Default to null

            // Using null safety checks before accessing the array
            if (arrTest is not null)
            {
                for (int i = 0; i < arrTest.Length; i++)
                {
                    Console.WriteLine(arrTest[i]); // Will not run, as arr is null
                }
            }
            else
            {
                Console.WriteLine("Array is null."); // Output: Array is null.
            }

            // Using null propagation operator (?.) to safely access properties
            int? arrayLengthTest = arrTest?.Length; // Safe access to Length property (if arr is not null)
            int safeLengthTest = arrayLengthTest ?? -1; // Default to -1 if arr is null
            Console.WriteLine($"Array Length: {safeLengthTest}"); // Output: -1 (as arr is null)
            #endregion

            #region Enum Usage Example
            // Enums are value types that represent named constants
            // Here, we define a "Season" enum and a "Gender" enum.

            Season currentSeasonTest = Season.Summer;
            Console.WriteLine($"Current Season (Expected Summer): {currentSeasonTest}");
            Gender currentGenderTest = Gender.M;
            Console.WriteLine($"Gender (Expected M): {currentGenderTest}");
            #endregion

            #region Permissions Example
            // Using the Flags attribute allows us to combine enum values with bitwise operations
            // This is useful for representing multiple permissions or flags.

            Permissions userPermissionsTest = Permissions.Read | Permissions.Delete;
            Console.WriteLine($"User Permissions (Expected Read, Delete): {userPermissionsTest}");
            userPermissionsTest ^= Permissions.Delete; // Toggle off Delete
            Console.WriteLine($"Updated Permissions (Expected Read): {userPermissionsTest}");
            bool hasDeletePermissionTest = (userPermissionsTest & Permissions.Delete) == Permissions.Delete;
            Console.WriteLine($"Has Delete Permission (Expected False): {hasDeletePermissionTest}");

            #endregion

            #region Exception Handling
            // Exception handling allows you to catch and handle errors gracefully.
            // We handle common exceptions like FormatException, DivideByZeroException, etc.

            try
            {
                // Trying to divide by zero
                int result = 10 / 0;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                // Handling divide by zero error
                Console.WriteLine($"Error: {ex.Message}"); // Output: Attempted to divide by zero.
            }
            catch (Exception ex)
            {
                // Handling other general exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            #endregion
        }
    }
}
