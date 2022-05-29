using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameElement.UI 
{
    public class BuyCarItem : MonoBehaviour
    {
        public Image carIcon;

        public void SetData(CarProfileSO carProfileSO) 
        {
            carIcon.sprite = carProfileSO.carIcon;
           // carName.text = carProfileSO.CarName;
          //  carPrice.text= string.Format("Price : {0:C}", carProfileSO.Price);
        }

    }
}


