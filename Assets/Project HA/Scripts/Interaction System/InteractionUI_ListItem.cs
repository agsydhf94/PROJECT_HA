using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace HA
{
    public class InteractionUI_ListItem : MonoBehaviour
    {
        
        public GameObject selection;
        public TMPro.TextMeshProUGUI text;

        private IInteractable interactionData;
        private string key;



        public string DataKey
        {
            get => key;
            set => key = value;
        }

        public string Message
        {
            set => text.text = value;
        }

        public bool IsSelected
        {
            set => selection.SetActive(value);
        }

        public IInteractable InteractionData
        {
            get => interactionData;
            set => interactionData = value;
        }



    }
}
