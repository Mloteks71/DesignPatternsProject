using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ZTPProject
{
    class Normal:Difficulty
    {
        public override double getMoneyMultiplier()
        {
            return 1;
        }
        public override double getScoreMultiplier()
        {
            return 1;
        }
        public override EnemyList enemyGenerate(EnemySpaceShip[] enemyList)
        {
            int l1 = 9;
            int l2 = 9;
            int l3 = 2;
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
            return new EnemyList(lista);
        }
        public override BitmapImage getBackground()
        {
            return new BitmapImage(new Uri("../../../Files/SpaceBlue.jpg", UriKind.Relative));
        }
    }
}
