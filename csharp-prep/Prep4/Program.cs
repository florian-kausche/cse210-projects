using System;

{
    List<int> numbers = new List<int>();
    int inputNumber;

    Console.WriteLine("Enter a list of numbers, type 0 when finished.");

    do
    {
        Console.Write("Enter number: ");
        inputNumber = int.Parse(Console.ReadLine());

        if (inputNumber != 0)
        {
            numbers.Add(inputNumber);
        }
    } while (inputNumber != 0);

    int sum = 0;
    foreach (int number in numbers)
    {
        sum += number;
    }
    double average = sum / (double)numbers.Count;

    int maxNumber = int.MinValue;
    foreach (int number in numbers)
    {
        if (number > maxNumber)
        {
            maxNumber = number;
        }
    }

    Console.WriteLine($"The sum is: {sum}");
    Console.WriteLine($"The average is: {average}");
    Console.WriteLine($"The largest number is: {maxNumber}");

    int minPositiveNumber = int.MaxValue;
    foreach (int number in numbers)
    {
        if (number > 0 && number < minPositiveNumber)
        {
            minPositiveNumber = number;
        }
    }

    if (minPositiveNumber != int.MaxValue)
    {
        Console.WriteLine($"The smallest positive number is: {minPositiveNumber}");
    }
    else
    {
        Console.WriteLine("There are no positive numbers in the list.");
    }
    numbers.Sort();
    Console.WriteLine("The sorted list is:");
    foreach (int number in numbers)
    {
        Console.WriteLine(number);
    }
}
