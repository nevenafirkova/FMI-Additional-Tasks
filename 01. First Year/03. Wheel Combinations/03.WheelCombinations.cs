//INPUT
int wheelsSum = int.Parse(Console.ReadLine());

//ACTION
int carWheels = 4;
int truckWheels = 6;
int motorcycleWheels = 3;

//Combinations Checker
for (int i = 0; i <= wheelsSum / 4; i++)
{
    carWheels *= i;
    for (int j = 0; j <= wheelsSum / 6; j++)
    {
	 truckWheels *= j;
	 for (int k = 0; k <= wheelsSum / 3; k++)
	 {
             motorcycleWheels *= k;

             if (wheelsSum == carWheels + truckWheels + motorcycleWheels)
             {
	     //OUTPUT
             Console.WriteLine($"{carWheels/4} {truckWheels/6} {motorcycleWheels/3}");
             }
	     motorcycleWheels = 3;
         }  
         truckWheels = 6;
    }
    carWheels = 4;
}

//Група разузнавачи трябвало да проучат състоянието на автопарка на противника.
//За целта те проникнали в базата и установили, че противниците притежават леки
//автомобили (с по 4 колела), товарни автомобили (с по 6 колела) и мотори с кош
//(с по 3 колела). Те внимателно преброили превозните средства и установили, че
//общият брой колела е N, след което ги описали. За съжаление при изтеглянето
//разузнавачите попаднали на засада и се наложило да прекосят река, при което
//част от документацията се намокрила и се загубила важна информация. Когато
//прегледали останалата част, установили, че се чете ясно само броят на колелата.
//За да се възстанови информацията, се наложило да се напише програма, която намира
//всички различни комбинации на трите вида превозни средства за определения брой
//колела. Тъй като програмистът на групата бил много болен (много силно настинал
//при преминаването на реката) се налага вие да им помогнете, като напишете програма,
//която прочита от клавиатурата цялото число N (3 < N < 50) и отпечатва на отделни
//редове на екрана различните комбинации на превозните средства, като ги подрежда
//така: на първо място броя на леките автомобили, на второ – броя на товарните
//автомобили и на трето – броя на моторите с кош."   

//Пример: Вход: 16
//Изход:
//1 0 4
//1 1 2
//1 2 0
//4 0 0
