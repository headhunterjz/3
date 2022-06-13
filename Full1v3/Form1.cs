using System;
using System.Drawing;
using System.Windows.Forms;

namespace Full1v3
{
    public partial class Form1 : Form
    {
        int iteration = 1;
        int iteration_time =0;
        int best_result = 0;
        int menu = 0;//добавление объектов
        int[,] road = { 
            {0,0,0,0,2,1,0,0,0,0,0,0,0,0,2,7,0,0,0,0 },
            {0,0,0,0,2,1,0,0,0,0,0,0,0,0,2,1,0,0,0,0 },
            {0,0,0,0,5,5,4,4,5,5,4,4,4,4,5,5,4,4,5,5 },
            {0,0,0,0,5,5,3,3,5,5,3,3,3,3,5,5,3,3,5,5 },
            {0,0,0,0,0,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1 },
            {0,0,0,0,0,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1 },
            {0,0,5,5,4,4,4,4,5,5,4,4,4,4,5,5,4,4,5,5 },
            {0,0,5,5,3,3,3,3,5,5,3,3,3,3,5,5,3,3,5,5 },
            {0,0,2,1,0,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1 },
            {0,0,2,1,0,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1 },
            {0,0,2,1,0,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1 },
            {0,0,5,5,4,4,4,4,5,5,4,4,4,4,5,5,4,4,5,5 },
            {0,0,5,5,3,3,3,3,5,5,3,3,3,3,5,5,3,3,5,5 },
            {0,0,2,1,0,0,0,0,2,1,0,0,0,0,2,1,0,0,0,0 },
            {0,0,2,1,0,0,0,0,2,1,0,0,0,0,2,1,0,0,0,0 },
            {0,0,2,1,0,0,0,0,2,1,0,0,0,0,2,1,0,0,0,0 },
            {0,0,5,5,4,4,4,4,5,5,4,4,4,4,5,5,4,4,4,4 },
            {0,0,5,5,3,3,3,3,5,5,3,3,3,3,5,5,3,3,3,3 },
            {0,0,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,2,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        };//создание дороги
        int[,] oject = {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        };//создание объектов
        int x_now = -1;//выделение объекта
        int y_now = -1;//выделение объекта
        int[] last_cross = new int[2];
        int[] car = new int[3] { 3, 19, 0 };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)//заполение картинками панели
            {
                for (int j = 0; j <20; j++)//заполение картинками панели
                {
                    PictureBox pic = new PictureBox//заполение картинками панели
                    {
                        Name = $"{i}_{j}",//заполение картинками панели
                        //BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(35, 35),//заполение картинками панели
                        Location = new Point(35 * i, 35 * j),//заполение картинками панели
                    };
                    pic.Click += Pic_Click;//выделение и установка объектов
                    pic.MouseHover += Pic_MouseHover;//отображение кординатов блока
                    panel1.Controls.Add(pic);//заполение картинками панели

                }
            }
            draw();//отрисовка объектов и дороги
        }

        private void Pic_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;//отображение кординатов блока
            label1.Text = pic.Name;//отображение кординатов блока
        }

        private void draw()
        {
           for (int i = 0; i < 20; i++)//отрисовка объектов и дороги
            {
                for (int j = 0; j < 20; j++)//отрисовка объектов и дороги
                {
                    PictureBox pic = panel1.Controls[j + "_" + i] as PictureBox;//отрисовка объектов и дороги
                    switch (road[i,j])//отрисовка дороги
                    {
                        case 1:
                            pic.BackgroundImage = Properties.Resources.Rvertical;
                            break;//дорога вверх
                        case 2:
                            pic.BackgroundImage = Properties.Resources.Rvertical;
                            pic.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                            break;//дорога вниз
                        case 3:
                            pic.BackgroundImage = Properties.Resources.Rvertical;
                            pic.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;//дорога направо
                        case 4:
                            pic.BackgroundImage = Properties.Resources.Rvertical;
                            pic.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;//дорога налево
                        case 5:
                            pic.BackgroundImage = Properties.Resources.Rcrossroads;
                            break;//перекресток
                        case 6:
                            pic.BackgroundImage = Properties.Resources.Rstart;
                            break;//старт
                        case 7:
                            pic.BackgroundImage = Properties.Resources.Rfinish;
                            break;//финиш
                    }
                    switch (oject[i, j])
                    {
                        case 1:
                            pic.Image = Properties.Resources.Rblock;
                            break;//кирпич
                        case 2:
                            pic.Image = Properties.Resources.Cvertical1;
                            break;//машина
                    }
                }
            }
           
        } 

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;//выделение и добавление объектов
            string[] s = pic.Name.Split('_');//удаление объектов
            int x = int.Parse(s[1]);//удаление объектов
            int y = int.Parse(s[0]);//удаление объектов
            if (x_now > 0)//отчистка рамки
            {
                PictureBox pic1 = panel1.Controls[y_now + "_" + x_now] as PictureBox;//отчистка рамки
                pic1.BorderStyle = BorderStyle.None;//отчистка рамки
            }
            button2.Enabled = false;//удаление объектов
            switch (menu)
            {
                case 0:
                    if (pic.Image != null)
                    {
                        pic.BorderStyle = BorderStyle.FixedSingle;
                        x_now = x;
                        y_now = y;
                        button2.Enabled = true;
                    }
                    break;//выделение объектов
                case 1:
                    if (road[x, y] >= 1 && road[x,y] <=4)
                    {
                        pic.Image = Properties.Resources.Rblock;
                    }
                    break;//установка кирпича
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu = 1;//установка кирпича
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(x_now != -1)//удаление объекта
            {
                PictureBox pic = panel1.Controls[y_now + "_" + x_now] as PictureBox;
                pic.Image = null;
                x_now = -1;
                pic.BorderStyle = BorderStyle.None;
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)//остановка обучения
        {
            timer1.Stop();
            stop();
        }
        private void stop()
        {
            PictureBox pic = panel1.Controls[car[0] + "_" + car[1]] as PictureBox;//удаление машины
            pic.Image = null;//удаление машины
            car = new int[3] { 3, 19, 0 };//сброс кардинат
            pic = panel1.Controls[car[0] + "_" + car[1]] as PictureBox;//установка машины
            pic.Image = Properties.Resources.Cvertical1;//установка машины
            

            iteration++;
            label5.Text = iteration.ToString();
            iteration_time = 0;
        }
        private void car_move()
        {
            int car_x=0,car_y = 0; 
            PictureBox pic = panel1.Controls[car[0] + "_" + car[1]] as PictureBox;
            pic.Image = null;
            switch (car[2])
            {
                case 0:
                    car_x = car[0];
                    car_y = car[1]-1;
                    break;
                case 1:
                    car_x = car[0]+1;
                    car_y = car[1];
                    break;
                case 2:
                    car_x = car[0];
                    car_y = car[1]+1;
                    break;
                case 3:
                    car_x = car[0]-1;
                    car_y = car[1];
                    break;
            }
            PictureBox pic1 = panel1.Controls[car_x + "_" + car_y] as PictureBox;
            if (pic1 != null)
            {
                if (pic1.Image == null && road[car_y, car_x] != 6 && road[car_y, car_x] != 0)
                {
                    switch (car[2])
                    {
                        case 0:
                            pic1.Image = Properties.Resources.Cvertical1;
                            break;
                        case 1:
                            pic1.Image = Properties.Resources.Cright;
                            break;
                        case 2:
                            pic1.Image = Properties.Resources.Cbottom;
                            break;
                        case 3:
                            pic1.Image = Properties.Resources.Cleft;
                            break;
                    }
                    car[0] = car_x;
                    car[1] = car_y;
                    if (road[car_y, car_x] == 5)
                    {
                        last_cross[0] = car_x;
                        last_cross[1] = car_y;
                    }
                    if(road[car_y, car_x] == 7)
                    {
                        if (iteration_time < best_result)
                        {
                            best_result = iteration_time;
                            label7.Text = best_result.ToString();
                        }
                        stop();
                    }
                }
                else
                {
                    bool c_t = false;
                    if (road[car[1], car[0]] == 5)
                    {
                        if (pic1.Image != null)
                        {
                            road[last_cross[1], last_cross[0]] = 6;
                            stop();
                        }
                        else
                        {
                            for (int i = 1; i >=0; i--)
                            {

                                int nav = turn(i);
                                switch (nav)
                                {
                                    case 0:
                                        car_x = car[0];
                                        car_y = car[1] - 1;
                                        break;
                                    case 1:
                                        car_x = car[0] + 1;
                                        car_y = car[1];
                                        break;
                                    case 2:
                                        car_x = car[0];
                                        car_y = car[1] + 1;
                                        break;
                                    case 3:
                                        car_x = car[0] - 1;
                                        car_y = car[1];
                                        break;
                                }
                                if (i == 0)
                                {
                                    sw_turn(car[2], ref car_x, ref car_y);
                                    if (road[car_y, car_x] >= 1 && road[car_y, car_x] <= 5)
                                    {
                                        sw_turn(car[2], ref car[0], ref car[1]);
                                        car[2] = turn(i);
                                        c_t = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (car_x >= 0 && car_x <= 19 && car_y >= 0 && car_y <= 19)
                                    {
                                        if (road[car_y, car_x] >= 1 && road[car_y, car_x] <= 5)
                                        {
                                            nav = turn(2);
                                            car_x = car[0];
                                            car_y = car[1];
                                            sw_turn(nav, ref car_x, ref car_y);
                                            if (road[car_y, car_x] < 5)
                                            {
                                                car[2] = turn(i);
                                                c_t = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                                
                            }
                            if (!c_t)
                            {
                                road[last_cross[1], last_cross[0]] = 6;
                                stop();
                            }
                        }
                    }
                    else
                    {
                        road[last_cross[1], last_cross[0]] = 6;
                        stop();
                    }
                }
            }
            else
            {
                road[last_cross[1], last_cross[0]] = 6;
                stop();
            } 
        }
        private void sw_turn(int sw, ref int x,ref int y)
        {
            switch (sw)
            {
                case 0:
                    y--;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y++;
                    break;
                case 3:
                    x--;
                    break;
            }
        }
        private int turn(int dir)
        {
            int nav = car[2];
            if (dir == 1)
                nav++;
            else if (dir == 2)
                nav += 2;
            else
                nav--;
            if (nav > 3)
                nav -= 4;
            else if (nav < 0)
                nav += 4;
            return nav;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value * 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            car_move();
            iteration_time++;
            label6.Text = iteration_time.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
