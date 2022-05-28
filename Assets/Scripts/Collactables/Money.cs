using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameElement.Player;
using DG.Tweening;
namespace GameElement.Collectable
{

    public class Money : ICollactable
    {
        public int moneyAmount;
        public void GoStackPosition(ICollector collector)
        {
       
            transform.SetParent(collector.CollectingParent);
            transform.DOLocalMove(collector.CollectorStackPivot.localPosition, 0.5f).OnComplete(() => 
            {
                transform.localEulerAngles = collector.CollectorStackPivot.localEulerAngles;
            });
            
        }

        public override void OnCollectorToched(ICollector collector)
        {
            GoStackPosition(collector);
        }
    }
}
