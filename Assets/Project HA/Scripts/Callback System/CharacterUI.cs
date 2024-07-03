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
        linkedCharacter.onDamageCallback += RefreshHpBar;  // "��������Ʈ�� chain�� �Ǵ�" ��� ǥ��
        // linkedCharacter.onDamagedAction += RefreshHpBar;
    }

    public void RefreshHpBar(float currentHp, float maxHp)
    {
        hpBar.fillAmount = currentHp / maxHp;
    }
}
