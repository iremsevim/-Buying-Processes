using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableItem : MonoBehaviour
{
    public Text itemColor;
    public Image colorImage;
    public GameObject itemLockStatus;

    public void UpdateItem(GameData.PurchasableItemProfile purchasableItemProfile)
    {
        itemColor.text = purchasableItemProfile.colorName;
        colorImage.color = purchasableItemProfile.color;
        itemLockStatus.SetActive(purchasableItemProfile.lockStatus);

    }
}
