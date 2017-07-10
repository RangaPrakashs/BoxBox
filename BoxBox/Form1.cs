using System;
using System.Drawing;
using System.Windows.Forms;


namespace BoxBox
{
    public partial class Form1 : Form
    {
        private Rectangle Goal = new Rectangle(350, 600, 50, 50);
        private Rectangle player = new Rectangle(350, 0, 50, 50);
        private Rectangle Enemy = new Rectangle(0, 150, 75, 75);
        private Rectangle Enemy2 = new Rectangle(599,350, 75, 75);
 



        public Form1()
        {
            this.MaximumSize = new Size(750, 750);
            this.MinimumSize = new Size(750, 750);
            this.BackColor = System.Drawing.Color.Black;
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red,Goal);
            e.Graphics.DrawRectangle(Pens.Blue,player);
            e.Graphics.DrawRectangle(Pens.Red,Enemy);
            e.Graphics.DrawRectangle(Pens.Red,Enemy2);
      

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int PlayerX = player.Location.X;
            int PlayerY = player.Location.Y;

            switch (e.KeyData)
            {
                case Keys.Up:
                    player.Location = new Point(PlayerX += 0, PlayerY -= 10);
                    this.Refresh();
                    break;
                case Keys.Down:
                    player.Location = new Point(PlayerX += 0, PlayerY += 10);
                    this.Refresh();
                    break;
                case Keys.Left:
                    player.Location = new Point(PlayerX - 10, PlayerY += 0);
                    this.Refresh();
                    break;
                case Keys.Right:
                    player.Location = new Point(PlayerX += 10, PlayerY += 0);
                    this.Refresh();
                    break;
                    
            }
            HitDetect();
            timer1.Start();
            this.Refresh();

        }
        public void HitDetect()
        {
            int PlayerX = player.Location.X;
            int PlayerY = player.Location.Y;
            if (player.IntersectsWith(Goal))
            {
                MessageBox.Show("Congratulations!!! You Win!!!");
                DialogResult dialogResult = MessageBox.Show("Do you want to Play again?", "Restart!", MessageBoxButtons.YesNo);
                if(dialogResult==DialogResult.Yes)
                {
                    player.Location = new Point(PlayerX = 350, PlayerY = 0);

                }
                else
                {
                    MessageBox.Show("The Game will now Exit");
                    this.Close();
                }
            }            

            if(Enemy.IntersectsWith(player)|| (Enemy2.IntersectsWith(player)))
            {
                player.Location = new Point(PlayerX = 350, PlayerY = 0);
                MessageBox.Show("You Lose!");
            }

                     


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeLocationOfRectangle(Enemy,780);
        }

        public void ChangeLocationOfRectangle(Rectangle rectangle, int xVal)
        {
           
            int EX1 = rectangle.Location.X;
            int EY1 = rectangle.Location.Y;
                        
            if (rectangle.Location.X > xVal)
            {
                rectangle.Location = new Point(EX1 = 0, EY1 = 150);

            }
            rectangle.Location = new Point(EX1 += 30, EY1 += 0);
            this.Refresh();
        }
    }
}
