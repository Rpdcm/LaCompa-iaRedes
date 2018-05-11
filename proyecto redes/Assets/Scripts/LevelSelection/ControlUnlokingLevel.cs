using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUnlokingLevel : MonoBehaviour {
    [SerializeField] private Sprite _padlock;
    [SerializeField] private Sprite _levelSprite;

    [SerializeField] private int _level;
    enum enumWorld
    {
        WORLD_1,
        WORLD_2,
        WORLD_3,
        WORLD_4
    }
    [SerializeField]private enumWorld _worlds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        switch (_worlds)
        {
            case enumWorld.WORLD_1:
                if (PlayerPrefs.GetInt("World1",0) >= _level )
                {
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = _levelSprite;
                }
                else
                {
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = _padlock;
                }
                break;
            case enumWorld.WORLD_2:
                if (PlayerPrefs.GetInt("World2",0) >= _level)
                {
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = _levelSprite;
                }
                else
                {
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = _padlock;
                }
                break;
            case enumWorld.WORLD_3:
                if (PlayerPrefs.GetInt("World3",0) >= _level)
                {
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = _levelSprite;
                }
                else
                {
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = _padlock;
                }
                break;

            case enumWorld.WORLD_4:
                if (PlayerPrefs.GetInt("World4", 0) >= _level)
                {
                    GetComponent<Button>().enabled = true;
                    GetComponent<Image>().sprite = _levelSprite;
                }
                else
                {
                    GetComponent<Button>().enabled = false;
                    GetComponent<Image>().sprite = _padlock;
                }
                break;
                
        }
    }

}
