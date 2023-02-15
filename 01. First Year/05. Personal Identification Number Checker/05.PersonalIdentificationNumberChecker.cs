using System;
using System.Text;
using System.Globalization;

public class PinValidation
{
    static void Main()
    {
        //INPUT
        string input = Console.ReadLine();
        char[] pinInput = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            pinInput[i] = input[i];
        }

        //OUTPUT
        if (PinChecker(pinInput))
        {
            Console.WriteLine("Your Personal Identification Number is valid!");
        }
        else
        {
            Console.WriteLine("Your Personal Identification Number is not valid!");
        }
    }

    //ACTION
    static bool PinChecker(char[] pin)
    {
        bool isValid = false;

        //Length Checker
        if (pin.Length == 10)
        {
            isValid = true;
        }
        else
        {
            isValid = false;
            return isValid;
        }

        //Symbols Checker
        for (int i = 0; i < pin.Length; i++)
        {
            if (pin[i] >= 48 && pin[i] <= 57)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                return isValid;
            }
        }

        //Date Checker
        string date = string.Empty;
        for (int j = 0; j < 6; j++)
        {
            //Kids after 1999
            if (j == 2)
            {
                if (pin[j] == 52)
                {
                    pin[j] = '0';
                }
                else if (pin[j] == 53)
                {
                    pin[j] = '1';
                }
            }
            date += ($"{pin[j].ToString()}");
            if (j % 2 == 1 && j != 5)
            {
                date += ("/");
            }
        }

        if (IsValidDate(date))
        {
            isValid = true;
        }
        else
        {
            isValid = false;
            return isValid;
        }

        return isValid;
    }

    //Date Checker
    static bool IsValidDate(string date)
    {
        DateTime tempObject;
        return DateTime.TryParseExact(date, "yy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempObject);
    }
}

//Направи проверка дали едно ЕГН е валидно с метод,
//който приема низ и връща булев резултат.

//Единният граждански номер (ЕГН) се състои от 10 цифри.
//Първите 6 цифри са дата на раждане (ГГ/ММ/ДД), следващите
//3 са поредност на раждането - число от 000 до 999 и
//десетата цифра е контролна.

//ЕГН-тата започват с последните две цифри (00 – лице родено в 2000 година,
//01 – лице родено в 2001 година и т.н.). Третата цифра (00Х, където Х
//е винаги 4) е контролна и проверява ЕГН. Четвъртата цифра е месеца
//(от 1-12, като ако лицето е родено между 10-12 месец, където са 2
//цифри, се прибавя +1 към Х, което прави третата цифра = 5 за лица
//родени от 10-12 месец). Петата и шестата цифра са датата на раждане
//(от 01-31). Последните 3 цифри са контролни за мъж/жена, град на
//раждане и отново проверка на ЕГН дали е валиден.
