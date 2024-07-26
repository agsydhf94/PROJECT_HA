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
        

        public string itemName;
        public StatToChange statToChange = new StatToChange();
        public int amountToChangeStat;

        public AttributesToChange attributesToChange = new AttributesToChange();
        public int amountToChangeAttribute;

        public CharacterBase characterBase => PlayerController.Instance.PlayerCharacterBase;

        //private void Awake()
        //{
        //    characterBase = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
        //}

        

        public bool UseItem()
        {
            switch(statToChange)
            {
                case StatToChange.HEALTH:
                    {
                        if (characterBase.currentHP == characterBase.maxHP)
                        {
                            return false;
                        }
                        else
                        {
                            characterBase.IncreaseHP(amountToChangeStat);
                            return true;
                        }
                    }
                case StatToChange.BULLET:
                    {
                        
                    }
                    break;
            }
            /*
            if (statToChange == StatToChange.HEALTH)
            {
                //PlayerController.Instance.PlayerCharacterBase.AddHP(amountToChangeStat);
                //PlayerController.Instance.PlayerCharacterBase.currentHP += amountToChangeStat;
                
                
            }
            */
            return false;

            

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
            MANA,
            BULLET
        }

        public enum AttributesToChange
        {
            NONE,
            ATTACK,
            DEFENSE
        }
    }
}
