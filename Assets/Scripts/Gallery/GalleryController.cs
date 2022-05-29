using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameElement.Gallery
{
    public class GalleryController : MonoBehaviour
    {
        private GameObject currentDisplayinCar;
        public static CarProfileSO lastDisplayingCarSO;
        public Transform createdCarPoint;


        private void OnEnable()
        {
            Events.onBuyMenuCarSelected += OnCarSelected;
        }
        private void OnDisable()
        {
            Events.onBuyMenuCarSelected -= OnCarSelected;
        }

        public async void OnCarSelected(CarProfileSO selectedCar) 
        {
            if(currentDisplayinCar)
            {
                Destroy(currentDisplayinCar);
            }
            lastDisplayingCarSO = selectedCar;
            currentDisplayinCar = Instantiate(selectedCar.CarPrefab, createdCarPoint.position,Quaternion.Euler(0,180,0),transform);
            await currentDisplayinCar.transform.DOPunchScale(currentDisplayinCar.transform.localScale, 0.25f, 4).AsyncWaitForCompletion();
        }



    }
}
