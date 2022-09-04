using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Game
    {

        Board board;
        Player player1;
        Player player2;
        Player currPlayer;

        public Game(Player player1, Player player2)
        {
            this.board = new Board();
            this.player1 = player1;
            this.player2 = player2;
            this.currPlayer = player1;
        }

        public void NewGame()
        {
            this.board.ResetBoard();
            this.currPlayer = player1;
        }

        public void PlayGame()
        {

        }

    }
}
