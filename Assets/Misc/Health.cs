using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    
    public class Health : MonoBehaviour
    {
        [SerializeField] private int currentHealth = 10;
        //[SerializeField] private bool destroyOnZeroHealth = true;

        public UnityEvent OnTakeDamage = new UnityEvent();
        public UnityEvent OnZeroHealth = new UnityEvent();

        public void TakeDamage(int damageAmount)
        {
            
            currentHealth -= damageAmount;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            OnTakeDamage.Invoke();

            if (currentHealth <= 0) 
            {
                OnZeroHealth.Invoke();
                Destroy(gameObject);
                //EventBus.CallEvent(gameObject.tag + "Dead");
                //if (destroyOnZeroHealth) Destroy(gameObject);
            }
            
        }

        public static void TryDamage(GameObject target, int damageAmount){
            Health health = target.GetComponent<Health>();

            if (health) health.TakeDamage(damageAmount);
        }
    }
}

