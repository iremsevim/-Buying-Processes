using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static ProfileData CarProfileData;

    private void Awake()
    {
        LoadData();
    }
    public static void SaveData() 
    {
        string saveJson = JsonUtility.ToJson(CarProfileData);
        PlayerPrefs.SetString("Save", saveJson);
    }
    public static ProfileData LoadData() 
    {
        string json = PlayerPrefs.GetString("Save");
        if (string.IsNullOrEmpty(json)) {
            CarProfileData.money = 100000;
            CarProfileData.ownedCarIDs = new List<string>();
            return CarProfileData;
        }
        CarProfileData = JsonUtility.FromJson<ProfileData>(json);
        return CarProfileData;
    }

    public static  void AddOwnedCar(string ID)
    {
        CarProfileData.ownedCarIDs.Add(ID);

    }

    [System.Serializable]
    public struct ProfileData 
    {
        public int money;
        public List<string> ownedCarIDs;
    }
}
