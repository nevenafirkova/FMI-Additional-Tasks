//INPUT
int inputNumber = int.Parse(Console.ReadLine());

//CHANGEABLE
int currentNumber = inputNumber;

//ACTION
while (currentNumber > 0)
{
    int lastDigit = currentNumber % 10;

    Console.WriteLine(lastDigit);

    currentNumber = (currentNumber - lastDigit) / 10;
}