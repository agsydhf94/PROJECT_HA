using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HA
{

    public class UIController : MonoBehaviour
    {
        public Canvas settingsCanvas;
        public Slider controlMainVolume;


        // 설정 패널 표시
        public void DisplaySettings()
        {
            GameMaster.instance.Display_Settings =
                !GameMaster.instance.Display_Settings;

            settingsCanvas.gameObject.SetActive(GameMaster.instance.Display_Settings);
        }

        public void MainVolume()
        {
            GameMaster.instance.MasterVolume(controlMainVolume.value);
        }
    }
}