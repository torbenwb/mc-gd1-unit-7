using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cursor : MonoBehaviour
    {
        MeshRenderer cursorMeshRenderer;

        public static bool TryGetTargetTile(out Vector3Int targetTile)
        {
            targetTile = Vector3Int.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                targetTile = Grid.WorldToGrid(hit.point + hit.normal * 0.5f);
                return true;
            }

            return false;
        }

        public static bool TryGetTargetTouchTile(out Vector3Int targetTile)
        {
            targetTile = Vector3Int.zero;
            if (Input.touchCount == 0) return false;

            var touchPosition = Input.GetTouch(0).position;
            var ray = Camera.main.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out var hit))
            {
                targetTile = Grid.WorldToGrid(hit.point + hit.normal * 0.5f);
                return true;
            }
            return false;
        }

        private void Awake()
        {
            cursorMeshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (TryGetTargetTile(out var tile))
            {
                transform.position = tile;

                if (Grid.Occupied(tile))
                {
                    DisablePreview();
                }
                else
                {
                    EnablePreview();
                }
            }
            else
            {
                DisablePreview();
            }
        }

        public void EnablePreview()
        {
            cursorMeshRenderer.enabled = true;
        }

        public void DisablePreview()
        {
            cursorMeshRenderer.enabled = false;
        }
    }

}
