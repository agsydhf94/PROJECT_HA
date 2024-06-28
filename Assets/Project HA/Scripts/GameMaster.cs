using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    // 플레이어 캐릭터 참조를 갖고
    // 플레이어 캐릭터의 시작 위치 참조를 갖는다
    public GameObject playerCharacter;
    public GameObject start_Position;
    public GameObject character_Customization;

    // 현재 신/레벨의 참조를 받는다
    public Scene current_Scene;

    // UI 요소들 참조
    public bool Display_Settings = false;
    public UIController ui_Controller;
    public int level = 0;

    // 배경음, FX사운드(효과음)의 초기 오디오 레벨
    public float audio_Level = 1.0f;
    public float fx_Level = 1.0f;




    private void Awake()
    {
        // 싱글턴
        if(instance == null)
        { 
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(this);
        }


        // 한 씬에서 다른 씬으로 넘어갈 때 게임 오브젝트가 유지되도록 한다
        DontDestroyOnLoad(this);

    }


    // 초기화
    private void Start()
    {
        // 불러온 씬의 UI 컨트롤러 참조를 찾기
        if(GameObject.FindGameObjectWithTag("UI") != null)
        {
            instance.ui_Controller =
                GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        }


        instance.ui_Controller.settingsCanvas.gameObject.SetActive(instance.Display_Settings);

    }

    public void MasterVolume


}

