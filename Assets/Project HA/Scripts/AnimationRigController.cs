using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class AnimationRigController : StateMachineBehaviour
{
    public GameObject Rifle;
    public PlayerController playerController;
    public Animator animator;

    private void Awake()
    {
        // Rifle = GameObject.Find("ScifiRifleWLT78Receiver");
        playerController = GameObject.Find("HA.Character.Player").GetComponent<PlayerController>();
        animator = GameObject.Find("FreeTestCharacterAsuna").GetComponent<Animator>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Rifle?.SetActive(true);
        animator.SetBool("Rifle_Active", true);
        playerController.IsEnableMovemnt = false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        animator.SetTrigger("Ready_Rifle");
        playerController.IsEnableMovemnt = true;
    }
    
}



