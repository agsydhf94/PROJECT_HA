using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    // �÷��̾� ĳ���� ������ ����
    // �÷��̾� ĳ������ ���� ��ġ ������ ���´�
    public GameObject playerCharacter;
    public GameObject start_Position;
    public GameObject character_Customization;

    // ���� ��/������ ������ �޴´�
    public Scene current_Scene;

    // UI ��ҵ� ����
    public bool Display_Settings = false;
    public UIController ui_Controller;
    public int level = 0;

    // �����, FX����(ȿ����)�� �ʱ� ����� ����
    public float audio_Level = 1.0f;
    public float fx_Level = 1.0f;




    private void Awake()
    {
        // �̱���
        if(instance == null)
        { 
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(this);
        }


        // �� ������ �ٸ� ������ �Ѿ �� ���� ������Ʈ�� �����ǵ��� �Ѵ�
        DontDestroyOnLoad(this);

    }


    // �ʱ�ȭ
    private void Start()
    {
        // �ҷ��� ���� UI ��Ʈ�ѷ� ������ ã��
        if(GameObject.FindGameObjectWithTag("UI") != null)
        {
            instance.ui_Controller =
                GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        }


        instance.ui_Controller.settingsCanvas.gameObject.SetActive(instance.Display_Settings);

    }

    public void MasterVolume


}

