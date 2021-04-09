using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    abstract class Bought : Player
    {
        private Player player;
        override public Player getPlayer() { return player; }
        public void setPlayer(Player pla) { player = pla; }
        override abstract public float getDamage();
        override abstract public double getMoneyMultiplier();
        override public void setHealthPoints(int hp) { player.setHealthPoints(hp); }
        override public int getHealthPoints() { return player.getHealthPoints(); }
        override public void setPosition(Point pos) { player.setPosition(pos); }
        override public Point getPosition() { return player.getPosition(); }
        override public double getMoney() { return player.getMoney(); }
        override public void setMoney(double mon) { player.setMoney(mon); }
        override public void setMoneyMultiplier(double mon) { player.setMoneyMultiplier(mon); }

    }
}
