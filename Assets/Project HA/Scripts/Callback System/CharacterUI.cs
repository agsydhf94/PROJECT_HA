using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUI: MonoBehaviour
{
    public Image hpBar;
    public Image mpBar;

    [SerializeField]
    private TMP_Text hpText;

    //public CharacterBase linkedCharacter;

    private void Start()
    {
        PlayerController.Instance.PlayerCharacterBase.OnDamaged += RefreshHpBar;
        PlayerController.Instance.PlayerCharacterBase.OnChangedHP += RefreshHpBar;

        //linkedCharacter.onDamageCallback += RefreshHpBar;  // "��������Ʈ�� chain�� �Ǵ�" ��� ǥ��
        // linkedCharacter.onDamagedAction += RefreshHpBar;

    }

    public void RefreshHpBar(float currentHp, float maxHp)
    {
        hpBar.fillAmount = currentHp / maxHp;
        hpText.text = $"{currentHp:0} / {maxHp:0}";
    }
}
