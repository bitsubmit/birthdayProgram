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
            ReadTxtFile("txt/seperationLine.txt")
                    .Wait();

            ReadTxtFile("txt/title.txt")
                    .Wait();

            ReadTxtFile("txt/seperationLine.txt")
                    .Wait();

            ReadTxtFile("txt/introBody.txt")
                    .Wait();

            YourNextMoveText()
                .Wait();

            await Task.CompletedTask;
        }

        private static async Task YourNextMoveText()
        {
            Console.WriteLine("\n");

            ReadTxtFile("txt/commands.txt")
                    .Wait();

            await Task.CompletedTask;
        }

        private static async Task<int?> UserInputChecker()
        {
            int? userInputNum = null;

            while (userInputNum > 2 || userInputNum == null)
            {
                userInputNum = Convert.ToInt32(Console.ReadLine());

                if (userInputNum == 0)
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("\n");

                if (userInputNum < 3)
                {
                    break;
                }

                ReadTxtFile("txt/errorMsg.txt")
                    .Wait();

                ReadTxtFile("txt/commands.txt")
                    .Wait();
            }

            return await Task.FromResult(userInputNum);
        }

        private static async Task UserInputListener(int? userInputNum)
        {
            switch (userInputNum)
            {
                case 1:
                    ReadTxtFile("txt/seperationLine.txt")
                    .Wait();

                    ReadTxtFile("txt/userSelectedOne.txt")
                    .Wait();

                    ReadTxtFile("txt/seperationLine.txt")
                    .Wait();

                    ReadTxtFile("txt/birthdayWishes.txt")
                        .Wait();

                    YourNextMove()
                        .Wait();
                    break;
                case 2:
                    ReadTxtFile("txt/seperationLine.txt")
                        .Wait();

                    ReadTxtFile("txt/userSelectedTwo.txt")
                    .Wait();

                    ReadTxtFile("txt/seperationLine.txt")
                        .Wait();

                    ReadTxtFile("txt/moreInfo.txt")
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

            UserInputListener(userInputNum)
                .Wait();
        }

        private static async Task ReadTxtFile(string src)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using StreamReader sr = new StreamReader(src);
                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            string allines = sb.ToString();

            Console.WriteLine(allines);
            await Task.CompletedTask;
        }
    }
}