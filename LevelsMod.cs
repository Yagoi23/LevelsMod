using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace LevelsMod
{
	public class LevelsMod : Mod
	{
		internal SkillsPannel skillsPannel;
		public UserInterface skillsInterface;
		public override void UpdateUI(GameTime gameTime)
		{
			if (!Main.gameMenu && SkillsPannel.visible)
			{
				skillsInterface?.Update(gameTime);
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			layers.Add(new LegacyGameInterfaceLayer("Cool Mod: Something UI", DrawSkillsPannel, InterfaceScaleType.UI));
		}

		private bool DrawSkillsPannel()
		{
			// it will only draw if the player is not on the main menu
			if (!Main.gameMenu && SkillsPannel.visible)
			{
				skillsInterface.Draw(Main.spriteBatch, new GameTime());
			}
			return true;
		}
	}
}