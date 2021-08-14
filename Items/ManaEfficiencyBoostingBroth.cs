using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevelsMod.Items
{
	public class ManaEfficiencyBoostingBroth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Efficiency Boosting Broth");
			Tooltip.SetDefault("A foul tasting broth that boosts your mana efficiency.");
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
			player.GetModPlayer<StatsPlayer>().ManaEffSkill += 1;
			Main.NewText("Mana Efficiency Lvl is now " + player.GetModPlayer<StatsPlayer>().ManaEffSkill, Color.Green, false);
			return true;
		}

	}
}
