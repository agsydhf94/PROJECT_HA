using HA;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class AnimationRigController_RifleOff : StateMachineBehaviour
{
    public GameObject Rifle;
    public PlayerController playerController;
    public Animator animator;

    private void Awake()
    {
        // Rifle = GameObject.Find("ScifiRifleWLT78Receiver");
        
        // animator = GameObject.Find("FreeTestCharacterAsuna").GetComponent<Animator>();
        // playerController = GameObject.Find("HA.Character.Player").GetComponent<PlayerController>();

        playerController = PlayerController.Instance;
        animator = PlayerController.Instance.GetComponent<Animator>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController.IsEnableMovemnt = false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Rifle.SetActive(false);
        animator.SetBool("Rifle_Active", false);
        playerController.IsEnableMovemnt = true;
    }

}

