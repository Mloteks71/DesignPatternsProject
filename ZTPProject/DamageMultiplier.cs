using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    class DamageMultiplier : Bought
    {
        int i = 0;
        public DamageMultiplier(Player player1) { setPlayer(player1); }
        override public float getDamage() { return getPlayer().getDamage() * 1.2f; }
        override public double getMoneyMultiplier() { return getPlayer().getMoneyMultiplier(); }
    }
}
