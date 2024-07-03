using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI: MonoBehaviour
{
    public Image hpBar;

    public CharacterBase linkedCharacter;

    private void Start()
    {
        linkedCharacter.onDamageCallback += RefreshHpBar;  // "델리게이트에 chain을 건다" 라고 표현
        // linkedCharacter.onDamagedAction += RefreshHpBar;
    }

    public void RefreshHpBar(float currentHp, float maxHp)
    {
        hpBar.fillAmount = currentHp / maxHp;
    }
}
