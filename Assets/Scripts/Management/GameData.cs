using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public List<PurchasableItemProfile> purchasableItemProfiles;
    public GameObject purchaseItemPrefab;

    [System.Serializable]
    public struct PurchasableItemProfile
    {
        public Color32 color;
        public string colorName;
        public bool lockStatus;
    }
}
