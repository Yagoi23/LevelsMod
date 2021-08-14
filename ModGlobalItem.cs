using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace LevelsMod
{
	public class ModGlobalItem : GlobalItem
	{
		public override void OnHitNPC(Item item, Player player, NPC npc, int damage, float knockback, bool crit)
		{
			player.GetModPlayer<StatsPlayer>().DMGXP += (int)(damage / 5);
			if(player.GetModPlayer<StatsPlayer>().DMGXP > (float)((player.GetModPlayer<StatsPlayer>().DMGSkill * 650) + (player.GetModPlayer<StatsPlayer>().DMGSkill * 6 * player.GetModPlayer<StatsPlayer>().DMGSkill))){
				player.GetModPlayer<StatsPlayer>().DMGXP = 0;
				player.GetModPlayer<StatsPlayer>().DMGSkill += 1;
				Main.NewText("Damage Lvl is now " + player.GetModPlayer<StatsPlayer>().DMGSkill, Color.Green, false);
			}
		}
        public override void OnConsumeMana(Item item, Player player, int manaConsumed)
        {
            //base.OnConsumeMana(item, player, manaConsumed);
			player.GetModPlayer<StatsPlayer>().ManaEffXP += (int)(manaConsumed / 5);
			if (player.GetModPlayer<StatsPlayer>().ManaEffXP > (float)((player.GetModPlayer<StatsPlayer>().ManaEffSkill * 650) + (player.GetModPlayer<StatsPlayer>().ManaEffSkill * 6 * player.GetModPlayer<StatsPlayer>().ManaEffSkill)))
			{
				player.GetModPlayer<StatsPlayer>().ManaEffXP = 0;
				player.GetModPlayer<StatsPlayer>().ManaEffSkill += 1;
				Main.NewText("Mana Efficiency Lvl is now " + player.GetModPlayer<StatsPlayer>().ManaEffSkill, Color.Green, false);
			}
		}
    }
}
