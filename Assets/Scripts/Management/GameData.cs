using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public List<CarProfileSO> carProfiles;
    public UI uiItems;
    public Save save;

    private void Start()
    {
        LoadOwnedCars();
    }

    private void LoadOwnedCars() 
    {
        foreach (var item in SaveManager.CarProfileData.ownedCarIDs)
        {
            if (string.IsNullOrEmpty(item)) continue;
           save.ownedCars.Add(carProfiles.Find(x => x.CarID == item));
        }
    }

    [System.Serializable]
    public struct UI 
    {
        public GameObject uiBuyCarItemPrefab;
        public Color32 buyCaritemFocusColor;
        public Color32 buyCaritemNormalColor;
    }
    [System.Serializable]
    public struct Save 
    {
        public List<CarProfileSO> ownedCars;
    }
}
