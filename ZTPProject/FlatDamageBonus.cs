using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    class FlatDamageBonus : Bought
    {
        int i = 0;
        public FlatDamageBonus(Player player1) { setPlayer(player1); }
        override public float getDamage() { return getPlayer().getDamage() + 1.0f; }
        override public double getMoneyMultiplier() { return getPlayer().getMoneyMultiplier();  }
    }
}
