using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public class SpawnerBehaviour_SO : ScriptableObject
    {
        [System.Serializable]
        public class Wave{
            public float startDelay; // time after previous wave ends to start new wave
            public List<EnemyGroup> enemyGroups;    
        }
        [System.Serializable]
        public struct EnemyGroup
        {
            public EnemyType type;
            public int count;
            public float spawnDelay;
            public float startDelay;
        }

        public List<Wave> waves = new List<Wave>();
    }
}

