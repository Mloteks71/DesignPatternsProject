using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ZTPProject
{
    class Shoot:Metoda
    {
        private Image ima1;
        public Object WykonajNaSingle(SingleShot shot,Canvas canvas,Object ob=null) {
            ima1 = new Image
            {

            };
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("/Files/EnemyShot.png", UriKind.Relative);
            bi1.EndInit();
            ima1.Source = bi1;
            canvas.Children.Add(ima1);
            Canvas.SetLeft(ima1, shot.getPosition().getX());
            Canvas.SetTop(ima1, shot.getPosition().getY());
            shot.setImage(ima1);
            return ima1;
        }
        public Object WykonajNaTShot(TShot shot,Canvas canvas, Object ob = null) {
            ima1 = new Image
            {

            };
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("/Files/TShot.png", UriKind.Relative);
            bi1.EndInit();
            ima1.Source = bi1;
            canvas.Children.Add(ima1);
            Canvas.SetLeft(ima1, shot.getPosition().getX());
            Canvas.SetTop(ima1, shot.getPosition().getY());
            shot.setImage(ima1);
            return ima1;
        }
        public Object WykonajNaBigTShot(BigTShot shot,Canvas canvas, Object ob = null) {
            ima1 = new Image
            {

            };
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("/Files/BigTShot.png", UriKind.Relative);
            bi1.EndInit();
            ima1.Source = bi1;
            canvas.Children.Add(ima1);
            Canvas.SetLeft(ima1, shot.getPosition().getX());
            Canvas.SetTop(ima1, shot.getPosition().getY());
            shot.setImage(ima1);
            return ima1;
        }
    }
}
