// See https://aka.ms/new-console-template for more information


Random rnd = new Random();
int randomNumber = rnd.Next(1, 100);

Console.WriteLine(randomNumber);

int count = 0;
while (true)
{
    count++;
    Console.WriteLine("Aklımdan tuttuğum sayıyı tahmin et bakalım : ");
    int guessNumber = int.Parse(Console.ReadLine());

    if(guessNumber>0 && guessNumber < 100)
    {
        if (randomNumber == guessNumber)
        {
            Console.WriteLine("DOĞRU TAHMİNNN.");
            Console.WriteLine("Aklımdan tuttuğum sayı " + randomNumber + " idi.");
            Console.WriteLine(count + " Tahminde doğru sayıyı bulması başardın BRAVO");
            break;
        }
        else if (randomNumber > guessNumber)
        {
            Console.WriteLine("Daha yüksek bir sayı tahmin etmen gerekiyor");
        }
        else if (randomNumber < guessNumber)
        {
            Console.WriteLine("Daha düşük bir sayı tahmin etmen gerekiyor");
        }
    }
    else
    {
        Console.WriteLine("0 ile 100 arasında bir sayı girmelisin");
    }

   
}

Console.WriteLine("GAME OVER");

