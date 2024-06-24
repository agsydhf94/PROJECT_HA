using HA;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[RequireComponent(typeof(GunController))]
public class WeaponManager : MonoBehaviour
{
    // ���� �ߺ� ��ü ����
    public static bool isChangeWeapon; // static �̹Ƿ� �����ڻ� Ŭ���� ���� = ���� ����
    public static Transform currentWeapon;
    public static Animator currentWeaponAnimator;
    private string currentWeaponType;

    private float changeWeaponDelayTime;
    private float changeWeaponEndDelayTime;

   
    private Weapon[] guns;
    private Dictionary<string, Weapon> weaponDictionary = new Dictionary<string, Weapon>();

    private GunController gunController;

    void Awake()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            weaponDictionary.Add(guns[i].name, guns[i]);
        }
      
    }

    private void Update()
    {
        if(!isChangeWeapon)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                // to do : ���� ��ü - ������
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                // to do : ���� ��ü - ����
            }
        }
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        
        yield return new WaitForSeconds(changeWeaponDelayTime);

        CancelPreWeaponAction();
    }

    private void CancelPreWeaponAction()
    {
        switch(currentWeaponType)
        {
            case "Gun":
                break;
        }
    }
}
