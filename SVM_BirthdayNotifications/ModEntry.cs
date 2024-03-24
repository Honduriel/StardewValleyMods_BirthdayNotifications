using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using SVM_BirthdayNotifications;

namespace SVM_BirthdayNotifications
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        public ModConfig config;
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += OnDayStarted;
            this.config = this.Helper.ReadConfig<ModConfig>();
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the day started.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            NPC BirthdayChild = Utility.getTodaysBirthdayNPC();

            if (config.NotifyUnknownNPCs || Game1.player.hasPlayerTalkedToNPC(BirthdayChild.Name))
            {
                string DisplayName = BirthdayChild.Name[^1] == 's' ? BirthdayChild.Name : BirthdayChild.Name + 's';
                string Pronoun = BirthdayChild.Gender == 0 ? "He" : "She";

                Game1.addHUDMessage(new HUDMessage($"It's {DisplayName} birthday! {Pronoun} likes {BirthdayChild.getFavoriteItem().DisplayName}",HUDMessage.newQuest_type));
            }
        }
    }
}