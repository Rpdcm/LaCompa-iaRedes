using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

    //para que una punta del cable siga al cable
    private bool _connected = false;
    private GameObject _objConnected1;
    private GameObject _objConnected2;
    private GameObject _levelManager;

    public bool Connected
    {
        get
        {
            return _connected;
        }

        set
        {
            _connected = value;
        }
    }

    public GameObject ObjConnected1
    {
        get
        {
            return _objConnected1;
        }

        set
        {
            _objConnected1 = value;
        }
    }

    public GameObject ObjConnected2
    {
        get
        {
            return _objConnected2;
        }

        set
        {
            _objConnected2 = value;
        }
    }

    void Start() {
        GetComponent<LineRenderer>().SetPosition(1, Input.mousePosition);
        _levelManager = FindObjectOfType< LevelOfEvaluation >().gameObject;
    }


    void Update() {
        if (!Connected)
        {
            //para que el eje z que de en 0 y no halla punto en que desaparesca la linea
            Vector3 pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            
            GetComponent<LineRenderer>().SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (Input.GetMouseButtonDown(1))
            {
                FindObjectOfType<LevelManager>().LooseCable = false;
                _objConnected1.GetComponent<ConnectableComponents>()._numberOfFreePorts++;
                Destroy(gameObject);
            }
        }
        
    }

    public void Delete()
    {
        switch (_objConnected1.GetComponent<ConnectableComponents>()._enumcomponent)
        {
            case ConnectableComponents.enumComponent.PC:
                if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.SWIT)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Pc_Switch++;

                }
                break;

            case ConnectableComponents.enumComponent.ROUTER:
                if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.SWIT)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Switch_Router--;
                }
                else if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.ROUTER)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Router_Router++;
                }
                break;

            case ConnectableComponents.enumComponent.SWIT:
                if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.PC)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Pc_Switch++;
                }
                else if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.ROUTER)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Switch_Router++;
                }
                break;

            default:
                Debug.Log("No se que acaban de unir");
                break;
        }
    }
    public void CorrectConect()
    {
        switch (_objConnected1.GetComponent<ConnectableComponents>()._enumcomponent)
        {
            case ConnectableComponents.enumComponent.PC:
                if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.SWIT)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Pc_Switch--;
                    
                }
                break;

            case ConnectableComponents.enumComponent.ROUTER:
                if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.SWIT)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Switch_Router--;
                }
                else if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.ROUTER)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Router_Router--;
                }
                break;

            case ConnectableComponents.enumComponent.SWIT:
                if (_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.PC)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Pc_Switch--;
                }
                else if(_objConnected2.GetComponent<ConnectableComponents>()._enumcomponent == ConnectableComponents.enumComponent.ROUTER)
                {
                    _levelManager.GetComponent<LevelOfEvaluation>().Switch_Router--;
                }
                break;

            default:
                Debug.Log("No se que acaban de unir");
                break;
        }
    }



}
