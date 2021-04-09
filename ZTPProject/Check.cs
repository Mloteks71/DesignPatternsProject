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
    class Check:Metoda
    {
        public Object WykonajNaSingle(SingleShot shott, Canvas canvas,Object obj)
        {
            Image target = (Image)obj;
            Image shot = shott.getImage();
            var a = Canvas.GetTop(shot);//a
            var b = Canvas.GetLeft(shot);//b
            var c = shot.ActualHeight + a;//c
            var d = shot.ActualWidth + b;//d
            var e = Canvas.GetTop(target);//e
            var f = Canvas.GetLeft(target);//f
            var g = target.ActualHeight + e;//g
            var h = target.ActualWidth + f;//h
            if (((a <= g && a >= e) || (c <= g && c >= e)) && ((b <= h && b >= f) || (d <= h && d >= f)))
                return true;
            return false;
        }
        public Object WykonajNaTShot(TShot shott, Canvas canvas, Object obj)
        {
            Image target = (Image)obj;
            Image shot = shott.getImage();
            var a = Canvas.GetTop(shot);//a
            var b = Canvas.GetLeft(shot)+8;//b
            var c = 32 + a;//c
            var d = 8 + b;//d
            var e = Canvas.GetTop(target);//e
            var f = Canvas.GetLeft(target);//f
            var g = 79 + e;//g
            var h = 85 + f;//h
            var k = b - 8;//k
            var l = d + 8;//l
            var m = a + 8;//m
            bool jeden= ((a <= g && a >= e) || (c <= g && c >= e)) && ((b <= h && b >= f) || (d <= h && d >= f));
            bool dwa = ((k >= f && k <= h) || (l >= f && l <= h)) && ((m <= g && m >= e) || (a <= g && a >= e));
            if (false||dwa)
                return true;
            return false;
        }
        public Object WykonajNaBigTShot(BigTShot shott, Canvas canvas, Object obj)
        {
            Image target = (Image)obj;
            Image shot = shott.getImage();
            var a = Canvas.GetTop(shot);//a
            var b = Canvas.GetLeft(shot) + 16;//b
            var c = 48 + a;//c
            var d = 8 + b;//d
            var e = Canvas.GetTop(target);//e
            var f = Canvas.GetLeft(target);//f
            var g = 79 + e;//g
            var h = 85 + f;//h
            var k = b - 16;//k
            var l = d + 16;//l
            var m = a + 8;//m
            bool jeden = ((a <= g && a >= e) || (c <= g && c >= e)) && ((b <= h && b >= f) || (d <= h && d >= f));
            bool dwa = ((k >= f && k <= h) || (l >= f && l <= h)) && ((m <= g && m >= e) || (a <= g && a >= e));
            if (jeden || dwa)
                return true;
            return false;
        }
    }
}
