using HA;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HA
{
    [CreateAssetMenu]
    public class ItemSO : ScriptableObject
    {
        public string itemName;
        public StatToChange statToChange = new StatToChange();
        public int amountToChangeStat;

        public AttributesToChange attributesToChange = new AttributesToChange();
        public int amountToChangeAttribute;

        public CharacterBase characterBase;

        private void Awake()
        {
            characterBase = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
        }

        public void UseItem()
        {
            if (statToChange == StatToChange.HEALTH)
            {
                characterBase.currentHP += amountToChangeStat;
            }

            if (statToChange == StatToChange.MANA)
            {
                characterBase.currentMP += amountToChangeStat;
            }
        }



        public enum StatToChange
        {
            NONE,
            HEALTH,
            MANA
        }

        public enum AttributesToChange
        {
            NONE,
            ATTACK,
            DEFENSE
        }
    }
}
