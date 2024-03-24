using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

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
            if (DisplayNotification(BirthdayChild, config))
            {
                string DisplayName = BirthdayChild.Name[^1] == 's' ? BirthdayChild.Name : BirthdayChild.Name + 's';
                string Pronoun = BirthdayChild.Gender == 0 ? Helper.Translation.Get("pronoun.male") : Helper.Translation.Get("pronoun.female");
                string _ = Helper.Translation.Get("notification-message.basic");
                string Notification = _.Replace("{name}", DisplayName);
                if (config.RecommendGift)
                {
                    _ = Helper.Translation.Get("notification-message.recommend-gift");
                    Notification += _.Replace("{pronoun}",Pronoun).Replace("{gift}", BirthdayChild.getFavoriteItem().DisplayName);
                }

                Game1.addHUDMessage(new HUDMessage(Notification,HUDMessage.newQuest_type));
            }
        }


        /// <summary>Checks if the notification should be displayed.</summary>
        /// <param name="npc">The NPC that has its birthday.</param>
        /// <param name="config">The current active mod config.</param>
        private static bool DisplayNotification(NPC npc, ModConfig config)
        {
            bool notifyIfKnown = config.NotifyUnknownNPCs || GameStateQuery.CheckConditions($"PLAYER_HAS_MET Current {npc.Name}");
            bool notifyIfDatable = !config.DatableNPCsOnly || npc.GetData().CanBeRomanced;

            return notifyIfKnown && notifyIfDatable;
        }
    }
}