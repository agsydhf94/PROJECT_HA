using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class AnimationRigController_RifleOff : StateMachineBehaviour
{
    public GameObject Rifle;
    public Animator animator;

    private void Awake()
    {
        // Rifle = GameObject.Find("ScifiRifleWLT78Receiver");
        animator = GameObject.Find("FreeTestCharacterAsuna").GetComponent<Animator>();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Rifle.SetActive(false);
        animator.SetBool("Rifle_Active", false);
    }

}

