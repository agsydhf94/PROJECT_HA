using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class AnimationRigController : StateMachineBehaviour
{
    public GameObject Rifle;

    private void Awake()
    {
        Rifle = GameObject.Find("ScifiRifleWLT78Receiver");
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rifle?.SetActive(true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        animator.SetTrigger("Ready_Rifle");
    }
    
}



