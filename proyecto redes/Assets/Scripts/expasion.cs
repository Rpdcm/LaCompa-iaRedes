using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expasion : MonoBehaviour {
    private Vector3 pos;
    private float angule;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        pos = pos - transform.position;
        angule = Mathf.Atan2(pos.y, pos.x)*180/Mathf.PI;
        transform.localEulerAngles = new Vector3(0,0,angule);
        transform.localScale = new Vector3(pos.magnitude,0.1f,1);
        
    }
}
