using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedLevelsCounter : MonoBehaviour {
    enum enumWorld
    {
        WORLD_1,
        WORLD_2,
        WORLD_3,
        WORLD_4
    }
    [SerializeField] private enumWorld _worlds;
    // Use this for initialization
    void Start()
    {
        switch (_worlds)
        {
            case enumWorld.WORLD_1:
                GetComponent<Text>().text = PlayerPrefs.GetInt("World1", 0).ToString() + "/5";
                break;
            case enumWorld.WORLD_2:
                GetComponent<Text>().text = PlayerPrefs.GetInt("World2", 0).ToString() + "/5";
                break;
            case enumWorld.WORLD_3:
                GetComponent<Text>().text = PlayerPrefs.GetInt("World3", 0).ToString() + "/5";
                break;

            case enumWorld.WORLD_4:
                GetComponent<Text>().text = PlayerPrefs.GetInt("World4", 0).ToString() + "/5";
                break;
        }
    }
}
