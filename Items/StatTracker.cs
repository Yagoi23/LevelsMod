using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevelsMod.Items
{
	public class StatTracker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stat Tracker");
			Tooltip.SetDefault("Displays your levels");
		}
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 32;
			item.maxStack = 1;
			item.rare = ItemRarityID.Red;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			//item.UseSound = SoundID.Item3;
			item.consumable = false;
		}

		public override bool UseItem(Player player)
		{
			Main.NewText("Damage Lvl " + player.GetModPlayer<StatsPlayer>().DMGSkill, Color.Purple, false);
			Main.NewText("Defense Lvl " + player.GetModPlayer<StatsPlayer>().DefenseSkill, Color.Purple, false);
			Main.NewText("Speed Lvl " + player.GetModPlayer<StatsPlayer>().SpeedSkill, Color.Purple, false);
			Main.NewText("Jump Lvl " + player.GetModPlayer<StatsPlayer>().JumpSkill, Color.Purple, false);
			return true;
		}

	}
}
