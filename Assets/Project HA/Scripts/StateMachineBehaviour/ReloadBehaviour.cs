using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class ReloadBehaviour : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerController.Instance.ReloadFinished();
        }
    }
}

