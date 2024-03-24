namespace SVM_BirthdayNotifications
{
    internal class ModConfig
    {
        public bool NotifyUnknownNPCs = false;
        public bool RecommendGift = false;
        public bool DatableNPCsOnly = false;
        public int MinimumFriendshipHeartLevel = 2;
        public string[] ExcludedNPCs = Array.Empty<string>();
    }
}
