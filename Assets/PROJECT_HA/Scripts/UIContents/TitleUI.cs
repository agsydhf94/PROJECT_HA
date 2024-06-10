using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class TitleUI : UIBase
    {
        public void OnClickStartButton()
        {
            Main.Instance.ChangeScene(SceneType.Game);
        }

        public void OnClickExitButton()
        {
            Debug.Log("Clicked Exit Button");
        }
    }
}
