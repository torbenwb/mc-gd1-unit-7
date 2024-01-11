using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        // points: sequential list of world space positions.
        [SerializeField] private List<Vector3> points = new List<Vector3>();

        void Awake()
        {
            CollectPoints();
        }

        // CollectPoints: collect points from child GameObjects
        // and occupy grid.
        private void CollectPoints()
        {
            points = new List<Vector3>();

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Vector3 point = child.transform.position;

                points.Add(point);
                Grid.Add(Grid.WorldToGrid(point), child);
                child.SetActive(false);
            }
        }


        // TryGetPoint: Get the path point at given index
        // if index is valid.
        public bool TryGetPoint(int index, out Vector3 point){
            point = Vector3.zero;
            if (index < 0 || index >= points.Count) return false;

            point = points[index];
            return true;
        }

    }
}

