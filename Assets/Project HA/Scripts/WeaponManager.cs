using HA;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // ���� �ߺ� ��ü ����
    public static bool isChangeWeapon; // static �̹Ƿ� �����ڻ� Ŭ���� ���� = ���� ����

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
