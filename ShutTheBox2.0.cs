using System.ComponentModel.Design;

namespace ShutTheBox
{
    class ShutTheBoxX
    {
        static void Main()
        {
            int[] flaps = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Random rnd = new Random();
            Console.WriteLine("Shut the Box CLI!");
            Thread.Sleep(100);
            Console.WriteLine("After rolling the dice, the player can choose to flip down any combination of tiles on the board that add up to the total rolled on the dice. For example, if the dice show 4 and 2 (totaling 6), the player can flip down tiles numbered 6, 5 and 1, 4 and 2, 3 and 3, or simply the tile numbered 6. The aim is to shut the box by flipping all 12 levers.");
            Console.ReadLine();
            int Dice1;
            int Dice2;
            int Score = 0;
            int WinLose = 0;
            while (WinLose == 0)
            {
                BoxStatus(flaps);
                Dice1 = rnd.Next(1, 7);
                Dice2 = rnd.Next(1, 7);
                int Dice3 = (Dice1) + (Dice2);
                Console.WriteLine("Dice: " + Dice3);
                Console.Write("Assign individually or combine? (1 or 2): ");
                int Decision1 = Convert.ToInt16(Console.ReadLine());
                int input1=0;
                int input2=0;
                if (Decision1 == 1) {
                    Console.Write("What is the first number would you like to use?: ");
                    input1 = Int32.Parse(Console.ReadLine());
                    Console.Write("What is the second number would you like to use?: ");
                    input2 = Int32.Parse(Console.ReadLine());
                    if (input1 + input2 != Dice3) {
                        WinLose = 3;
                    }
                }
                bool Survive = Determine(Decision1, input1, input2, flaps, Dice3);
                if (!Survive)
                {
                    WinLose = 2;
                }
                else if ((flaps[1] + flaps[2] + flaps[3] + flaps[4] + flaps[5] + flaps[6] + flaps[7] + flaps[8] +
                            flaps[9] + flaps[10] + flaps[11] + flaps[12]) == 12)
                {
                    WinLose = 1;
                }
                Score++;
            }

            switch (WinLose)
            {
                case 1:
                    Console.WriteLine("You win! You shut the box!");
                    break;
                case 2:
                    Console.WriteLine("You lose... play again! Score: " + Score);
                    break;
                case 3:
                    Console.WriteLine("You cheated. Not ok. Score: -666");
                    break;
                default:
                    Console.WriteLine("Unknown Error");
                    break;
            }

            Console.ReadLine();
        }

        static bool Determine(int Decision1, int input1, int input2, int[] flaps, int dice3)
        {
            if (Decision1 == 2) {
                if (flaps[(dice3 - 1)] == 0) {
                    flaps[dice3 -1] = 1;
                    return true;
                } else {
                    return false;
                }
            } else if (Decision1 == 1) {
                if (flaps[input1-1] == 0 && flaps[input2-1] == 0) {
                    flaps[input1-1] = 1;
                    flaps[input2-1] = 1;
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
        static void BoxStatus(int[] flaps)
        {
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine((i + 1) + ". " + Convert.ToString(flaps[i]));
            }
        }
    }
}