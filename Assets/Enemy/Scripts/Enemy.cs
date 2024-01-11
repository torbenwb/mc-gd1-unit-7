using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public static int count { get; private set; } = 0;
        public EnemyType type;
        public Path path;
        public int index = 0;
        public int health => type.health;
        public float speed => type.speed;
        public int damage => type.damage;

        int damageTaken = 0;
        private void OnEnable()
        {
            count++;
        }

        private void OnDisable()
        {
            count--;
        }

        void Start()
        {
            // Find path
            path = FindObjectOfType<Path>();
            StartCoroutine(FollowPath());
        }

        public void TakeDamage(int amount)
        {
            damageTaken += amount;
            if (TryGetComponent<Animator>(out var animator))
            {
                animator.SetTrigger("Damage");
            }
            if (damageTaken >= health)
            {
                Player.ChangeGold(type.gold);
                Destroy(gameObject);
            }
        }

        IEnumerator FollowPath()
        {
            Vector3 target;
            while(path.TryGetPoint(index, out target))
            {
                Vector3 start = transform.position;

                float maxDistance = Mathf.Min(speed * Time.deltaTime, (target - start).magnitude);
                transform.position = Vector3.MoveTowards(start, target, maxDistance);
                
                // Rotate towards next point
                transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(target - start),0.05f);

                if (transform.position == target) index++;
                yield return null;
            }

            // Damage player at the end of the path
            Player.ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
}

