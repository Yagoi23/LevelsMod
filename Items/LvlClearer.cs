using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevelsMod.Items
{
	public class LvlClearer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lvl Clearer");
			Tooltip.SetDefault("Clears your levels");
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
			player.GetModPlayer<StatsPlayer>().DMGSkill = 0;
			player.GetModPlayer<StatsPlayer>().DefenseSkill = 0;
			player.GetModPlayer<StatsPlayer>().SpeedSkill = 0;
			player.GetModPlayer<StatsPlayer>().JumpSkill = 0;
			Main.NewText("Damage Lvl " + player.GetModPlayer<StatsPlayer>().DMGSkill, Color.Red, false);
			Main.NewText("Defense Lvl " + player.GetModPlayer<StatsPlayer>().DefenseSkill, Color.Red, false);
			Main.NewText("Speed Lvl " + player.GetModPlayer<StatsPlayer>().SpeedSkill, Color.Red, false);
			Main.NewText("Jump Lvl " + player.GetModPlayer<StatsPlayer>().JumpSkill, Color.Red, false);
			return true;
		}

	}
}
