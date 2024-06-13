using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class LocomotionBehavior : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var controller = animator.transform.root.GetComponent<PlayerControllerRPG>();
            controller.AttackComboCount = 0;
            animator.SetInteger("ComboCount", 0);

            controller.IsEnableMovemnt = true;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var controller = animator.transform.root.GetComponent<PlayerControllerRPG>();
            controller.IsEnableMovemnt = false;
        }
    }
}
