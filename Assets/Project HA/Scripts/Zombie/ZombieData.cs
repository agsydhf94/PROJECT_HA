using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    [CreateAssetMenu(menuName = "ScriptableObject/ZombieData", fileName = "ZombieData")]
    public class ZombieData : ScriptableObject
    {
        public float health = 100f;
        public float damage = 20f;
        public float speed = 1.8f;
        public Color skinColor = Color.white;


    }
}
