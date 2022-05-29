using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameElement.UI 
{
    public class BuyCarItem : MonoBehaviour
    {
        public Image carIcon;
        [HideInInspector()]
        public CarProfileSO Represented;
        public Image focusImage;

        public void SetData(CarProfileSO carProfileSO) 
        {
            Represented = carProfileSO;
            carIcon.sprite = carProfileSO.carIcon;
        }

        public void OnClick() 
        {
            Events.onBuyMenuCarSelected?.Invoke(Represented);
        }

        public void ChangeFocusImage(bool status) 
        {
            focusImage.color = status ? GameData.instance.uiItems.buyCaritemFocusColor : GameData.instance.uiItems.buyCaritemNormalColor;
        }

    }
}


