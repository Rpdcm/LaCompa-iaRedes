using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableComponents : MonoBehaviour {
    //cable que crea
    [SerializeField]protected GameObject _link;
    //objeto que se crea para moverle valores
    protected GameObject _auxLink;
    //objeto que se busca para guardar el cable para luego mover valores
    private GameObject _levelManager;
    //numero de conexiones que tiene este objeto
    [Header("numero de cables permitidos")]
    [SerializeField] public int _numberOfFreePorts;

    public enum enumComponent
    {
        PC,
        SWIT,
        ROUTER
    }
    public enumComponent _enumcomponent;

    void Start () {
        _levelManager = FindObjectOfType<LevelManager>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void OnMouseDown()
    {
        //primero revise si hay cables volando
        if (!_levelManager.GetComponent<LevelManager>().LooseCable)
        {
            //luego si tiene lugar para conectar en este dispositivo
            if (_numberOfFreePorts >0)
            {
                _auxLink = Instantiate(_link, new Vector3(0, 0, 0), Quaternion.identity);
                _levelManager.GetComponent<LevelManager>().CurrentCable = _auxLink;
                _auxLink.GetComponent<Link>().ObjConnected1 = gameObject; 
                _auxLink.GetComponent<LineRenderer>().SetPosition(0, transform.position);
                _levelManager.GetComponent<LevelManager>().LooseCable = true;
                _numberOfFreePorts--;
            }
        }
        else
        {
            //si hay cable volando y hay lugar para conectar se cierra la coneccion y que no sea el mismo objeto
            if ( _numberOfFreePorts > 0 && _levelManager.GetComponent<LevelManager>().CurrentCable.GetComponent<Link>().ObjConnected1 != gameObject)
            {
                _levelManager.GetComponent<LevelManager>().CurrentCable.GetComponent<Link>().Connected = true;
                _levelManager.GetComponent<LevelManager>().CurrentCable.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                _levelManager.GetComponent<LevelManager>().LooseCable = false;
                _numberOfFreePorts--;
                _levelManager.GetComponent<LevelManager>().CurrentCable.GetComponent<Link>().ObjConnected2 = gameObject;
                //agregamos ese cable al objeto con el que se conecto al final para que evite conectarse de nuevo
                _auxLink = _levelManager.GetComponent<LevelManager>().CurrentCable;
                _levelManager.GetComponent<LevelOfEvaluation>().Links.Add(_auxLink);
                _auxLink.GetComponent<Link>().CorrectConect();
            }
        }

        
    }
}
