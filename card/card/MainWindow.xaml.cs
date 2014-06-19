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
namespace card
{

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        bool[] state = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        int[] check = new int[16];
        Image[] arr = new Image[16];
        int[] ImageId = new int[20];
   
        int firstPicPos = -1;
        int Counter = 0;
        DateTime start; //成員變數
          
   
  

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
           
            arr[0] = this.im1; arr[1] = this.im2;
            arr[2] = this.im3; arr[3] = this.im4;
            arr[4] = this.im5; arr[5] = this.im6;
            arr[6] = this.im7; arr[7] = this.im8;
            arr[8] = this.im9; arr[9] = this.im10;
            arr[10] = this.im11; arr[11] = this.im12;
            arr[12] = this.im13; arr[13] = this.im14;
            arr[14] = this.im15; arr[15] = this.im16;

            for (int i = 0; i < 16; i++)
            { arr[i].Source = new BitmapImage(new Uri("back.jpg", UriKind.RelativeOrAbsolute)); }

            for (int i = 0; i < 8; i++)
            {
                ImageId[i * 2] = i;
                ImageId[i * 2 + 1] = i;
            }
            Random rd = new Random();
            for (int i = 0; i < 16; i++)
            {
                //決定要交換的位置
                int t = rd.Next(0, 16);
                //交換位置i和t的Id
                int temp = ImageId[i];
                ImageId[i] = ImageId[t];
                ImageId[t] = temp;
            }
            start = DateTime.Now;
        }

        private async void im1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int picPos = 0;
            Image s = (Image)sender;
            for (int i = 0; i < 16; i++)
            {
                if (s == arr[i]) picPos = i; //挑到第幾個box
            }
            
            
            int id = ImageId[picPos];    //挑到哪一張圖片
            

            if (id == -1) return;

            if (firstPicPos == -1)
            {
                //此是第一張, 記錄其位置並打開圖片
                arr[picPos].Source = new BitmapImage(new Uri((id+1).ToString() + ".jpg", UriKind.RelativeOrAbsolute));
                firstPicPos = picPos;
            }
            else
            { //已有打開的圖片
                if (picPos == firstPicPos) return;  //同一張
                //這是第二張，打開圖片
                arr[picPos].Source = new BitmapImage(new Uri((id+1).ToString() + ".jpg", UriKind.RelativeOrAbsolute));
                
                //延遲0.5秒，

                await Task.Delay(500);
                if (id == ImageId[firstPicPos])
                {   //取走此兩張圖片
                    arr[picPos].Source = null;
                    arr[firstPicPos].Source = null;
                    //記錄已取走的狀態
                    ImageId[firstPicPos] = -1;
                    ImageId[picPos] = -1;
                    Counter += 2; //比對成功的圖片數加2
                    //處理是否全部打開的情形 (下一頁)
                   

                   
                    if (Counter == 16)
                    {
                        DateTime end = DateTime.Now;
                        TimeSpan t = end - start;
                        int ts = (int)t.TotalSeconds;
                        MessageBox.Show("完成! 共花了" + ts + "秒", "記憶遊戲");
                    }
                }
                else
                {   //蓋上此兩張圖片               
                    arr[picPos].Source = new BitmapImage(new Uri("back.jpg", UriKind.RelativeOrAbsolute));
                    arr[firstPicPos].Source = new BitmapImage(new Uri("back.jpg", UriKind.RelativeOrAbsolute));
                }
                firstPicPos = -1; //記錄“未打開第一張”的狀態
            }
        }
    }
}