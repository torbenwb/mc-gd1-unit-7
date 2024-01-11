using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

[CreateAssetMenu(menuName ="Game Settings/New Game Settings")]
public class GameSettings : ScriptableObject
{
    public List<SpawnerBehaviour_SO> levels = new List<SpawnerBehaviour_SO>();
    public int startingGold = 10;
    public int startingHealth = 10;
    public int maxLevel = 3;
    public float cameraShakeTime = 0.1f;
    public float cameraShakeStrength = 0.02f;
}
