using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            InitiazizeIntroText()
                .Wait();

            int? userInputNum = UserInputChecker()
                .Result;

            UserInputListener(userInputNum)
                .Wait();
        }

        private static async Task InitiazizeIntroText()
        {
            SeperationLine()
                .Wait();

            Console.WriteLine("---------------------------------FOEDSELSDAGS INVITATION!----------------------------------------\n");

            SeperationLine()
                .Wait();

            Console.WriteLine("Hej x\n");
            Console.WriteLine("Du er inviteret til min 30 års foedselsdag d. 01/02-2020\n");
            Console.WriteLine("Jeg glæder mig meget til at se dig! :-)\n");
            Console.WriteLine("Hvor foregår det?\n");
            Console.WriteLine("På: Emiliehøj 16, 1, mf. 8270 Hoejbjerg\n");
            Console.WriteLine("\n\n");

            YourNextMoveText()
                .Wait();

            await Task.CompletedTask;
        }

        private static async Task YourNextMoveText()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Tast 1 for gaveliste. Tast 2 for mere info, eller tast 0 for at afslutte\n");

            await Task.CompletedTask;
        }

        private static async Task<int?> UserInputChecker()
        {
            int? userInputNum = null;

            while (userInputNum > 2 || userInputNum == null)
            {
                userInputNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if (userInputNum < 3)
                {
                    break;
                }

                Console.WriteLine("Jeg forstod ikke dit svar prøv igen?\n");
                Console.WriteLine("Tast 1 for gaveliste. Tast 2 for mere info eller tast 0 for at afslutte\n");
            }

            return await Task.FromResult(userInputNum);
        }

        private static async Task SeperationLine()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n");

            await Task.CompletedTask;
        }

        private static async Task UserInputListener(int? userInputNum)
        {
            switch (userInputNum)
            {
                case 1:
                    Console.WriteLine("\n\n");

                    SeperationLine()
                        .Wait();

                    Console.WriteLine("----------------------Du tastede 1 og kan nu se hvad Simon ønsker sig:---------------------------\n");

                    SeperationLine()
                        .Wait();

                    ReadTxtFile();

                    YourNextMove()
                        .Wait();

                    break;
                case 2:
                    Console.WriteLine("\n\n");

                    SeperationLine()
                        .Wait();

                    Console.WriteLine("---------------------------------Du tastede 2 for mere info:-------------------------------------\n");

                    SeperationLine()
                        .Wait();

                    YourNextMove()
                        .Wait();

                    break;
                default:
                    UserInputChecker()
                        .Wait();

                    break;
            }

            await Task.CompletedTask;
        }

        private static async Task YourNextMove()
        {
            YourNextMoveText()
                .Wait();

            int? userInputNum = UserInputChecker()
                .Result;

            await Task.CompletedTask;

            UserInputListener(userInputNum).Wait();
        }

        private static void ReadTxtFile()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using StreamReader sr = new StreamReader("birthdayWishes.txt");
                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.ReadLine();
            }

            string allines = sb.ToString();

            Console.WriteLine(allines);
        }
    }
}