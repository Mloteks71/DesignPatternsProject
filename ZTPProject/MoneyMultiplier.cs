using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    class MoneyMultiplier : Bought
    {
        public MoneyMultiplier(Player player1) { setPlayer(player1); }
        override public float getDamage() { return getPlayer().getDamage(); }
        override public double getMoneyMultiplier() { return getPlayer().getMoneyMultiplier() * 2; }
    }
}
