using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevelsMod.Items
{
	public class SpeedBoostingBroth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Speed Boosting Broth");
			Tooltip.SetDefault("A foul tasting broth that boosts your ability to run.");
		}
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 32;
			item.maxStack = 99;
			item.rare = ItemRarityID.Red;
			item.useAnimation = 15;
			item.useTime = 15;
			item.value = 50000;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<StatsPlayer>().SpeedSkill += 1;
			Main.NewText("Speed Lvl is now " + player.GetModPlayer<StatsPlayer>().SpeedSkill, Color.Green, false);
			return true;
		}

	}
}
