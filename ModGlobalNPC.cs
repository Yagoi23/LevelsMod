
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LevelsMod
{
	public class ModGlobalNPC : GlobalNPC
	{


		public override void OnHitPlayer(NPC npc, Player player, int damage, bool crit)
		{
			player.GetModPlayer<StatsPlayer>().DefenseXP += (int)(damage);
			if(player.GetModPlayer<StatsPlayer>().DefenseXP > (float)((player.GetModPlayer<StatsPlayer>().DefenseSkill * 50) + (player.GetModPlayer<StatsPlayer>().DefenseSkill * player.GetModPlayer<StatsPlayer>().DefenseSkill))){
				player.GetModPlayer<StatsPlayer>().DefenseXP = 0;
				player.GetModPlayer<StatsPlayer>().DefenseSkill += 1;
				Main.NewText("Defense Lvl is now " + player.GetModPlayer<StatsPlayer>().DefenseSkill, Color.Green, false);
			}
		}
	}
}
