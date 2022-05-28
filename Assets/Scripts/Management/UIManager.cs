using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Transform purchaseItemCarrier;

    private void Start()
    {
        LoadPurchasableItem();
    }
    public void LoadPurchasableItem()
    {
        foreach (Transform item in purchaseItemCarrier)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in GameData.instance.purchasableItemProfiles)
        {
         GameObject purchaseItem=Instantiate(GameData.instance.purchaseItemPrefab, purchaseItemCarrier);
           if(purchaseItem.TryGetComponent(out PurchasableItem purchasable))
            {
                purchasable.UpdateItem(item);
            }
        }
    }
}
