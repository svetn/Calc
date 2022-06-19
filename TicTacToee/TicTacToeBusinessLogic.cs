using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeBusinessLogic
    {
        public static string Map = "|   |   |   |\n" +
                                   "|   |   |   |\n" +
                                   "|   |   |   |\n";

        public static string GameStatus = "Няма победител";

        void SetStatus(string Status)
        {
            GameStatus = Status;
        }

        public static void RestartGame()
        {
            Map = "|   |   |   |\n" +
                  "|   |   |   |\n" +
                  "|   |   |   |\n";

            GameStatus = "Няма победител";

            StepCounter = 0;
        }

        public void RunGameTicTacToe()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (NotEndOfGame)
            {
                Console.WriteLine(Map);
                Console.WriteLine(GameStatus);

                Console.Write("X: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Y: ");
                int y = int.Parse(Console.ReadLine());

                SetStatus("Няма победител");

                try
                {
                    oTicTacToeSystemLogic.IsValidPlayerPosition(x, y);
                    
                    oTicTacToeSystemLogic.MangePosition(
                        TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionIsValidPosition,
                        x,
                        y,
                        ref Map );
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    SetStatus(ex.Message);

                    continue;
                }

                oTicTacToeSystemLogic.MangePosition(TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer, x, y, ref Map);
                StepCounter++;

                TicTacToeSystemLogic.Players ePlayer = oTicTacToeSystemLogic.GetTheWinner(ref Map);
                if (ePlayer == TicTacToeSystemLogic.Players.PlayersPlayerO)
                {
                    SetStatus("O e победител");
                    NotEndOfGame = false;
                }

                if (ePlayer == TicTacToeSystemLogic.Players.PlayersPlayerX)
                {
                    SetStatus("X e победител");
                    NotEndOfGame = false;
                }

                if (StepCounter == 9 && 
                    oTicTacToeSystemLogic.GetTheWinner(ref Map) == TicTacToeSystemLogic.Players.PlayersPlayerNoWinner)
                {
                    SetStatus("Резултата е равен");
                    NotEndOfGame = false;
                }

                if (NotEndOfGame)
                    Console.Clear();
                else
                {
                    Console.Clear();
                    Console.WriteLine(Map);
                    Console.WriteLine(GameStatus);
                }
            }
        }

        public TicTacToeSystemLogic oTicTacToeSystemLogic = new TicTacToeSystemLogic();

        static bool NotEndOfGame = true;
        public static int StepCounter = 0;
    }
}
