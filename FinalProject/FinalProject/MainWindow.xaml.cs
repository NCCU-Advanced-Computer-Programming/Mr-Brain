using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        bool start = false;
        int tmp;
        int stage = 4;
        int nowcount = 1;
        bool [] state = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        int [] check = new int[15];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.bt1.Visibility = Visibility.Hidden;
            this.lb1.Content = "        Stage :  "+ (stage-3).ToString();
            start = true;
            Image [] arr = { this.im1, this.im2, this.im3, this.im4, this.im5, this.im6, this.im7, this.im8, this.im9, this.im10, this.im11, this.im12, this.im13, this.im14, this.im15 };
            for (int i = 0; i < 15; ++i )
            {
                arr[i].Source = new BitmapImage(new Uri(@"/NUM/" +  "begin.jpg", UriKind.RelativeOrAbsolute));
            }
            GameStart(start, arr, stage);
        }
        private async void GameStart(bool start, Image [] arr, int stage)
        {
            if (start)
            {
                start = false;
                for (int i = 1; i < stage; ++i)
                {
                    do
                    {
                        tmp = new Random(Guid.NewGuid().GetHashCode()).Next() % 15;
                    } while (state[tmp]);
                    state[tmp] = true;
                    arr[tmp].Source = new BitmapImage(new Uri(@"/NUM/" + i.ToString() + ".jpg", UriKind.RelativeOrAbsolute));
                    check[i] = tmp;
                }
                await Task.Delay(3000);
                int count = 0;
                foreach (bool element in state)
                {
                    if (element == true)
                    {
                        arr[count].Source = new BitmapImage(new Uri(@"/NUM/" + "back.jpg", UriKind.RelativeOrAbsolute));
                    }
                    ++count;
                }
            }    
            start = true;

        }
        private void checkin(Image now, int imnum)
        {
            if(imnum == check[nowcount])
            {
                now.Source = new BitmapImage(new Uri(@"/NUM/" + nowcount.ToString() + ".jpg", UriKind.RelativeOrAbsolute));
                ++nowcount;
                if (nowcount == stage) 
                {
                    if (stage == 10)
                    {
                        MessageBox.Show("You Complete Full Stages!!");
                        stage = 4;
                        nowcount = 1;
                        for (int j = 0; j < 15; ++j)
                        {
                            state[j] = false;
                            check[j] = -1;
                        }
                        start = false;
                        this.bt1.Content = "Start";
                        this.bt1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ++stage;
                        nowcount = 1;
                        for (int j = 0; j < 15; ++j)
                        {
                            state[j] = false;
                            check[j] = -1;
                        }
                        start = false;
                        this.bt1.Content = "Next";
                        this.bt1.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("You Lose in Stage "+(stage-3).ToString()+"!!");
                stage = 4;
                nowcount = 1;
                for (int j = 0; j < 15; ++j)
                {
                    state[j] = false;
                    check[j] = -1;
                }
                start = false;
                this.bt1.Content = "Retry";
                this.bt1.Visibility = Visibility.Visible;
            }
        }
        private void im1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(start)
                checkin(this.im1, 0);
        }

        private void im2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im2, 1);
        }

        private void im3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im3, 2);
        }

        private void im4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im4, 3);
        }

        private void im5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im5, 4);
        }

        private void im6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im6, 5);
        }

        private void im7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im7, 6);
        }

        private void im8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im8, 7);
        }

        private void im9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im9, 8);
        }

        private void im10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im10, 9);
        }

        private void im11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im11, 10);
        }

        private void im12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im12, 11);
        }

        private void im13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im13, 12);
        }

        private void im14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im14, 13);
        }

        private void im15_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (start) 
                checkin(this.im15, 14);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
    }
}
