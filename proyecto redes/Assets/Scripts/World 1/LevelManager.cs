using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    private bool _looseCable = false;
    private GameObject _currentCable;
    public bool LooseCable
    {
        get
        {
            return _looseCable;
        }

        set
        {
            _looseCable = value;
        }
    }

    public GameObject CurrentCable
    {
        get
        {
            return _currentCable;
        }

        set
        {
            _currentCable = value;
        }
    }
}
