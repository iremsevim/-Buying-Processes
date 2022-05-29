using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameElement.UI;

public class UIManager : MonoBehaviour
{
    public Transform buyCarItemCarrier;

   public void LoadBuyCarData() 
    {
        foreach (Transform item in buyCarItemCarrier)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in GameData.instance.carProfiles)
        {
            var createdCar = Instantiate(GameData.instance.uiItems.uiBuyCarItemPrefab, buyCarItemCarrier);
            if (createdCar.TryGetComponent(out BuyCarItem buyCarItem))
                buyCarItem.SetData(item);
            
        }
    }
}
