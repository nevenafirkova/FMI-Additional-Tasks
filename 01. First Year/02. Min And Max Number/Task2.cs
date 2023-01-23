//INPUT
ushort inputNumber = ushort.Parse(Console.ReadLine());

//CHANGEABLE
ushort biggestNumber = ushort.MinValue;
ushort smallestNumber = ushort.MaxValue;

//ACTION
while (inputNumber != 0)
{
	if (inputNumber > biggestNumber)
	{
		biggestNumber = inputNumber;
	}
	if (inputNumber < smallestNumber)
	{
		smallestNumber = inputNumber;
	}
	inputNumber = ushort.Parse(Console.ReadLine());
}

//OUTPUT
Console.WriteLine($"Biggest number is: {biggestNumber}");
Console.WriteLine($"Smallest number is: {smallestNumber}");

//На вход постъпва поредица от цели положителни числа между 1 и 30000, 
//като не се знае предварително колко е дълга поредицата (тя може да е
//толкова дълга, че да не се събира в паметта на компютъра). Знае се
//обаче, че всяко число е на отделен ред и че поредицата завършва с 
//числото 0. Напишете програма, която намира максималното и минималното
//число от поредицата. Входните данни се четат от клавиатурата. На всеки
//ред имаме по едно цяло положително число между 1 и 30000 – поредният
//елемент от поредицата. Входът задължително завършва с ред, съдържащ
//числото 0. Резултатът се извежда на екрана. На първия ред се извежда
//намереният максимален елемент от поредицата, а на втори ред се извежда
//намереният минимален елемент от поредицата.
