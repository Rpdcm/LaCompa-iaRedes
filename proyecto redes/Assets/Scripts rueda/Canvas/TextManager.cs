using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour {

	public GameObject flag;
	public GameObject InputPanel;
	public InputField inputField;
    public GameObject PanelAyuda;
    private bool ok;
    private GameObject[] items;
    public GameObject botonAyuda;
    public GameObject botonCheck;
    public GameObject WINPANEL;
    public GameObject LOSEPANEL;
    private bool notOK = false;
    public int level = 0;


	public void GetAndSetIP(InputField input){  //Función para recibir el Input y asignar la IP al objeto que abrió el Panel
		flag.gameObject.GetComponent<LinkData> ().ipAddress = input.text;
		InputPanel.SetActive (false);
	}

	public void setFlag(GameObject obj_flag){  //Función que recibe el objeto que necesita cambiar la IP y luego abre el panel
		flag = obj_flag;
		inputField.text = flag.gameObject.GetComponent<LinkData>().ipAddress;
		InputPanel.SetActive (true);
	}

    public void check()
    {
        botonAyuda.SetActive(false);
        botonCheck.SetActive(false);
        items = GameObject.FindGameObjectsWithTag("Linked");
        
        foreach(GameObject item in items)
        {
            ok = item.GetComponent<LinkData>().CheckIP();
            if(ok == false)
            {
                notOK = true;
            }
        }

        if (notOK == false)
        {
            WINPANEL.SetActive(true);
            if (level == PlayerPrefs.GetInt("World2", 0))
            {
                PlayerPrefs.SetInt("World2", level + 1);
            }
        }
        else if(notOK == true)
        {
            LOSEPANEL.SetActive(true);
        }
    }

    public void openHelp()
    {
        PanelAyuda.SetActive(true);
    }

    public void closeHelp()
    {
        PanelAyuda.SetActive(false);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
