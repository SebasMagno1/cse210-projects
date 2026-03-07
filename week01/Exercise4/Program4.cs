using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
                numbers.Add(input);
        } while (input != 0);

        // Sum
        int sum = 0;
        foreach (int num in numbers)
            sum += num;
        Console.WriteLine($"\nThe sum is: {sum}");

        // Average
        double average = (numbers.Count > 0) ? (double)sum / numbers.Count : 0;
        Console.WriteLine($"The average is: {average}");

        // Maximum
        int max = int.MinValue;
        foreach (int num in numbers)
            if (num > max)
                max = num;
        Console.WriteLine($"The largest number is: {max}");
    }
}