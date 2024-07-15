using HA;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HA
{
    [CreateAssetMenu]
    public class ItemSO : ScriptableObject
    {
        public static ItemSO instance;

        public string itemName;
        public StatToChange statToChange = new StatToChange();
        public int amountToChangeStat;

        public AttributesToChange attributesToChange = new AttributesToChange();
        public int amountToChangeAttribute;

        //public CharacterBase characterBase;

        //private void Awake()
        //{
        //    characterBase = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
        //}

        

        public void UseItem()
        {
            if (statToChange == StatToChange.HEALTH)
            {
                //PlayerController.Instance.PlayerCharacterBase.AddHP(amountToChangeStat);
                //PlayerController.Instance.PlayerCharacterBase.currentHP += amountToChangeStat;
                PlayerController.Instance.PlayerCharacterBase.IncreaseHP(amountToChangeStat);
            }

            if (statToChange == StatToChange.MANA)
            {
                //PlayerController.Instance.PlayerCharacterBase.AddMP(amountToChangeStat);
                PlayerController.Instance.PlayerCharacterBase.currentMP += amountToChangeStat;
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
