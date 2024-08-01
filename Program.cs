using System;
namespace PatikaProje1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mini oyunumuza hoşgeldiniz!"); // Just a greeting line for our game. 
            Console.WriteLine("Aşağıdaki üç oyundan birini seçerek dilediğiniz gibi oynayabilirsiniz! \n (1) Rastgele Sayı Bulma Oyunu \n (2) Hesap Makinesi \n (3) Ortalama Hesaplama"); // Main menu concept. They will choose the game with this map.
            Console.WriteLine("Başlamak için bir numara giriniz.");
            string option = Console.ReadLine();
            switch (option)  // With global methods we can make our code blocks more clear. Also we can build more complex structures.
            {
                case "1":
                    RandomNumberGame();
                    break;
                case "2":
                    CalculatorGame();
                    break;
                case "3":
                    AverageCalculate();
                    break;
                default:
                    Console.WriteLine("Geçerli bir değer giriniz");
                    break;
            }
        }

        // Random Number app.
        static void RandomNumberGame()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);  // Making random number
            Console.WriteLine("Bilgisayarınız 1 ile 100 arasında bir sayı tutacak lütfen sayıyı bulmaya çalışın. Tahmin hakkınız 5tir iyi eğlenceler!");
            int userHealthBar = 5; // We are giving 5 chance to our user from beggining.
            while (userHealthBar > 0)
            {
                Console.WriteLine("Tahmininizi giriniz");
                int userGuess;
                bool isValidGuess = int.TryParse(Console.ReadLine(), out userGuess); // I am using TryParse for advanced error handling and signing the result to userGuess integer.
                if (!isValidGuess || userGuess < 1 || userGuess > 100) // Handling the games edges
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz");
                }
                if (userGuess == randomNumber)
                {
                    Console.WriteLine("Tebrikler doğru bildiniz!");
                    continue;
                }
                else if (userGuess > randomNumber)
                {
                    Console.WriteLine("Daha küçük bir sayı deneyin");
                }
                else
                {
                    Console.WriteLine("Daha büyük bir sayı deneyin");
                }
                userHealthBar--;
                if (userHealthBar >= 1)
                {
                    Console.WriteLine($"Kalan hakkınız {userHealthBar}");
                }
                else
                {
                    Console.WriteLine($"Hakkınız doldu! Doğru sayı: {randomNumber}");
                }
            }
        }

        // Calculator app.
        static int CalculatorGame()  // Calculator game method
        {
            Console.WriteLine("Hesap makinasına hoşgeldiniz");
            Console.WriteLine("Birinci sayıyı giriniz");
            int numOne = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("İkinci sayıyı giriniz");
            int numTwo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yapmak istediğiniz işlemi giriniz \n + - * /");
            char inputOfUser = Convert.ToChar(Console.ReadLine()); // We want char type because it fits the just one place for our input.
            int result = 0;  // At the beginning result is null. It will be changed with type of calculation.
            bool validResult = true;  // This would help us to showing result.
            switch (inputOfUser)
            {
                case '+':
                    result = numOne + numTwo;
                    break;
                case '-':
                    result = numOne - numTwo;
                    break;
                case '*':
                    result = numOne * numTwo;
                    break;
                case '/':
                    if (numTwo != 0)
                    {
                        result = numOne / numTwo;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("İkinci sayı 0 olamaz");  // Math rule. 
                        result = 0;
                        validResult = false;  // For not showing the final writing.
                        break;
                    }
                default:
                    Console.WriteLine("Geçersiz işlem seçtiniz.");
                    validResult = false;  // Same reason as for the else statement.
                    return 0;
            }
            if (validResult)
            {
                Console.WriteLine($"Sonuç {result}");
            }
            return result;
        }

        // Average Calculating
        static void AverageCalculate()
        {
            Console.WriteLine("Birinci notu giriniz");
            double firstNote = double.Parse(Console.ReadLine()); // I didn't use TryParse just for not having boolean work to do
            Console.WriteLine("İkinci notu giriniz");
            double secondNote = double.Parse(Console.ReadLine());
            Console.WriteLine("Üçüncü sayıyı giriniz");
            double thirdNote = double.Parse(Console.ReadLine());

            double avarageNote = (firstNote + secondNote + thirdNote) / 3.0;  // Using double for double options

            string letterNote;  // We gonna use later we can describe in here

            if (firstNote < 1 || firstNote > 100)
            {
                Console.WriteLine("Geçerli bir not giriniz birinci notu yanlış girdiniz");
                return;
            }
            else if (secondNote < 1 || secondNote > 100)
            {
                Console.WriteLine("Geçerli bir not giriniz ikinci notu yanlış girdiniz");
                return;
            }
            else if (thirdNote < 1 || thirdNote > 100)
            {
                Console.WriteLine("Geçerli bir not giriniz üçüncü notu yanlış girdiniz");
                return;
            }

            Console.WriteLine($"Ortalamanızın puan karşılığı: {avarageNote}");

            if (avarageNote >= 90)
            {
                letterNote = "AA";
            }
            else if (avarageNote >= 85) { letterNote = "BA"; }
            else if (avarageNote >= 80) { letterNote = "BB"; }
            else if (avarageNote >= 75) { letterNote = "CB"; }
            else if (avarageNote >= 70) { letterNote = "CC"; }
            else if (avarageNote >= 65) { letterNote = "DC"; }
            else if (avarageNote >= 60) { letterNote = "DD"; }
            else if (avarageNote >= 55) { letterNote = "FD"; }
            else { letterNote = "FF"; }

            Console.WriteLine($"Ortalamanızın harf karşılığı: {letterNote}");
        }


    }
}