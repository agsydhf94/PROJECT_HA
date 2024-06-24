using HA;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[RequireComponent(typeof(GunController))]
public class WeaponManager : MonoBehaviour
{
    // 무기 중복 교체 방지
    public static bool isChangeWeapon; // static 이므로 공동자산 클래스 변수 = 정적 변수
    public static Transform currentWeaponTransform; // 기존 무기 껐다 키는 역할 -> 무기 종류가 많아서 공통으로 가지는 Transform으로 함
    public static Animator currentWeaponAnimator;
    private string currentWeaponType;

    private float changeWeaponDelayTime;
    private float changeWeaponEndDelayTime;

   
    private Weapon[] guns;
    private Dictionary<string, Weapon> weaponDictionary = new Dictionary<string, Weapon>();

    private GunController gunController;
    public GameObject weaponHolder;
    public Weapon currentWeapon;

    void Awake()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            weaponDictionary.Add(guns[i].name, guns[i]);
        }

        var weaponGameObject = TransformUtility.FindGameObjectWithTag(weaponHolder, "Weapon");
        currentWeapon = weaponGameObject.GetComponent<Weapon>();

    }

    private void Update()
    {
        if(!isChangeWeapon)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                // to do : 무기 교체 - 라이플
                // StartCoroutine(ChangeWeaponCoroutine("Rifle"));
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                // to do : 무기 교체 - 권총
            }
        }
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        
        yield return new WaitForSeconds(changeWeaponDelayTime);

        CancelPreWeaponAction();
        // WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeWeaponEndDelayTime);

        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    private void CancelPreWeaponAction()
    {
        switch(currentWeaponType)
        {
            case "Rifle":
                currentWeapon.CancelReload();
                break;
            case "Handgun":
                break;
        }
    }
    /*
    private void WeaponChange(string type, string name)
    {
        switch(type)
        {
            case "Rifle":
                gunController.GunChange(weaponDictionary[name]);
                break;
        }
    }
    */
}
