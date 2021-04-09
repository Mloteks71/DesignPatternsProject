using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    abstract public class Iterator
    {
        public abstract Object Next();
        public abstract bool hasNext();
    }

    public class EnemysIterator : Iterator
    {
        private Random rnd = new Random();
        private List<ProxyEnemy> Enemies;
        public EnemysIterator(List<ProxyEnemy> Enemies) { this.Enemies = Enemies; }
        public override Object Next() {
            if (Enemies.Count > 1)
            {
                var index = rnd.Next(0, Enemies.Count - 1);
                ProxyEnemy enemy = Enemies[index];
                Enemies.Remove(enemy);
                return enemy;
            }
            else
            {
                ProxyEnemy enemy = Enemies[0];
                Enemies.Remove(enemy);
                return enemy;
            }
        }
        public override bool hasNext(){
            if (Enemies.Count<=0)
                return false;
            else
                return true;
        }
       

    }

    abstract public class IList
    {
        public abstract Iterator CreateIterator();
    }

    public class EnemyList : IList
    {
        private List<ProxyEnemy> Enemies;
        public EnemyList(List<ProxyEnemy> list) { Enemies = list; }
        public void setEnemies(List<ProxyEnemy> list) { Enemies = list; }
        public List<ProxyEnemy> GetEnemies() { return Enemies; }
        public override Iterator CreateIterator() { return new EnemysIterator(Enemies); }
        public int Count()
        {
            return Enemies.Count;
        }
    }
}
