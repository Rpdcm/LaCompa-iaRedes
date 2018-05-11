using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOfEvaluation : MonoBehaviour {

    private List<GameObject> links = new List<GameObject>();

    [Header("numero de conexiones")]
    [SerializeField]
    private int _Pc_Switch;
    [SerializeField]
    private int _Switch_Router;
    [SerializeField]
    private int _Router_Router;
    [SerializeField]
    private int Level;
    private int playerlevel;


    [Header("Paneles finales")]
    [SerializeField]
    private GameObject _panelGoodJob;
    [SerializeField]
    private GameObject _panelErrorSystem;

    public List<GameObject> Links
    {
        get
        {
            return links;
        }

        set
        {
            links = value;
        }
    }

    public int Router_Router
    {
        get
        {
            return _Router_Router;
        }

        set
        {
            _Router_Router = value;
        }
    }

    public int Switch_Router
    {
        get
        {
            return _Switch_Router;
        }

        set
        {
            _Switch_Router = value;
        }
    }

    public int Pc_Switch
    {
        get
        {
            return _Pc_Switch;
        }

        set
        {
            _Pc_Switch = value;
        }
    }


    // Use this for initialization

    void Start () {
        //_panelErrorSystem.GetComponent<Animator>().speed = 0;
    }
	
    public void RemoveLastLink()
    { //mira si hay cables
        if (links.Count > 0 )
        {// mira a que esta conectado el cable y le deja los puerto libres de nuevo
            if (links[links.Count - 1].GetComponent<Link>().ObjConnected2 != null)
            {
                links[links.Count - 1].GetComponent<Link>().ObjConnected1.GetComponent<ConnectableComponents>()._numberOfFreePorts++;
                links[links.Count - 1].GetComponent<Link>().ObjConnected2.GetComponent<ConnectableComponents>()._numberOfFreePorts++;
                links[links.Count - 1].GetComponent<Link>().Delete();

            }
            else
            {
                links[links.Count - 1].GetComponent<Link>().ObjConnected1.GetComponent<ConnectableComponents>()._numberOfFreePorts++;
            }

            //saca el objeto de la sala y de la lista
            Destroy(links[links.Count - 1]);
            links.RemoveAt(links.Count-1);
        }
    }
    
    public void EvaluedSystem()
    {
   
        if (_Router_Router == 0 && _Pc_Switch == 0 && _Switch_Router == 0)
        {
          _panelGoodJob.active = true;
            playerlevel = PlayerPrefs.GetInt("World1", 0);
            if (Level == playerlevel)
            {
                PlayerPrefs.SetInt("World1", Level + 1);
            }
        }
        else
        {
           
          _panelErrorSystem.active = true;
        }
            
        
    }

    private void Update()
    {
       
    }



}
