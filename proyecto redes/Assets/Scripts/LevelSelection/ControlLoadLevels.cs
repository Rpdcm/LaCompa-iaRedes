using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLoadLevels : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("World1", 0) == 0)
        {
            PlayerPrefs.SetInt("World1", 1);
        }

        if (PlayerPrefs.GetInt("World2", 0) == 0)
        {
            PlayerPrefs.SetInt("World2", 1);
        }

        if (PlayerPrefs.GetInt("World3", 0) == 0)
        {
            PlayerPrefs.SetInt("World3", 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
