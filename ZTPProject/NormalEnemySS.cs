using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ZTPProject
{
    class NormalEnemySS:EnemySpaceShip
    {
        public NormalEnemySS() {; }
        public NormalEnemySS(NormalEnemySS ss) { this.setPosition(ss.getPosition()); this.setHealthPoints(ss.getHealthPoints()); this.setDamage(ss.getDamage()); this.setMoney(ss.getMoney()); this.setStrategia(ss.getIStrategia()); this.setImage(ss.getImage()); this.setImgString(ss.getImgString()); }

        public override EnemySpaceShip clone()
        {

            return new NormalEnemySS(this);

        }
        public override void move()
        {
            throw new NotImplementedException();
        }
    }
}
