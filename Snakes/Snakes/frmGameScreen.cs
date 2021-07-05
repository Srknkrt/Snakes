using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakes
{
    public partial class frmGameScreen : Form
    {
        //Liste tipinde yilan olusturuldu.
        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
        //Liste tipinde duvar olusturuldu.
        private List<Circle> wall = new List<Circle>();
        int Counter = 5;

        public frmGameScreen()
        {
            InitializeComponent();

            new Settings();

            //Yilanin hareket etmesini saglayan zamanlayici ayarlandi.
            tGameTimer.Interval = 500 / Settings.Speed;
            tGameTimer.Tick += UpdateScreen;
            tGameTimer.Start();

            //Oyuna baslayici fonksiyon cagirildi.
            StartGame();
        }

        private void StartGame()
        {
            lblDescription.Visible = false;

            //Duvarlar olusturuldu.
            GenerateWall();
            
            new Settings();

            //Yilanin baslangic yeri olusturuldu.
            snake.Clear();
            Circle head = new Circle { X = 25, Y = 13 };
            snake.Add(head);

            lblScore.Text ="Score: " + Settings.Score.ToString();

            //Besin olusturucu fonksiyon cagirildi.
            GenerateFood();
        }

        private void GenerateFood()
        {
            //Besinin oyun alanindaki olusacagi yer kisitlandi.
            int maxXPos = pcbArea.Size.Width / Settings.Width;
            int maxYPos = pcbArea.Size.Height / Settings.Heigth;

            //Yilan harita boyuna ulasirsa oyun kazanildi.
            if (snake.Count == maxXPos * maxYPos)
            {
                food = new Circle { X = maxXPos + 1, Y = maxYPos + 1 };
                MessageBox.Show("Congratulations. You are winner!!!");
                Settings.direction = Direction.Stop;
                Settings.GameOver = true;
            }

            //Besin oyun alaninda rastgele olacak sekilde olusturuldu.
            Random Rand = new Random();
            food = new Circle { X = Rand.Next(0, maxXPos), Y = Rand.Next(0, maxYPos) };

            //Besinin yilanin icerisinde olusmamasi saglandi.
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                while (food.X == snake[i].X && 
                       food.Y == snake[i].Y)
                {
                    food = new Circle { X = Rand.Next(0, maxXPos), Y = Rand.Next(0, maxYPos) };
                    i = snake.Count - 1;
                }
            }

            //Besinin duvarin icerisinde olusmamasi saglandi.
            for (int i = 0; i < maxXPos * 2 + maxYPos * 2 - 30; i++)
            {
                while (food.X == wall[i].X &&
                       food.Y == wall[i].Y)
                {
                    food = new Circle { X = Rand.Next(0, maxXPos), Y = Rand.Next(0, maxYPos) };
                    i = 0;
                }
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver)
            {
                if(Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                //Klavyeden alinan veriye gore yilanin yonu ayarlandi.
                if ((Input.KeyPressed(Keys.Up) || Input.KeyPressed(Keys.W))
                    && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if ((Input.KeyPressed(Keys.Down) || Input.KeyPressed(Keys.S))
                    && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;
                else if ((Input.KeyPressed(Keys.Right) || Input.KeyPressed(Keys.D))
                    && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if ((Input.KeyPressed(Keys.Left) || Input.KeyPressed(Keys.A))
                    && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.P) && Settings.direction != Direction.Stop)
                    Settings.Paused = true;
                //Yilanin hareket etmesini saglayan fonksiyon cagirildi.
                MovePlayer();
            }

            pcbArea.Invalidate();
        }

        private void GenerateWall()
        {
            int maxXPos = pcbArea.Size.Width / Settings.Width;
            int maxYPos = pcbArea.Size.Height / Settings.Heigth;

            //Sol ve sag tarafin ortasi delikli bir sekilde duvari olusturuldu.
            for (int i = 0; i < maxYPos; i++)
            {
                if (10 < i && i < 16)
                    continue;
                Circle leftWall = new Circle { X = 0, Y = i };
                wall.Add(leftWall); 
                Circle rightWall = new Circle { X = maxXPos - 1, Y = i };
                wall.Add(rightWall);
            }

            //Ust ve alt tarafin ortasi delikli bir sekilde duvari olusturuldu.
            for(int i = 0; i < maxXPos; i++)
            {
                if (19 < i && i < 30)
                    continue;
                Circle upWall = new Circle { X = i, Y = 0 };
                wall.Add(upWall);
                Circle downWall = new Circle { X = i, Y = maxYPos - 1};
                wall.Add(downWall);
            }
        }

        private void pcbArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics area = e.Graphics;

            //Duvarin renkgi olusturuldu.
            int maxXPos = pcbArea.Size.Width / Settings.Width;
            int maxYPos = pcbArea.Size.Height / Settings.Heigth;
            for (int i = 0; i < maxYPos * 2 + maxXPos * 2 - 30; i++)
            {
                area.FillEllipse(Brushes.Navy,
                        new Rectangle(wall[i].X * Settings.Width,
                                      wall[i].Y * Settings.Heigth,
                                      Settings.Width, Settings.Heigth));
            }


            if (!Settings.GameOver)
            {
                for(int i = 0; i < snake.Count; i++ )
                {
                    Brush snakeColour;

                    //Yilanin ve besinin renkleri olusturuldu.
                    if (i == 0)
                        snakeColour = Brushes.Black;
                    else
                        snakeColour = Brushes.Green;

                    area.FillEllipse(snakeColour,
                        new Rectangle(snake[i].X * Settings.Width,
                                      snake[i].Y * Settings.Heigth,
                                      Settings.Width, Settings.Heigth));
                    area.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width,
                                      food.Y * Settings.Heigth,
                                      Settings.Width, Settings.Heigth));
                }
            }
            else
            {
                string gameOver = "Game over \nYour final score is: " + Settings.Score + "\nPress Enter to try again";
                lblDescription.Text = gameOver;
                lblDescription.Visible = true;
            }
        }

        private void MovePlayer()
        {
            if(Settings.Paused)
            {
                //Oyunun duraklatilmasi icin fonksiyon cagirildi.
                PauseGame();
            }
            else
            {
                for (int i = snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        //Yilanin yonune gore hareket etmesi saglandi.
                        switch (Settings.direction)
                        {
                            case Direction.Right:
                                snake[i].X++;
                                break;
                            case Direction.Left:
                                snake[i].X--;
                                break;
                            case Direction.Up:
                                snake[i].Y--;
                                break;
                            case Direction.Down:
                                snake[i].Y++;
                                break;
                        }

                        //Yilan eger alanin disina cikarsa karsi taraftan oyuna devam etmesi saglandi.
                        int maxXPos = pcbArea.Size.Width / Settings.Width;
                        int maxYPos = pcbArea.Size.Height / Settings.Heigth;
                        if (snake[i].X >= maxXPos)
                            snake[i].X = 0;
                        if (snake[i].X < 0)
                            snake[i].X = maxXPos;
                        
                        if (snake[i].Y >= maxYPos)
                            snake[i].Y = 0;
                        if (snake[i].Y < 0)
                            snake[i].Y = maxYPos;

                        //Yilan eger kendi vucudunu yerse kuculmesi saglandi.
                        int size = snake.Count;
                        for (int j = 1; j < snake.Count; j++)
                        {
                            if (snake[i].X == snake[j].X &&
                                snake[i].Y == snake[j].Y)
                            {
                                for(int k = size; k > j; k--)
                                {
                                    snake.RemoveAt(k - 1);
                                    Settings.Score -= Settings.Points;
                                    lblScore.Text = "Score: " + Settings.Score.ToString();
                                }
                            }
                        }

                        //Yilan eger duvara carparsa olmesi saglandi.
                        for (int j = 0; j < maxXPos * 2 + maxYPos * 2 - 30; j++)
                        {
                            if (snake[i].X == wall[j].X &&
                                snake[i].Y == wall[j].Y)
                            {
                                Die();
                            }
                        }
                        //Yilanin besin yemesi saglandi.
                        if (snake[i].X == food.X &&
                            snake[i].Y == food.Y)
                        {
                            Eat();
                        }
                    }
                    else if (Settings.direction != Direction.Stop)
                    {
                        //Yilanin vucudunun kafasini takip etmesi saglandi.
                        snake[i].X = snake[i - 1].X;
                        snake[i].Y = snake[i - 1].Y;
                    }
                }
            } 
        }

        private void Eat()
        {
            //Yilan beslendigi zaman boyutunun artmasi saglandi.
            Circle food = new Circle
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };

            snake.Add(food);

            Settings.Score += Settings.Points;
            lblScore.Text ="Score: " + Settings.Score.ToString();

            //Besin alinditan sonra yeni besin icin fonksiyon cagirildi.
            GenerateFood();
        }

        private void Die()
        {
            //Yilanin oldugu zaman oyunun bitmesi saglandi.
            Settings.GameOver = true;
        }

        private void PauseGame()
        {
            //Oyun durdugunda ekranda yazacak olan yazi.
            string Paused = "Game Paused\n           " + Counter.ToString();

            lblDescription.Text = Paused;
            lblDescription.Visible = true;
            tPaused.Start();
           
            //Oyun Duraklatildi ve devam etmesi saglandi.
            if (Counter == 0 && Settings.Paused)
            {
                tPaused.Stop();
                Paused = "Game Paused\n       Ready";
                lblDescription.Text = Paused;

                if (Input.KeyPressed(Keys.P))
                {
                    Settings.Paused = false;
                    Settings.direction = Direction.Stop;

                    lblDescription.Visible = false;
                    Counter = 5;
                }
            }  
        }

        private void tPaused_Tick(object sender, EventArgs e)
        {
            //Zaman sayaci olusturuldu.
            Counter--;
        }

        private void frmGameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //Klavyeden bir tusa basildigi zaman yapilacak degisiklikler saglandi.
            Input.ChangedState(e.KeyCode, true);
        }

        private void frmGameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //Klavyeden bir tus birakildigi zaman yapilacak degisikler saglandi.
            Input.ChangedState(e.KeyCode, false);
        }

        private void frmGameScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Uygulama kapatildi.
            Application.Exit();
        }
    }
}
