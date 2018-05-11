using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public GameObject panelQuestion;

	public void changeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OpenPanelQ()
    {
        panelQuestion.SetActive(true);
    }

}
