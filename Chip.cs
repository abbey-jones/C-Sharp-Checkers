using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Chip
    {
        private bool isRed;
        private bool isKing;
        
        private int? last_x_pos;
        private int? last_y_pos;

        public Chip(bool isRed=true, int x_pos, int y_pos)
        {
            this.last_x_pos = null;
            this.last_y_pos = null;
            this.isRed = true;
            this.isKing = false;
        }

        public bool isChipRed()
        {
            return this.isRed;
        }

        public bool validPos(int new_x_pos, int new_y_pos)
        {
            bool valid = false;
            int diff_x, diff_y;

            diff_x = new_x_pos - last_x_pos;
            diff_y = new_y_pos - last_y_pos;

            if (diff_x == 1 && diff_y == 1)
            {
                valid = true;
            }

            else if (diff_x == 2 && diff_y == 2)
            {
                valid = true;
            }

            else
            {
                valid = false;
            }

            return valid;
        }

    }
}
