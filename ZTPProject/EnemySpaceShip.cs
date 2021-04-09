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
    abstract public class EnemySpaceShip
    {
        private Point position;
        private float healthPoints;
        private int damage;
        private int money;
        private Strategia strategia;
        private Image ima;
        private String imgname;
        private int cd;
        public void setCD(int newcd) { cd = newcd; }
        public int getCD() { return cd; }
        public void setImgString(String imgname) { this.imgname = imgname; }
        public String getImgString() { return imgname; }
        public void setImage(Image ima1) { ima = ima1; }
        public Image getImage() { return ima; }
        public void setStrategia(Strategia str) { strategia=str; }
        public Strategia getIStrategia() { return strategia; }
        public Point getPosition() { return position; }
        public void setPosition(Point pos) { position = pos; }
        public int getDamage() { return damage; }
        public void setDamage(int dam) { damage = dam; }
        public int getMoney() { return money; }
        public void setMoney(int mon) { money=mon; }
        public float getHealthPoints() { return healthPoints; }
        public void setHealthPoints(float HP) { healthPoints=HP; }

        public virtual List<IShot> shoot(List<IShot> list, Canvas canvas) {return list; }
        public void addIShot(IShot iSht) {; }
        public abstract EnemySpaceShip clone();
        public abstract void move();
    }
}
