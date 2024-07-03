using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace HA
{
    public class CharacterBase : MonoBehaviour
    {
        public float currentHP;
        public float maxHP;

        public delegate void OnDamage(float currentHP, float maxHP);
        public OnDamage onDamageCallback;

        public delegate void OnCharacterDead();
        public OnCharacterDead onCharacterDead;

        // public System.Action<float, float> onDamagedAction;

        // public event OnDamage onDamageCallbackEvent;

        public void Damage(float damage)
        {
            currentHP -= damage;

            onDamageCallback(currentHP, maxHP);
            // onDamagedAction(currentHP, maxHP);

            if (currentHP <= 0)
            {
                onCharacterDead();
                Destroy(gameObject);
            }
        }

        [ContextMenu("Damage Debug")]
        public void DamageDebugButton()
        {
            Damage(20);
        }
    }
}
