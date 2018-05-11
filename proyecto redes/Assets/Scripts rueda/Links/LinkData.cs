using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkData : MonoBehaviour {

	public string ipAddress = "";
	private GameObject IPmanager;
    public string[] possibleAnswers;
    public GameObject conectedRouter;
    private bool OK = true;
    private GameObject[] Links;
    private bool itsOK = false;
    private bool notOK = false;
    private float cont = 0;
    private float contPuntos = 0;
    private float contPuntosRouter = 0;
    private string miRed;
    private int miRedInt;
    private string suRed;
    private int suRedInt;
    private int contPosible = 0;
    private bool redDiferente = false;
    private bool redIgual = false;
    public enum DISPOSITIVO
    {
        PC,
        ROUTER
    }

    public DISPOSITIVO _Dispositivo;

	// Use this for initialization
	void Start () {
		// Busca al IPManager
		IPmanager = GameObject.FindGameObjectWithTag("IPManager");
        Links = GameObject.FindGameObjectsWithTag("Linked");
	}

	void OnMouseDown(){
		//Le dice al IPManager quien es para modificar mi dirección IP
		IPmanager.GetComponent<TextManager> ().setFlag (gameObject);
	}

    public bool CheckIP()
    {
        foreach (GameObject Link in Links)
        {
            if (Link.GetComponent<LinkData>().ipAddress == ipAddress)
            {
                cont++;
                if (cont == 2)
                {
                    notOK = true; //error (quedo mál el nivel)
                    Debug.Log("IP Repetida");
                    
                }
            }
        } 

        switch (_Dispositivo)
        {
            case DISPOSITIVO.PC:
                foreach (char c in ipAddress)
                {
                    if (contPuntos == 2)
                    {
                        miRed = c.ToString();
                        //miRedInt = int.Parse(miRed);

                        foreach (char b in conectedRouter.GetComponent<LinkData>().ipAddress)
                        {
                            if (contPuntosRouter == 2)
                            {
                                suRed = b.ToString();
                                //suRedInt = int.Parse(suRed);
                                Debug.Log(suRed);
                                Debug.Log(miRed);
                                if (suRed == miRed)
                                {
                                    itsOK = true;
                                    checkforsamenet();
                                    Debug.Log("misma red entre " + ipAddress + " y " + conectedRouter.GetComponent<LinkData>().ipAddress);
                                }
                                else
                                {
                                    
                                    notOK = true;
                                    Debug.Log("Red diferente entre " + ipAddress + " y " + conectedRouter.GetComponent<LinkData>().ipAddress);

                                }
                                contPuntosRouter++;
                            }

                            if (b.ToString() == ".")
                            {
                                contPuntosRouter++;
                            }


                        }

                        contPuntos++;
                    }

                    if (c.ToString() == ".")
                    {
                        contPuntos++;
                    }

                }

                break;
            case DISPOSITIVO.ROUTER:
                checkforsamenet();
                break;
        }


        //checkforsamenet(); //verifica si la respuesta está en las respuestas posibles
        

        if(contPosible == 0)
        {
            itsOK = false;
            notOK = true;
        }

        if (itsOK == true)
        {
            OK = true;
        }else if(notOK == true)
        {
            OK = false;
        }

        return OK;
    }

    private void checkforsamenet()
    {
        foreach (string answer in possibleAnswers)
        {
            if (answer != ipAddress)
            {
                OK = false;
                Debug.Log("Ip no es posible");
            }
            else if (answer == ipAddress)
            {
                itsOK = true;
                contPosible++;
            }
        }
    }
}
