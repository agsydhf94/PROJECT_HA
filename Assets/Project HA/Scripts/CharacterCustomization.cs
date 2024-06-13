using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public GameObject playerCharacterAsuna;
    public Material[] hairColor;
    public GameObject hair;

    // 어깨 패드
    public GameObject armor_ShoulderLeft;
    public GameObject armor_UpperArmLeft;
    public GameObject armor_EllbowLeft;
    public GameObject armor_ShoulderRight;
    public GameObject armor_UpperArmRight;
    public GameObject armor_EllbowRight;

    // player 캐릭터 무기
    public GameObject handGun;
    public GameObject scifiRifle;

    // 무릎
    public GameObject armor_KneeLeft;
    public GameObject armor_KneeRight;


    private void Start()
    {
        
    }

    public bool rotateCharacter = false;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            this.rotateCharacter = !rotateCharacter;
        }

        if(this.rotateCharacter)
        {
            this.playerCharacterAsuna.transform.Rotate(new Vector3(0,1,0), 33.0f * Time.deltaTime);
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log(PlayerPrefs.GetString("NAME"));
        }
    }

    public void SetShoulderPad(Toggle id)
    {
        switch(id.name)
        {
            case "SPad-01":
                this.armor_ShoulderLeft.SetActive(id.isOn);
                this.armor_UpperArmLeft.SetActive(false);
                this.armor_EllbowLeft.SetActive(false);
                this.armor_ShoulderRight.SetActive(id.isOn);
                this.armor_UpperArmRight.SetActive(false);
                this.armor_EllbowRight.SetActive(false);
                PlayerPrefs.SetInt("SP-01", 1);
                PlayerPrefs.SetInt("SP-02", 0);
                PlayerPrefs.SetInt("SP-03", 0);
                break;

            case "SPad-02":
                this.armor_ShoulderLeft.SetActive(false);
                this.armor_UpperArmLeft.SetActive(id.isOn);
                this.armor_EllbowLeft.SetActive(false);
                this.armor_ShoulderRight.SetActive(false);
                this.armor_UpperArmRight.SetActive(id.isOn);
                this.armor_EllbowRight.SetActive(false);
                PlayerPrefs.SetInt("SP-01", 0);
                PlayerPrefs.SetInt("SP-02", 1);
                PlayerPrefs.SetInt("SP-03", 0);
                break;

            case "SPad-03":
                this.armor_ShoulderLeft.SetActive(false);
                this.armor_UpperArmLeft.SetActive(false);
                this.armor_EllbowLeft.SetActive(id.isOn);
                this.armor_ShoulderRight.SetActive(false);
                this.armor_UpperArmRight.SetActive(false);
                this.armor_EllbowRight.SetActive(id.isOn);
                PlayerPrefs.SetInt("SP-01", 0);
                PlayerPrefs.SetInt("SP-02", 0);
                PlayerPrefs.SetInt("SP-03", 1);
                break;

        }
    }

    public void SetKneePad(Toggle id)
    {
        switch(id.name)
        {
            case "Kpad-01":
                {
                    this.armor_KneeLeft.SetActive(id.isOn);
                    this.armor_KneeRight.SetActive(id.isOn);
                }
                break;
        }
    }

    public void SetRifle(Toggle id)
    {
        switch(id.name)
        {
            case "sciFiRifle":
                {
                    this.scifiRifle.SetActive(id.isOn);
                }
                break;
        }
    }

    public void SetHandGun(Toggle id)
    {
        switch(id.name)
        {
            case "sciFiHandGun":
                {
                    this.handGun.SetActive(id.isOn);
                }
                break;
        }
    }

    public void SetHairColor(Slider id)
    {
        this.hair.GetComponent<Renderer>().material = this.hairColor[System.Convert.ToInt32(id.value)];
    }
}

