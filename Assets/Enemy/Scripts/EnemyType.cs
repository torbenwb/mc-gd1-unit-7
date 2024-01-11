using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/New Enemy")]
    public class EnemyType : ScriptableObject
    {
        public int health;
        public int damage;
        public float speed;
        public int gold;
        public GameObject prefab;

        public GameObject SpawnInstance(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var newInstance = Instantiate(prefab, position, rotation);
            if (parent) newInstance.transform.parent = parent;

            if (newInstance.TryGetComponent<Enemy>(out var enemy)) enemy.type = this;
            else newInstance.AddComponent<Enemy>().type = this;
            return newInstance;
        }
    }
}


