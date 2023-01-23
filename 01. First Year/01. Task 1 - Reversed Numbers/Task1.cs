//INPUT
int inputNumber = int.Parse(Console.ReadLine());
int inputNumberLength = inputNumber.ToString().Length;

//CHANGEABLE

//ACTION
for (int i = inputNumberLength; i >= 1; i--)
{
    int lastDigit = inputNumber % 10;

    Console.WriteLine(lastDigit);

    inputNumber = (inputNumber - lastDigit) / 10;
}