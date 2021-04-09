using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
   public class Point
    {
        private double x;
        private double y;
        public Point() { }
        public Point(double xx,double yy) { x = xx;y = yy; }

        public double getX() { return x; }
        public void setX(double xx) { x = xx; }
        public double getY() { return y; }
        public void setY(double yy) { y = yy; }
    }
}
