//INPUT
int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

//ACTION
int biggestNumber = int.MinValue;
int secondBiggestNumber = int.MinValue;

foreach (int number in inputArray)
{
    if (number > biggestNumber)
    {
        secondBiggestNumber = biggestNumber;
        biggestNumber = number;
    }
    else if (number > secondBiggestNumber)
    {
        secondBiggestNumber = number;
    }
}

//OUTPUT
Console.WriteLine($"The second biggest number is: {secondBiggestNumber}.");