using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearHelp : MonoBehaviour {
    private Animator anim;
    private bool _pressButton = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AppearOrDisappearHelp()
    {
        if (_pressButton)
        {
            _pressButton = false;
            anim.SetBool("pressButton",_pressButton);
        }
        else
        {
            _pressButton = true;
            anim.SetBool("pressButton",_pressButton);
        }
    }

}
