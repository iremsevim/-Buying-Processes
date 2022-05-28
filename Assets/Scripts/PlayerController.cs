using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GameElement.Collectable;
using TMPro;
namespace GameElement.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : Singleton<PlayerController>,ICollector
    {
        #region Variables
        private NavMeshAgent agent;
        public float movementSpeed;
        #region Collector
        public Transform collectorStackPivot;
        public Transform CollectorStackPivot => collectorStackPivot;
        public Transform CollectingParent => transform;
        public TextMeshPro moneyText;
        public int moneyAmount;

        #endregion
        #region Physics
        [SerializeField]  private LayerMask groundLayer;
       private RaycastHit hit;
        private Ray ray;

        #endregion
        #endregion
        private void Awake()
        {
            gameObject.TryGetComponent(out agent);

        }
        
        private void Update()
        {
            GroundClickControl();
        }

        private void GroundClickControl()
        {
          
            if(Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin,ray.direction, out hit,1000,groundLayer))
                {
                    GoToPoint(hit.point);
                }
                 
            }  
        }
        private void GoToPoint(Vector3 pos)
        {
            agent.SetDestination(pos);
            agent.speed = movementSpeed;
            agent.isStopped = false;
            
        }
        private void StopMovement()
        {
            agent.speed = 0;
            agent.isStopped = true;
            agent.SetDestination(transform.position);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out ITriggerListener triggerListener))
            {
           
                triggerListener.OnTriggerEnterTouched(this);
            }
        }

        
        public void OnTouchedCollectable(ICollactable collactable)
        {
           if(collactable is Money money)
            {
                IncreaseMoneyAmount(money.moneyAmount);
            }
        }
        public void IncreaseMoneyAmount(int money)
        {
            moneyAmount += money;
            UpdateMoneyText();
        } 
        public void DecreaseMoneyAmount(int money)
        {
            moneyAmount -= money;
            UpdateMoneyText();
        }
        public void UpdateMoneyText()
        {
            moneyText.text = moneyAmount.ToString();
        }
    }
}
