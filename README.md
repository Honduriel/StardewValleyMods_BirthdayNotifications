# SVM_BirthdayNotifications
Get notified on wakeup when it's someones birthday!

## How to use the mod:
Navigate to "\%SteamLibrary%\steamapps\common\Stardew Valley\Mods\SVM_BirthdayNotifications" and open "config.json". The default file should look like this:

```json
﻿{
  "NotifyUnknownNPCs": false,
  "RecommendGift": true,
  "DatableNPCsOnly": false,
  "MinimumFriendshipHeartLevel": 1,
  "MinimumFriendshipHeartLevelForGifts": 2,
  "ExcludedNPCs": []
}
```

With these setting you will get notifications if you met the person and have at least one heart of friendship. At 2 hearts you will also get a recommendation for a gift. This seemed like the most natural way to set it up.

### Chose whether to get notified even if you didn't meet the person yet:
```json
"NotifyUnknownNPCs": false,
```
Possible values: false or true.
Default value is false.


### Chose whether or not to get a gift recommendation:
```json
﻿"RecommendGift": false,
```
Possible values:  or true.
Default value is false.


### Chose between notifications for all NPCs or just those you can date:
```json
﻿"DatableNPCsOnly": false,
```
Possible values:  or true.
Default value is false.

### Chose a minimum friendship level to get notifications:
```json
﻿"MinimumFriendshipHeartLevel": 1,
```
Possible values: Between 0 and 10. 0 equals "Always notify".
Default value is 1.

### Chose a minimum friendship level to get gift recommendations:
```json
﻿"MinimumFriendshipHeartLevelForGifts": 2,
```
Possible values: Between 0 and 10. 0 equals "Always notify".
Default value is 2.

### Exclude NPCs to not get notifications for their birthday:
```json
﻿"ExcludedNPCs": ["Haley", "Alex"],
```
Possible values: See example above, write names in quotation marks inside the squared brackets, separated by commas.
Default value is empty (Don't exclude any notifications)

