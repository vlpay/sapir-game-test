using System;
using UnityEngine;

namespace _Project._Scripts.Core.TargetHitting
{
    public class Target: MonoBehaviour, IDetectPlayer
    {
        public event Action OnPlayerHit;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Попадание!");
                OnPlayerHit?.Invoke();
            }
        }
    }
}