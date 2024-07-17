using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataModel : MonoBehaviour
{
    public static GameDataModel Instance;

    public GameDataBase myDummyData;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}

