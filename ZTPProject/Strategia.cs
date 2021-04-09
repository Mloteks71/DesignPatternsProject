using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ZTPProject
{
    abstract public class Strategia
    {
        public abstract void Poruszanie(EnemySpaceShip enemy);
        public abstract Strategia DeepCopy();
    }

    class Teleportacja : Strategia
    {
        private Random rnd = new Random();
        private bool isRight = true;
        int time = 0;
        public override Strategia DeepCopy()
        {
            Strategia str = new Teleportacja();
            return str;
        }
        public override void Poruszanie(EnemySpaceShip enemy) {
           
            if (time<=0) {
                Image ima = new Image
                {

                };
                ima = enemy.getImage();

                if (Canvas.GetLeft(ima) > (600 - 180))
                {
                    isRight = false;
                }
                if (Canvas.GetLeft(ima) < 75)
                {
                    isRight = true;
                }
                int pom = rnd.Next(1, 3);
                if (isRight == true&&pom==1)
                {
                    Canvas.SetLeft(ima, Canvas.GetLeft(ima) + 75);
                }
                else if(Canvas.GetLeft(ima) > 75)
                {
                    Canvas.SetLeft(ima, Canvas.GetLeft(ima) - 75);
                }
                else
                {
                    Canvas.SetLeft(ima, Canvas.GetLeft(ima) + 75);
                }
                time = 45;
            }
            else
            {
                time--;
            }
        }
    }

    class PoosiX : Strategia
    {
        public override Strategia DeepCopy()
        {
            Strategia str = new PoosiX();
            return str;
        }
        private bool isRight = true;
        public override void Poruszanie(EnemySpaceShip enemy) {
            Image ima = new Image
            {

            };
            ima = enemy.getImage();
            if (Canvas.GetLeft(ima)>(310))
            {
                isRight = false;
            }
            if (Canvas.GetLeft(ima) < 0)
            {
                isRight = true;
            }
            if(isRight == true)
            { 
                Canvas.SetLeft(ima, Canvas.GetLeft(ima) + 10);  
            }
           else {
                Canvas.SetLeft(ima, Canvas.GetLeft(ima) - 10);
            }
        }
    }

    class PoosiachXY : Strategia
    {
        public override Strategia DeepCopy()
        {
            Strategia str = new PoosiachXY();
            return str;
        }
        private bool isRight = true;
        private bool isBot = true;
        public override void Poruszanie(EnemySpaceShip enemy) {
            Image ima = new Image
            {

            };
            ima = enemy.getImage();
            if (Canvas.GetLeft(ima) > (600 - 105))
            {
                isRight = false;
            }
            if (Canvas.GetLeft(ima) < 0)
            {
                isRight = true;
            }
            if (isRight == true)
            {
                Canvas.SetLeft(ima, Canvas.GetLeft(ima) + 5);
            }
            else
            {
                Canvas.SetLeft(ima, Canvas.GetLeft(ima) - 5);
            }

            if (Canvas.GetTop(ima) < (0))
            {
                isBot = true;
            }
            if (Canvas.GetTop(ima) > 100)
            {
                isBot = false;
            }
            if (isBot == true)
            {
                Canvas.SetTop(ima, Canvas.GetTop(ima) + 5);
            }
            else
            {
                Canvas.SetTop(ima, Canvas.GetTop(ima) - 5);
            }

        }
    }

    class Szarża : Strategia
    {
        public override Strategia DeepCopy()
        {
            Strategia str = new Szarża();
            return str;
        }
        public override void Poruszanie(EnemySpaceShip enemy) {
          
          
                Image ima = new Image
                {

                };
                ima = enemy.getImage();
                Canvas.SetTop(ima, Canvas.GetTop(ima) + 10);
               
            
        }
    }

    class Nieruchome : Strategia
    {
        public override Strategia DeepCopy()
        {
            Strategia str = new Nieruchome();
            return str;
        }
        public override void Poruszanie(EnemySpaceShip enemy) { }
    }
}
