using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorModifier : MonoBehaviour
{
    [Header("Hair Color")]
    public SkinnedMeshRenderer hair;
    public Slider red;
    public Slider green;
    public Slider blue;

    [Header("Body Color")]
    public SkinnedMeshRenderer body;
    public Slider body_R;
    public Slider body_G;
    public Slider body_B;

    public void HairColorEdit()
    {
        Color color = hair.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        hair.material.color = color;
        hair.material.SetColor("_EmissionColor", color);
    }

    public void BodyColorEdit()
    {
        Color color = body.material.color;
        color.r = body_R.value;
        color.g = body_G.value;
        color.b = body_B.value;
        body.material.color = color;
        body.material.SetColor("_EmissionColor", color);
    }
}
