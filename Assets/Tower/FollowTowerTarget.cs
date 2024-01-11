using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class FollowTowerTarget : MonoBehaviour
    {
        Tower tower;
        public bool clampPitch = false;
        // Start is called before the first frame update
        void Start()
        {
            tower = GetComponentInParent<Tower>();
        }

        // Update is called once per frame
        void Update()
        {
            // In order to get enemyTarget from tower we have
            // to make it public
            if (!tower.enemyTarget) return; // if target is null stop right there

            // Rotate this GameObject towards enemyTarget
            // Get direction (target position - transform.position)
            Vector3 direction = tower.enemyTarget.transform.position - transform.position;

            // Get rotation from direction and convert to eulers
            Vector3 eulerRotation = Quaternion.LookRotation(direction).eulerAngles;
            
            // Whether this object should rotate up and down 
            // (good for bow and arrow bad for cannon)
            if (clampPitch) eulerRotation.x = 0f;

            // Assign rotation to transform by converting euler back into quaternion
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}

