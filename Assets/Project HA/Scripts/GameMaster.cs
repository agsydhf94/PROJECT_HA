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
        // Static은 얼마나 많은 인스턴스가 생기던 간에
        // 맨 처음 선언된 순간부터 여러 인스턴스를 거쳐 수정된 사항이 이어져 내려오게 되는 속성이 있다
        // 즉, 모든 인스턴스가 메모리 공간에 할당된 오직 하나의 객체를 가리킨다

        // 플레이어 캐릭터 참조를 갖고
        // 플레이어 캐릭터의 시작 위치 참조를 갖는다
        public GameObject playerCharacter;
        public GameObject start_Position;
        public GameObject character_Customization;

        // 현재 신/레벨의 참조를 받는다
        public Scene current_Scene;

        public InventorySystem inventorySystem;

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
            if (instance == null)
            {
                instance = this;

                // 인벤토리 시스템 초기화
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


            // 한 씬에서 다른 씬으로 넘어갈 때 게임 오브젝트가 유지되도록 한다
            DontDestroyOnLoad(this);

        }


        // 초기화
        private void Start()
        {
            // 불러온 씬의 UI 컨트롤러 참조를 찾기
            // 현재 씬에서 UI 컨트롤러 존재 유무 확인
            if (GameObject.FindGameObjectWithTag("UI") != null)
            {
                // 존재하면 참조를 얻는다
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
            // 게임을 시작하는 함수이며, 플레이어가 캐릭터를 커스터마이징하는 신을 로드합니다
            // SceneManager.LoadScene(SceneName.CharacterCustomizaion);
        }


    }
}

