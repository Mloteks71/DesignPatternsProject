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
  abstract public class IShot
    {
        private Point position;
        private Image ima;
        private int damage;
        public void setDamage(int i) { damage = i; }
        public int getDamage() { return damage; }

        public Point getPosition() { return position; }
        public void setPosition(Point pos) { position = pos; }
        public Image getImage() { return ima; }
        public void setImage(Image ima1) { ima = ima1; }
        abstract public Object wykonaj(Metoda metoda,Canvas canvas,Object ob=null);
    }
}
