using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace LevelsMod
{
	public class ModGlobalProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC npc, int damage, float knockback, bool crit)
		{
			Player player = new Player();
			player = Main.player[projectile.owner];
			player.GetModPlayer<StatsPlayer>().DMGXP += (int)(damage / 5);
			if(player.GetModPlayer<StatsPlayer>().DMGXP > (float)((player.GetModPlayer<StatsPlayer>().DMGSkill * 650) + (player.GetModPlayer<StatsPlayer>().DMGSkill * 6 * player.GetModPlayer<StatsPlayer>().DMGSkill))){
				player.GetModPlayer<StatsPlayer>().DMGXP = 0;
				player.GetModPlayer<StatsPlayer>().DMGSkill += 1;
				Main.NewText("Damage Lvl is now " + player.GetModPlayer<StatsPlayer>().DMGSkill, Color.Green, false);
			}

		}
	}
}