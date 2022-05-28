using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollector 
{
    public Transform CollectingParent { get; }
    public Transform CollectorStackPivot { get; }

    public void OnTouchedCollectable(ICollactable collactable);
}
