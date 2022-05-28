using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICollactable : MonoBehaviour, ITriggerListener
{
    public virtual void OnTriggerEnterTouched(MonoBehaviour toucher)
    {
       if(toucher is ICollector collector)
        {
            OnCollectorToched(collector);
            collector.OnTouchedCollectable(this);
        }
    }

    public abstract void OnCollectorToched(ICollector collector);
    

    
}
