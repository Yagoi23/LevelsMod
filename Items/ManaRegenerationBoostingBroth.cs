using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LevelsMod.Items
{
	public class ManaRegenerationBoostingBroth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Regeneration Boosting Broth");
			Tooltip.SetDefault("A foul tasting broth that boosts your mana regeneration.");
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
			player.GetModPlayer<StatsPlayer>().ManaRGNSkill += 1;
			Main.NewText("Mana Regeneration Lvl is now " + player.GetModPlayer<StatsPlayer>().ManaRGNSkill, Color.Green, false);
			return true;
		}

	}
}
