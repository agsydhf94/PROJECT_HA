using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class Interaction_NPC : MonoBehaviour, IInteractable
    {
        public string Key => "NPC." + gameObject.GetHashCode();

        public string Message => "Talk";

        public void Interact()
        {

        }
    }
}