using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Grid : MonoBehaviour
    {
        private static Grid instance;
        private static Dictionary<Vector3Int, GameObject> gameObjects = new Dictionary<Vector3Int, GameObject>();

        private void Awake()
        {
            instance = this;
            gameObjects = new Dictionary<Vector3Int, GameObject>();
        }

        public static bool Occupied(Vector3Int tileCoordinates)
        {
            return gameObjects.ContainsKey(tileCoordinates);
        }

        public static bool Add(Vector3Int tileCoordinates, GameObject gameObject){
            if (gameObjects.ContainsKey(tileCoordinates)) return false;

            gameObjects.Add(tileCoordinates, gameObject);
            return true;
        }

        public static void Remove(Vector3Int tileCoordinates){
            if (!gameObjects.ContainsKey(tileCoordinates)) return;

            Destroy(gameObjects[tileCoordinates]);
            gameObjects.Remove(tileCoordinates);
        }

        public static Vector3Int WorldToGrid(Vector3 worldPosition){
            return new Vector3Int(
                Mathf.RoundToInt(worldPosition.x),
                Mathf.RoundToInt(worldPosition.y),
                Mathf.RoundToInt(worldPosition.z)
            );
        }

        public static Vector3 GridToWorld(Vector3Int gridPosition){
            return gridPosition;
        }
    }
}

