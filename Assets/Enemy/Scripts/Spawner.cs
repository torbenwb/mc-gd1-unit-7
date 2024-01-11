using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class Spawner : MonoBehaviour
    {
        public SpawnerBehaviour_SO spawnerBehaviour => GameManager.levelSpawnerBehavior;
        public bool startNextWave = true;
        public bool loopOverride = false;
        
        public UnityEvent ReadyForNextWave = new UnityEvent();
        public UnityEvent ReadyForNextLevel = new UnityEvent();

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(RunSpawnerBehavior(spawnerBehaviour));
        }

        public void StartNextWave()
        {
            startNextWave = true;
        }

        IEnumerator RunSpawnerBehavior(SpawnerBehaviour_SO behaviour)
        {
            foreach (var wave in behaviour.waves)
            {
                ReadyForNextWave.Invoke();

                yield return new WaitUntil(() => startNextWave);
                yield return new WaitForSeconds(wave.startDelay);
                

                foreach(var group in wave.enemyGroups)
                {
                    yield return new WaitForSeconds(group.startDelay);
                    for(int i = 0; i < group.count; i++)
                    {
                        SpawnEnemy(group.type);
                        yield return new WaitForSeconds(group.spawnDelay);
                    }
                }

                yield return new WaitUntil(() => Enemy.count == 0);
                startNextWave = false;
                if (loopOverride) startNextWave = true;
            }

            yield return new WaitUntil(() => Enemy.count == 0);
            ReadyForNextLevel.Invoke();

            if (loopOverride)
            {
                StartCoroutine(RunSpawnerBehavior(spawnerBehaviour));
            }
        }

        public void SpawnEnemy(EnemyType type)
        {
            type.SpawnInstance(transform.position, transform.rotation, transform);
        }
    }
}

