using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearLevels : MonoBehaviour {
    private int indexLevels;
    public GameObject[] levels;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Appear(int index)
    {
        indexLevels = index;
        levels[indexLevels].active = true;
        GetComponent<Animator>().SetBool("MoveCam", true);
    }

    public void disappear()
    {
        GetComponent<Animator>().SetBool("MoveCam", false);
        levels[indexLevels].active = false;
    }
}
