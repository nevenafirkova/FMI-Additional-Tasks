using System;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Security.Claims;

public class PinValidation
{
    static void Main()
    {
        //INPUT
        string input = Console.ReadLine();
        char[] pinInput = new char[input.Length];

        string genderString = string.Empty;
        string birthArea = string.Empty;
        string bornDate = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            pinInput[i] = input[i];
        }

        //OUTPUT
        if (PinChecker(input, pinInput, ref genderString, ref birthArea, ref bornDate))
        {
            Console.WriteLine("This Personal Identification Number is valid!");
            Console.WriteLine($"The person owning it is a {genderString} born in {birthArea}, Bulgaria on {bornDate}.");
        }
        else
        {
            Console.WriteLine("This Personal Identification Number is not valid!");
        }
    }

    //ACTION
    static bool PinChecker(string input, char[] pin, ref string genderString, ref string birthArea,  ref string bornDate)
    {
        bool isValid = true;

        //LENGTH CHECKER
        if (pin.Length != 10)
        {
            isValid = false;
            return isValid;
        }

        //SYMBOLS CHECKER
        bool isAllDigits = pin.All(char.IsDigit);
        if (isAllDigits == false)
        {
            isValid = false;
            return isValid;
        }

        //DATE CHECKER
        string date = string.Empty;
        for (int j = 0; j < 6; j++)
        {
            date += ($"{pin[j].ToString()}");
            if (j % 2 == 1 && j != 5)
            {
                date += ("/");
            }
        }

        int[] pinDateArray = date.Split("/").Select(int.Parse).ToArray();

        //Kids Born After 1999
        int year = 0;
        if (pinDateArray[1] >= 40 && pinDateArray[1] < 50)
        {
            pinDateArray[1] -= 40;
            year = 2000 + pinDateArray[0];
        }
        else if (pinDateArray[1] >= 50 && pinDateArray[1] < 60)
        {
            pinDateArray[1] -= 50;
            year = 2000 + pinDateArray[0];
        }
        //Kids Born Before 1900
        else if (pinDateArray[1] >= 20 && pinDateArray[1] < 30)
        {
            pinDateArray[1] -= 20;
            year = 1800 + pinDateArray[0];
        }
        //Kids Born Before 2000 and after 1899
        else
        {
            year = 1900 + pinDateArray[0];
        }

        date = String.Join("/", pinDateArray);

        if (IsValidDate(date) == false)
        {
            isValid = false;
            return isValid;
        }
        else
        {
            DateTime dt = new DateTime(year, pinDateArray[1], pinDateArray[2]);
            bornDate = String.Format("{0:dddd, MMMM d, yyyy}", dt);
        }

        //BIRTH AREA
        string birthAreaNumbersString = String.Join("", pin[6], pin[7], pin[8]);
        int birthAreaNumbers = int.Parse(birthAreaNumbersString);

        if (birthAreaNumbers >= 0 && birthAreaNumbers <= 43)
        {
            birthArea = "Blagoevgrad";
        }
        else if (birthAreaNumbers >= 44 && birthAreaNumbers <= 93)
        {
            birthArea = "Burgas";
        }
        else if (birthAreaNumbers >= 94 && birthAreaNumbers <= 139)
        {
            birthArea = "Varna";
        }
        else if (birthAreaNumbers >= 140 && birthAreaNumbers <= 169)
        {
            birthArea = "Veliko Tarnovo";
        }
        else if (birthAreaNumbers >= 170 && birthAreaNumbers <= 183)
        {
            birthArea = "Vidin";
        }
        else if (birthAreaNumbers >= 184 && birthAreaNumbers <= 217)
        {
            birthArea = "Vratsa";
        }
        else if (birthAreaNumbers >= 218 && birthAreaNumbers <= 233)
        {
            birthArea = "Gabrovo";
        }
        else if (birthAreaNumbers >= 234 && birthAreaNumbers <= 281)
        {
            birthArea = "Kardzhali";
        }
        else if (birthAreaNumbers >= 282 && birthAreaNumbers <= 301)
        {
            birthArea = "Kyustendil";
        }
        else if (birthAreaNumbers >= 302 && birthAreaNumbers <= 319)
        {
            birthArea = "Lovech";
        }
        else if (birthAreaNumbers >= 320 && birthAreaNumbers <= 341)
        {
            birthArea = "Montana";
        }
        else if (birthAreaNumbers >= 342 && birthAreaNumbers <= 377)
        {
            birthArea = "Pazardzhik";
        }
        else if (birthAreaNumbers >= 378 && birthAreaNumbers <= 395)
        {
            birthArea = "Pernik";
        }
        else if (birthAreaNumbers >= 396 && birthAreaNumbers <= 435)
        {
            birthArea = "Pleven";
        }
        else if (birthAreaNumbers >= 436 && birthAreaNumbers <= 501)
        {
            birthArea = "Plovdiv";
        }
        else if (birthAreaNumbers >= 502 && birthAreaNumbers <= 527)
        {
            birthArea = "Razgrad";
        }
        else if (birthAreaNumbers >= 528 && birthAreaNumbers <= 555)
        {
            birthArea = "Ruse";
        }
        else if (birthAreaNumbers >= 556 && birthAreaNumbers <= 575)
        {
            birthArea = "Silistra";
        }
        else if (birthAreaNumbers >= 576 && birthAreaNumbers <= 601)
        {
            birthArea = "Sliven";
        }
        else if (birthAreaNumbers >= 602 && birthAreaNumbers <= 623)
        {
            birthArea = "Smolyan";
        }
        else if (birthAreaNumbers >= 624 && birthAreaNumbers <= 721)
        {
            birthArea = "Sofia";
        }
        else if (birthAreaNumbers >= 722 && birthAreaNumbers <= 751)
        {
            birthArea = "Sofia area";
        }
        else if (birthAreaNumbers >= 752 && birthAreaNumbers <= 789)
        {
            birthArea = "Stara Zagora";
        }
        else if (birthAreaNumbers >= 790 && birthAreaNumbers <= 821)
        {
            birthArea = "Dobrich";
        }
        else if (birthAreaNumbers >= 822 && birthAreaNumbers <= 843)
        {
            birthArea = "Targovishte";
        }
        else if (birthAreaNumbers >= 844 && birthAreaNumbers <= 871)
        {
            birthArea = "Haskovo";
        }
        else if (birthAreaNumbers >= 872 && birthAreaNumbers <= 903)
        {
            birthArea = "Shumen";
        }
        else if (birthAreaNumbers >= 904 && birthAreaNumbers <= 925)
        {
            birthArea = "Yambol";
        }
        else if (birthAreaNumbers >= 926 && birthAreaNumbers <= 999)
        {
            birthArea = "place unknown";
        }

        //GENDER
        int gender = int.Parse(pin[8].ToString());
        genderString = string.Empty;

        if (gender % 2 == 0)
        {
            genderString = "male";
        }
        else
        {
            genderString = "female";
        }

        //LAST CONTROL NUMBER
        int[] pinInt = Array.ConvertAll(pin, n => (int)Char.GetNumericValue(n));

        int controlNumber = ((pinInt[0]*2) + (pinInt[1]*4) + (pinInt[2]*8) + (pinInt[3]*5) + (pinInt[4]*10) + (pinInt[5]*9) + (pinInt[6]*7) + (pinInt[7]*3) + (pinInt[8]*6));

        double fraction = (double)controlNumber / 11.0;
        int fractionInt = controlNumber / 11;
        double remainder = Math.Ceiling((fraction - fractionInt) * 10);

        double controlNumberFinal = 0;
        if (remainder < 10)
        {
            controlNumberFinal = remainder;
        }
        else if (remainder == 0 || remainder == 10)
        {
            controlNumberFinal = 0;
        }
        else
        {
            controlNumberFinal = controlNumber - (fraction * fraction);
        }

        if (controlNumberFinal != pinInt[9])
        {
            isValid = false;
            return isValid;
        }

        //OUTPUT
        return isValid;
    }

    //Date Checker
    static bool IsValidDate(string date)
    {
        DateTime tempObject;
        return DateTime.TryParseExact(date, "y/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempObject);
    }
}

//УСЛОВИЕ
//Направи проверка дали едно ЕГН е валидно с метод,
//който приема низ и връща булев резултат.


//НАРЕДБА № РД-02-20-9 ОТ 21 МАЙ 2012 Г. ЗА ФУНКЦИОНИРАНЕ НА ЕДИННАТА СИСТЕМА ЗА ГРАЖДАНСКА РЕГИСТРАЦИЯ

//Формиране на единен граждански номер
//Чл. 104. (1) Единните граждански номера (ЕГН) се формират автоматизирано
//за всяка календарна година от Главна дирекция "ГРАО".


//(2) Единният граждански номер се състои от десет цифри и се формира по следния начин:

//1.първите шест цифри показват датата на раждане на лицето; изписват се последователно
//последните две цифри от годината, две цифри за месеца и две цифри за деня на раждане;

//2.седма, осма и девета цифра представляват уникална комбинация от цифри за деня - число
//от 000 до 999; деветата цифра обозначава пола на лицето - тя е четна за мъж и нечетна за жена;

//3.десетата цифра е контролна и се изчислява по следния начин:
//На всяка от деветте цифри от ЕГН, започвайки от най-лявата надясно, се определят следните
//коефициенти: 2, 4, 8, 5, 10, 9, 7, 3 и 6. Всяка от деветте цифри на ЕГН се умножава по
//съответния коефициент и получените произведения се сумират. Сумата от произведенията се
//дели на 11. Полученият остатък е контролна цифра, която е нула при остатък 0 или 10.

//(3) Единният граждански номер за лицата, родени до 31 декември 1899 г. включително, се формира
//по реда на ал. 2, като към числото на месеца се прибавя числото 20, за родените от 1 януари 2000 г.
//до 31 декември 2099 г. включително се прибавя числото 40.
