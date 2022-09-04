namespace Checkers
{
    public partial class CheckersGame : Form
    {
        Image? last_image;
        Button? last_button;
        int? last_x;
        int? last_y;
        
        public CheckersGame()
        {
            InitializeComponent();
            this.SetupGame();
        }

        private (int x, int y) GetButtonXY(Button button)
        {
            string[] btnName = button.Name.Split("_");
            return (int.Parse(btnName[1]), int.Parse(btnName[2]));
            
        }

        private void NullLast()
        {
            last_button.Image = null;
            last_button = null;
            last_image = null;
            last_x = null;
            last_y = null;
        }

        private void ResetLastButton()
        {
            if (last_button != null)
            {
                last_button.Image = last_image;
            }
            this.NullLast();
        }

        private void ToggleImage(Button button)
        {
            int x, y;
            Bitmap greyChip;

            // Grey Chip image -- Transparent background
            greyChip = new Bitmap("GreyChip.bmp");
            greyChip.MakeTransparent(Color.White);

            (x, y) = this.GetButtonXY(button);

            // User picked a tile with no image (meaning they want to move a piece to a different tile)
            if (button.Image == null)
            {
                // They didn't a checker first -- Error
                if (last_image == null || last_x == null || last_y == null || last_button == null)
                {
                    MessageBox.Show("You cannot select an empty space without first selecting a chip.\n");
                    return;
                }

                // Validate checker index
                // distance_x = x - last_x.Value;
                // distance_y = y - last_y.Value;

                button.Image = last_image;
                this.NullLast();
                
                // Check with the distance from last checker to this checker
                // Should only be 1 space away
                //if (distance_x != 1 || distance_x != -1 || distance_y != 1 || distance_y != -1)
                //{
                //    this.ResetLastButton();
                ///    MessageBox.Show("You cannot move there!");
                //    return;
                //}

            }

            // User picked an image with a checker on it to move it.
            else
            {

                if (last_image != null)
                {
                    MessageBox.Show("You have already selected a chip.");
                    return;
                }


                last_button = button;
                last_image = button.Image;
                button.Image = greyChip;

                last_x = x;
                last_y = y;
            }
        }

        private void anyButton_Click(object sender, EventArgs e)
        {
            ToggleImage((Button)sender);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.last_button = null;
            this.last_x = null;
            this.last_y = null;
            this.last_image = null;
            this.board.ResetBoard();
        }

        private void SetupGame()
        {
            Button button;

            int numTiles = this.board.GetSize();

            this.SuspendLayout();
            for (int i = 0; i < numTiles; i++)
            {
                for (int j = 0; j < numTiles; j++)
                {
                    button = board.GetButton(i, j);
                    button.Click += new System.EventHandler(anyButton_Click);
                    this.Controls.Add(button);
                }
            }
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}