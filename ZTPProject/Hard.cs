using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ZTPProject
{
    class Hard:Difficulty
    {
        public override double getMoneyMultiplier()
        {
            return 0.5;
        }
        public override double getScoreMultiplier()
        {
            return 2;
        }
        public override EnemyList enemyGenerate(EnemySpaceShip[] enemyList)
        {
            int l1 = 7;
            int l2 = 6;
            int l3 = 6;
            List<ProxyEnemy> lista = new List<ProxyEnemy>();
            for (int i = 0; i < l1; i++)
            {
                EnemySpaceShip enS = enemyList[1].clone();
                ProxyEnemy en = new ProxyEnemy();
                en.setEnemySpaceShip(enS);
                lista.Add(en);
            }
            for (int i = 0; i < l2; i++)
            {
                EnemySpaceShip enS = enemyList[2].clone();
                ProxyEnemy en = new ProxyEnemy();
                en.setEnemySpaceShip(enS);
                lista.Add(en);
            }
            for (int i = 0; i < l3; i++)
            {
                EnemySpaceShip enS = enemyList[3].clone();
                ProxyEnemy en = new ProxyEnemy();
                en.setEnemySpaceShip(enS);
                lista.Add(en);
            }
            for (int i = 0; i < 1; i++)
            {
                EnemySpaceShip enS = enemyList[4].clone();
                ProxyEnemy en = new ProxyEnemy();
                en.setEnemySpaceShip(enS);
                lista.Add(en);
            }
            return new EnemyList(lista);
        }
        public override BitmapImage getBackground()
        {
            return new BitmapImage(new Uri("../../../Files/Space.jpg", UriKind.Relative));
        }
    }
}
