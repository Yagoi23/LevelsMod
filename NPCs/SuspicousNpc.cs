using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using LevelsMod.Items;


namespace LevelsMod.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Miner : ModNPC
	{
		private bool gemShop;
		public override string Texture => "LevelsMod/NPCs/SuspicousNpc";

		public override string[] AltTextures => new[] { "LevelsMod/NPCs/SuspicousNpc" };

		public override bool Autoload(ref string name)
		{
			name = "Suspicous Cloaked Man";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 0;
			NPCID.Sets.DangerDetectRange[npc.type] = 150;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 23;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}


		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return true;
			/*for (int k = 0; k < 255; k++)
			{
	
				//Player player = Main.player[k];
				//if (!player.active)
				//{
				//	continue;
				//}

				foreach (Item item in player.inventory)
				{
					if (item.type == ItemType<ExampleItem>() || item.type == ItemType<Items.Placeable.ExampleBlock>())
					{
						return true;
					}
				}*/
			//}
			//return false;
		}

		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
		/*public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 0;
			for (int x = left - Main.zoneX / 2 / 16 - 1 - Lighting.offScreenTiles; x <= right + Main.zoneX / 2 / 16 + 1 + Lighting.offScreenTiles; x++)
			{
				for (int y = top - Main.zoneY / 2 / 16 - 1 - Lighting.offScreenTiles; y <= bottom + Main.zoneY / 2 / 16 + 1 + Lighting.offScreenTiles; y++)
				{
					int type = Main.tile[x, y].type;
					if (type == TileID.Furnaces)
					{
						score++;
					}
					if (type == TileID.Anvils)
					{
						score += 5;
					}
				}
			}
			return score > 800;
		}*/

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Tod";
				case 1:
					return "Fod";
				case 2:
					return "Hank";
				default:
					return "Frank";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(4))
			{
				case 0:
					return "You wanna buy some? don't worry it's safe to eat.";
				case 1:
					return "Yes those are teeth";
				case 2:
					{
						return "Hey do you have some money I can borrow.";
					}
				default:
					return "What?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
			//button2 = "Other " + Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			shop = true;
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			//Add items for "Shop"
			shop.item[nextSlot].SetDefaults(ItemType<StatTracker>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<DamageBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<CritBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<DefenseBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<EnduranceBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<JumpBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<SpeedBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<ManaRegenerationBoostingBroth>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<ManaEfficiencyBoostingBroth>());

		}

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.


		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (Main.hardMode)
			{
				damage = 70;
				knockback = 3;
			}
			else
			{
				damage = 40;
				knockback = 2;
			}
		}

		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
		{
			scale = 1;
			item = Main.itemTexture[ItemID.NightsEdge];
			itemSize = 32;
		}

		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
		{
			itemWidth = 32;
			itemHeight = 32;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 20;
		}

	}
}