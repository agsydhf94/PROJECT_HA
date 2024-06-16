using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class InteractionSensor : MonoBehaviour
    {
        public bool HasInteractable => interactables.Count > 0;

        public List<IInteractable> interactables = new List<IInteractable>();

        public System.Action<IInteractable> OnDetected;
        public System.Action<IInteractable> OnLost;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent(out IInteractable interactable))
            {
                interactables.Add(interactable);
                OnDetected?.Invoke(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.root.TryGetComponent(out IInteractable interactable))
            {
                interactables.Remove(interactable);
                OnLost?.Invoke(interactable);
            }
        }
    }
}
