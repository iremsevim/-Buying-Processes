using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CarProfile",menuName = "BuyProcesses/CarProfile")]
public class CarProfileSO : ScriptableObject
{
    public string CarID;
    public string CarName;
    public Sprite carIcon;
    public GameObject CarPrefab;
    public int Price;
    
}
