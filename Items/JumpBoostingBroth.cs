using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevelsMod.Items
{
	public class JumpBoostingBroth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jump Boosting Broth");
			Tooltip.SetDefault("A foul tasting broth that boosts your defense.");
		}
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 32;
			item.maxStack = 99;
			item.rare = ItemRarityID.Red;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<StatsPlayer>().JumpSkill += 1;
			Main.NewText("Jump Lvl is now " + player.GetModPlayer<StatsPlayer>().JumpSkill, Color.Green, false);
			return true;
		}

	}
}
