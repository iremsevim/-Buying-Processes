using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public List<CarProfileSO> carProfiles;
    public UI uiItems;

    [System.Serializable]
    public struct UI 
    {
        public GameObject uiBuyCarItemPrefab;
    }

}
