using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class GivePlayerGold : MonoBehaviour
    {
        public int amount = 1;
        public void Execute()
        {
            Player player = FindObjectOfType<Player>();
            if (player) player.Addgold(amount);
        }
    }
}

