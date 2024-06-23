using HA;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // 무기 중복 교체 방지
    public static bool isChangeWeapon; // static 이므로 공동자산 클래스 변수 = 정적 변수

    private float changeWeaponDelayTime;
    private float changeWeaponEndDelayTime;

    private string currentWeaponType;

    public static Transform currentWeapon;

    private Weapon[] guns;
    private Dictionary<string, Weapon> weaponDictionary = new Dictionary<string, Weapon>();

    void Awake()
    {
        
        
    }
}
