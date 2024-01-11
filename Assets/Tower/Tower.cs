using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Animator))]
    public class Tower : MonoBehaviour
    {
        private List<Enemy> enemiesInRange = new List<Enemy>();
        public Tower_SO towerType;
        private bool firing = false;
        public Enemy enemyTarget;
        Animator animator;
        int damage => towerType.damage;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void DamageTarget()
        {
            if (!enemyTarget) return;
            enemyTarget.TakeDamage(damage);
        }

        private void RemoveDestroyedEnemies()
        {
            int i = 0;
            while(i < enemiesInRange.Count)
            {
                if (enemiesInRange[i]) i++;
                else enemiesInRange.RemoveAt(i);
            }
        }

        IEnumerator DamageEnemyTarget()
        {
            firing = true;

            while(enemiesInRange.Count > 0)
            {
                RemoveDestroyedEnemies();
                if (enemiesInRange.Count > 0)
                {
                    enemyTarget = enemiesInRange[0];
                    animator.SetTrigger("Fire");
                }
                

                yield return new WaitForSeconds(towerType.fireRate);
            }

            firing = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject.GetComponent<Enemy>());

            if (!firing) StartCoroutine(DamageEnemyTarget());
        }

        private void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject.GetComponent<Enemy>());
        }

        // Not great but what are ya gonna do
        public void GivePlayerGold(){
            FindObjectOfType<Player>().Addgold(1);
        }
    }
}

