using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class AnimationRigController_RifleOff : StateMachineBehaviour
{
    public GameObject Rifle;

    private void Awake()
    {
        Rifle = GameObject.Find("ScifiRifleWLT78Receiver");
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rifle.SetActive(false);
    }

}

