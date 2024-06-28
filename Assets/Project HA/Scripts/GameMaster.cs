using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HA
{
    public class GameMaster : MonoBehaviour
    {
        public static GameMaster instance;
        // Static�� �󸶳� ���� �ν��Ͻ��� ����� ����
        // �� ó�� ����� �������� ���� �ν��Ͻ��� ���� ������ ������ �̾��� �������� �Ǵ� �Ӽ��� �ִ�
        // ��, ��� �ν��Ͻ��� �޸� ������ �Ҵ�� ���� �ϳ��� ��ü�� ����Ų��

        // �÷��̾� ĳ���� ������ ����
        // �÷��̾� ĳ������ ���� ��ġ ������ ���´�
        public GameObject playerCharacter;
        public GameObject start_Position;
        public GameObject character_Customization;

        // ���� ��/������ ������ �޴´�
        public Scene current_Scene;

        public InventorySystem inventorySystem;

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
            if (instance == null)
            {
                instance = this;

                // �κ��丮 �ý��� �ʱ�ȭ
                instance.inventorySystem = new InventorySystem();
                InventoryItem temp = new InventoryItem();

                temp.Category = BaseItem.ItemCategory.CLOTHING;
                temp.Name = "Testing";
                temp.Description = "Testing the item type";
                temp.Strength = 0.5f;
                temp.Weight = 0.2f;
                instance.inventorySystem.AddItem(temp);
            }

            

            else if (instance != this)
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
            // ���� ������ UI ��Ʈ�ѷ� ���� ���� Ȯ��
            if (GameObject.FindGameObjectWithTag("UI") != null)
            {
                // �����ϸ� ������ ��´�
                instance.ui_Controller =
                    GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
            }


            instance.ui_Controller.settingsCanvas.gameObject.SetActive(instance.Display_Settings);

        }

        public void MasterVolume(float volume)
        {
            instance.audio_Level = volume;
            instance.GetComponent<AudioSource>().volume = instance.audio_Level;
        }

        public void StartGame()
        {
            // ������ �����ϴ� �Լ��̸�, �÷��̾ ĳ���͸� Ŀ���͸���¡�ϴ� ���� �ε��մϴ�
            // SceneManager.LoadScene(SceneName.CharacterCustomizaion);
        }


    }
}

