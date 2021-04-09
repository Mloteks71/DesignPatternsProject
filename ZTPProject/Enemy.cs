using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{

    abstract public class InterfaceEnemy
    {

        public abstract EnemySpaceShip getEnemySpaceShip();
        public abstract void setEnemySpaceShip(EnemySpaceShip enship);
        public abstract int getX();
        public abstract void setX(int x);
        public abstract void Zmieństrategie(Strategia strategy);
        public abstract void porusz();

       
    }
    public class Enemy : InterfaceEnemy
    {
        private EnemySpaceShip enemySpaceShip;
        private Strategia strategy;
        private int x;
        public Enemy() { ; }

          public override EnemySpaceShip getEnemySpaceShip() {return enemySpaceShip; }
          public override void setEnemySpaceShip(EnemySpaceShip enship) {enemySpaceShip=enship;

         }
        public override int getX() { return x; }
        public override void  setX(int x) { this.x = x;
            this.strategy = enemySpaceShip.getIStrategia().DeepCopy();

        }

        public override void  Zmieństrategie(Strategia strategy) { }
     public override void porusz() { strategy.Poruszanie(enemySpaceShip); }


    }

   public  class ProxyEnemy : InterfaceEnemy
    {
        private Enemy enemy=null;
        private EnemySpaceShip enship=null;
        public ProxyEnemy() { }

         public override EnemySpaceShip getEnemySpaceShip() {
            if (enemy == null)
            {
                if (enship != null)
                    return enship;
                else return null;
            }
         return enemy.getEnemySpaceShip() ;
          }
         public override void setEnemySpaceShip(EnemySpaceShip enship) {
            this.enship = enship;
      
        }
        public override int getX() {
            if (enemy == null)
                return 0;
            return enemy.getX();
     
        }
        public override void setX(int x) {
            if (enemy == null)
            {
                enemy = new Enemy();
                enemy.setEnemySpaceShip(enship);
               enship = null;           
            }
            enemy.setX(x);
                }
  
        public override void Zmieństrategie(Strategia strategy) { enemy.Zmieństrategie(strategy); }
        public override void porusz() { enemy.porusz(); }

    }
}
