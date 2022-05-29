using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameElement.Gallery;
using System.Linq;
namespace GameElement.UI
{

    public class GalleryPanel : MonoBehaviour
    {
        public Text carName;
        public Text carPrice;
        public Button buyButton;
        private List<BuyCarItem> buyCarItems;
        public Transform buyCarItemCarrier;

        private void Start()
        {
            LoadBuyCarData();
        }

        public void LoadBuyCarData()
        {
            foreach (Transform item in buyCarItemCarrier)
            {
                Destroy(item.gameObject);
            }

            buyCarItems = new List<BuyCarItem>();

            foreach (var item in GameData.instance.carProfiles)
            {
                var createdCar = Instantiate(GameData.instance.uiItems.uiBuyCarItemPrefab, buyCarItemCarrier);
                if (createdCar.TryGetComponent(out BuyCarItem buyCarItem))
                {
                    buyCarItem.SetData(item);
                    buyCarItems.Add(buyCarItem);
                }
            }
        }

        public void OnEnable()
        {
            Events.onBuyMenuCarSelected += OnCarSelected;
        }
        public void OnDisable()
        {
            Events.onBuyMenuCarSelected -= OnCarSelected;
        }
        public  void OnCarSelected(CarProfileSO selectedCar)
        {
            carName.text = selectedCar.CarName;
            carPrice.text = string.Format("Price : {0:C}", selectedCar.Price);
            foreach (var item in buyCarItems)
            {
                item.ChangeFocusImage(selectedCar ==item.Represented);
            }

            buyButton.gameObject.SetActive(!SaveManager.CarProfileData.ownedCarIDs.Any(x => x.Equals(selectedCar.CarID)));
            
        }

        public void BuyButtonClick()
        {
             
            if(IsHasMoney(GalleryController.lastDisplayingCarSO.Price))
            {
                IncreseMoney(GalleryController.lastDisplayingCarSO.Price);
                SaveManager.AddOwnedCar(GalleryController.lastDisplayingCarSO.CarID);
                GameData.instance.save.ownedCars.Add(GalleryController.lastDisplayingCarSO);
                SaveManager.SaveData();

            }
        }


        public bool IsHasMoney(int amount) => SaveManager.CarProfileData.money >= amount;

        public void IncreseMoney(int amount) 
        {
            if (SaveManager.CarProfileData.money <= 0 || SaveManager.CarProfileData.money < amount) return;
            SaveManager.CarProfileData.money -= amount;
        }
        public void DecreaseMoney(int amount) 
        {
            SaveManager.CarProfileData.money += amount;
        }

    }
}