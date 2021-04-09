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
    public interface Metoda
    {
        Object WykonajNaSingle(SingleShot shot,Canvas canvas,Object ob=null);
        Object WykonajNaTShot(TShot shot, Canvas canvas, Object ob=null);
        Object WykonajNaBigTShot(BigTShot shot, Canvas canvas, Object ob=null);
    }
}
