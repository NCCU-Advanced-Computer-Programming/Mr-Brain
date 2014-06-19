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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;


namespace WpfApplication2
{
   
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        int[] level = new int[10] {2,1,3,2,4,2,1,3,2,1} ;
        int[] player_answer = new int[10] {0,0,0,0,0,0,0,0,0,0};
        static int current_level = 1;
        static int i;
        static int press_time = 0;
        char[] color = new char[4] {'紅','綠','籃','黃' };

  
         
  


        public MainWindow()
        {
            InitializeComponent();
            this.label.Content = "Level=1";
            Game_Start();
        }


        private async void Game_Start() {
            await Task.Delay(500);
            MessageBox.Show("每次出現一個顏色，依照出現的順序來進行遊戲");
            Game_Go();
        }

        private async void Game_Go()
        {
            await Task.Delay(500);
            MessageBox.Show(" " + color[level[current_level-1]-1]);


        }

        private void check() {
         
            press_time++;
            if (player_answer[press_time-1] != level[press_time-1]) {//失敗後初始化
                MessageBox.Show("You Lose!!!");
                press_time = 0;
                current_level = 1;
          //      Random ram;
                for (int k = 0; k < 10; k++) {
                    player_answer[k] = 0;
       //              ram = new Random();
       //             level[k] = ram.Next() % 4;

                } 
                //失敗後初始化結束
            } else if (press_time == current_level) {//過關後關卡+1
                press_time = 0;
                for (int k = 0; k < 10; k++)
                {

                    player_answer[k] = 0;
                }
                Game_Go();
                if (current_level == 10)
                {
                    MessageBox.Show("You Win!!!");
                    current_level = 1;
                    for (int l = 0; l < 10; l++)
                    {
                        player_answer[l] = 0;
               //         Random ram = new Random();
            //            level[l] = ram.Next() % 4;

                    } 
                }
                else
                {
                    current_level++;
                   
                    //過關後關卡+1結束
                }

            }
            this.label.Content = "Level=" + (current_level);
        }//check end

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                player_answer[press_time] = 1;        
                check();  
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            player_answer[press_time] = 2;
            check();  
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
           player_answer[press_time] = 3;
            check();  
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
             player_answer[press_time] = 4;
             check();       
        }

      
      
    }
}
