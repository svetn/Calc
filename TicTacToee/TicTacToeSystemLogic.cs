using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeSystemLogic
    {
        public enum Players : ushort
        {
            PlayersPlayerX = 1,
            PlayersPlayerO = 2,

            // NoWinner
            PlayersPlayerNoWinner = 3
        };

        public enum ManagePositionAction
        {
            ManagePositionActionIsValidPosition     = 1,
            ManagePositionActionDrawPlayer          = 2,
        };

        public bool IsValidPlayerPosition(int x, int y)
        {
            if (x > XMAX || x < 0)
            {
                throw (new IndexOutOfRangeException("IndexOutOfRangeException X:" + x.ToString()));
            }

            if (y > YMAX || y < 0)
            {
                throw (new IndexOutOfRangeException("IndexOutOfRangeException Y:" + y.ToString()));
            }

            return true;
        }

        public int MangePosition(ManagePositionAction eManagePositionAction, int x, int y, ref string map)
        {
            int index = 0;

            switch (y)
            {
                case 1:
                {
                    index = 14;
                }
                break;

                case 2:
                {
                    index = 28;
                }
                break; 
            }


            switch (x)
            {
                case 0:
                {
                    if (eManagePositionAction == ManagePositionAction.ManagePositionActionIsValidPosition)
                    {
                        if(map[2 + index] != ' ')
                           throw (new InvalidOperationException("InvalidOperationException Index " + index.ToString()));

                        index = index + 2;
                    }
                    else if (eManagePositionAction == ManagePositionAction.ManagePositionActionDrawPlayer)
                    {
                         DrawPlayerPosition(ref ePlayer, 2 + index, ref map); 
                    }
                }
                break;

                case 1:
                {
                    if (eManagePositionAction == ManagePositionAction.ManagePositionActionIsValidPosition)
                    {
                        if(map[6 + index] != ' ')
                            throw (new InvalidOperationException("InvalidOperationException Index " + index.ToString()));

                        index = index + 6;
                    }
                    else if (eManagePositionAction == ManagePositionAction.ManagePositionActionDrawPlayer)
                    {
                        DrawPlayerPosition(ref ePlayer, 6 + index, ref map); 
                    }
                }
                break;

                case 2:
                {
                    if (eManagePositionAction == ManagePositionAction.ManagePositionActionIsValidPosition)
                    {
                        if(map[10 + index] != ' ')
                            throw (new InvalidOperationException("InvalidOperationException Index " + index.ToString()));

                        index = index + 10;
                    }
                    else if (eManagePositionAction == ManagePositionAction.ManagePositionActionDrawPlayer)
                    {
                        DrawPlayerPosition(ref ePlayer, 10 + index, ref map);
                    }
                }
                break;
            } 

            return index;
        }

        public void DrawPlayerPosition(ref Players ePlayer, int mapIndex, ref string map)
        {
            switch (ePlayer)
            {
                case Players.PlayersPlayerO:
                {
                    var newMap = new StringBuilder(map);
                    newMap[mapIndex] = CurrentPlayer; 
                    map = newMap.ToString(); 

                    ePlayer = Players.PlayersPlayerX;
                    CurrentPlayer = 'X';
                }
                break;

                case Players.PlayersPlayerX:
                {
                    var newMap = new StringBuilder(map);
                    newMap[mapIndex] = CurrentPlayer; 
                    map = newMap.ToString();

                    ePlayer = Players.PlayersPlayerO;
                    CurrentPlayer = 'O';
                }
                break;
            }
        }

        public Players GetTheWinner(ref string map)
        {
            for (Players i = Players.PlayersPlayerX; i <= Players.PlayersPlayerO; i++) 
            {
                char chPlayer = 'X';
                if (i == Players.PlayersPlayerO)
                    chPlayer = 'O';

                if (map[2] == chPlayer && map[6] == chPlayer && map[10] == chPlayer)
                    return i;

                if (map[16] == chPlayer && map[20] == chPlayer && map[24] == chPlayer) 
                    return i;

                if (map[30] == chPlayer && map[34] == chPlayer && map[38] == chPlayer)
                    return i;

                if (map[2] == chPlayer && map[16] ==  chPlayer && map[30] == chPlayer)
                    return i;

                if (map[6] == chPlayer && map[20] ==  chPlayer && map[34] == chPlayer)
                    return i;

                if (map[10] == chPlayer && map[24] == chPlayer && map[38] == chPlayer)
                    return i;

                if (map[2] == chPlayer && map[20] == chPlayer && map[38] == chPlayer)
                    return i;

                if (map[10] == chPlayer && map[20] == chPlayer && map[30] == chPlayer)
                    return i;
            }

            return Players.PlayersPlayerNoWinner;
        }

        public void ClearCell(int x, int y, ref string map)
        {
            if( !IsValidPlayerPosition(x, y) )
                return;

            int index = 0;

            switch (y)
            {
                case 1:
                {
                    index = 14;
                }
                break;

                case 2:
                {
                    index = 28;
                }
                break;
            }

            switch (x)
            {
                case 0:
                {
                    var newMap = new StringBuilder(map);
                    newMap[2 + index] = ' ';
                    map = newMap.ToString();
                }
                break;

                case 1:
                {                    
                    var newMap = new StringBuilder(map);
                    newMap[6 + index] = ' '; 
                    map = newMap.ToString(); 
                }
                break;
                
                case 2:
                {
                    var newMap = new StringBuilder(map);
                    newMap[10 + index] = ' '; 
                    map = newMap.ToString();  
                }
                break;
            }
        }

        public char GetCurrentPlayer()
        {
            return CurrentPlayer;
        }

        private int XMAX = 2;
        private int YMAX = 2;

        static Players ePlayer = Players.PlayersPlayerX;
        static char CurrentPlayer = 'X';
    }
}
