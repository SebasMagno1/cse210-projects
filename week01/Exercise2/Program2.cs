using System;

class Program
{
    static void Main()
    {
        // Step 1: Ask the user for their grade percentage
        Console.Write("Enter your grade percentage (0-100): ");
        int grade = int.Parse(Console.ReadLine());

        // Step 2: Determine the letter grade
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Step 3 (Optional Stretch): Determine + or - sign
        string sign = "";
        if (letter != "F") // F has no + or -
        {
            int lastDigit = grade % 10;

            if (letter == "A" && grade >= 100) // No A+ (optional protection)
            {
                sign = "";
            }
            else if (letter == "A" && lastDigit >= 7)
            {
                sign = "-"; // A- for 97-99
            }
            else if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            // else sign remains empty
        }

        // Step 4: Display the grade
        Console.WriteLine($"\nYour grade is: {letter}{sign}");

        // Step 5: Determine pass/fail
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't worry! Keep studying and you'll do better next time.");
        }
    }
}