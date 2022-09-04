using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Player
    {
        string name;
        bool player1;
        Bitmap chip;

        public Player(string name, bool player1=true)
        {
            // Set player name
            this.name = name;

            // Player 1 by default
            this.player1 = player1;

            // Set the player's chip 
            if (this.player1)
            {
                this.chip = new Bitmap("RedChip.bmp");
            }
            else
            {
                this.chip = new Bitmap("BlueChip.bmp");
            }
            this.chip.MakeTransparent(Color.White);
            
        }

        public bool isPlayer1()
        {
            return this.player1;
        }

        public Bitmap getChip()
        {
            return this.chip;
        }

    }
}
