using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorModifier : MonoBehaviour
{
    public SkinnedMeshRenderer hair;
    public Slider red;
    public Slider green;
    public Slider blue;

    public void OnEdit()
    {
        Color color = hair.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        hair.material.color = color;
        hair.material.SetColor("_EmissionColor", color);
    }
}
