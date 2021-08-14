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
	}
}
