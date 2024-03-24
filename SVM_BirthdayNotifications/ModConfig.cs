namespace SVM_BirthdayNotifications
{
    internal class ModConfig
    {
        public bool NotifyForUnknownNPCs = false;
        public bool RecommendGift = true;
        public bool DatableNPCsOnly = false;
        public int MinimumFriendshipHeartLevel = 1;
        public int MinimumFriendshipHeartLevelForGiftRecommendations = 2;
        public string[] ExcludedNPCs = Array.Empty<string>();
    }
}