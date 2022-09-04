using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Board
    {
        int numTiles, tileSize;
        int startDrawingPointX, startDrawingPointY;
        Bitmap redChip, blueChip; 
        Button[,] board;

        public Board(int startDrawingPointX=10, int startDrawingPointY=50, int numTiles=8, int tileSize=75)
        {
            // Ex: if numTiles = 8, it'll create a 8x8 Grid
            this.numTiles = numTiles;

            // Formatted size  of the tile. Ex, NxN pixels
            this.tileSize = tileSize;

            // Start Drawing Point X and Y for form 
            this.startDrawingPointX = startDrawingPointX;
            this.startDrawingPointY = startDrawingPointY;

            // Red Chip image -- Transparent background
            this.redChip = new Bitmap("RedChip.bmp");
            this.redChip.MakeTransparent(Color.White);

            // Blue Chip image -- Transparent background
            this.blueChip = new Bitmap("BlueChip.bmp");
            this.blueChip.MakeTransparent(Color.White);

            // Create the 2D Array of buttons
            this.board = new Button[tileSize, tileSize];
            
            // Create the board (initialize it) 
            this.CreateBoard();
        }

        public int GetTileSize()
        {
            return this.tileSize;
        }
        
        public int GetSize()
        {
            return this.numTiles;
        }
        
        public Button[,] GetBoard()
        {
            return this.board;
        }
        
        public Button GetButton(int x, int y)
        {
            return this.board[x, y];
        }

        private void CreateBoard()
        {
            bool red = false;
            int pointX;
            int pointY = this.startDrawingPointY;

            // Initialize the array of buttons
            for (int i = 0; i < this.numTiles; i++)
            {
                
                red = !red;
                pointX = this.startDrawingPointX;
                for (int j = 0; j < this.numTiles; j++)
                {
                    this.board[i, j] = new System.Windows.Forms.Button();

                    this.board[i, j].Name = "button_" + i.ToString() + "_" + j.ToString();
                    this.board[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.board[i, j].FlatAppearance.BorderSize = 0;
                    this.board[i, j].Margin = new System.Windows.Forms.Padding(0);
                    this.board[i, j].Size = new System.Drawing.Size(this.tileSize, this.tileSize);
                    this.board[i, j].Location = new System.Drawing.Point(pointX, pointY);
                    this.board[i, j].Enabled = false;

                    // Set the colors of the files
                    if (red)
                    {
                        // Set the red tiles and enable them
                        this.board[i, j].BackColor = System.Drawing.Color.IndianRed;
                    }
                    else 
                    {
                        // Set the black tiles and disable them
                        this.board[i, j].UseVisualStyleBackColor = false;
                        this.board[i, j].BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                    }

                    
                    pointX += (this.tileSize - 1);
                    red = !red;
                }
                pointY += (this.tileSize - 1);
            }

            this.ResetBoard();
        }

        public void ResetBoard()
        {
            for (int i = 0; i < this.numTiles; i++)
            {
                for (int j = 0; j < this.numTiles; j++)
                {
                    // Reset the image for a tile regardless.
                    this.board[i, j].Image = null;
                    this.board[i, j].Enabled = false;

                    // Put Red Chips in the top 3 rows
                    if ((i < 3) && (this.board[i,j].Enabled == true))
                    {
                        this.board[i, j].Image = redChip;
                        continue;
                    }

                    if (i >= (this.numTiles - 3) && (this.board[i, j].Enabled == true))
                    {
                        this.board[i, j].Image = blueChip;
                        continue;
                    }
                }
 
            }

        }

    }
}
