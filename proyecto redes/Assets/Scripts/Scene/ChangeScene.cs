using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{


    private const string MAINMENU = "MainMenu"; 
    private const string LEVELSELECTION = "LevelSelection";
    private const string LEVEL1W1L = "LEVEL1W1L";
    private const string LEVEL2W1L = "LEVEL2W1L";
    private const string LEVEL3W1L = "LEVEL3W1L";
    private const string LEVEL4W1L = "LEVEL4W1L";
    private const string LEVEL5W1L = "LEVEL5W1L";
    private const string LEVEL1W2L = "LEVEL1W2L";
    private const string LEVEL2W2L = "LEVEL2W2L";
    private const string LEVEL3W2L = "LEVEL3W2L";
    private const string LEVEL4W2L = "LEVEL4W2L";
    private const string LEVEL5W2L = "LEVEL5W2L";


    enum EnumCambiarEscena
    {
        MAINMENU,
        LEVELSELECTION,
        LEVEL1W1L,
        LEVEL2W1L,
        LEVEL3W1L,
        LEVEL4W1L,
        LEVEL5W1L,
        LEVEL1W2L,
        LEVEL2W2L,
        LEVEL3W2L,
        LEVEL4W2L,
        LEVEL5W2L

    }
    [SerializeField] private EnumCambiarEscena _escena;


    public void changeScene()
    {


        switch (_escena)
        {
            case EnumCambiarEscena.LEVELSELECTION:
                SceneManager.LoadScene(LEVELSELECTION);
                break;
            case EnumCambiarEscena.MAINMENU:
                SceneManager.LoadScene(MAINMENU);
                break;
            case EnumCambiarEscena.LEVEL1W1L:
                SceneManager.LoadScene(MAINMENU);
                break;
            case EnumCambiarEscena.LEVEL2W1L:
                SceneManager.LoadScene(LEVEL2W1L);
                break;
            case EnumCambiarEscena.LEVEL3W1L:
                SceneManager.LoadScene(LEVEL3W1L);
                break;
            case EnumCambiarEscena.LEVEL4W1L:
                SceneManager.LoadScene(LEVEL4W1L);
                break;
            case EnumCambiarEscena.LEVEL5W1L:
                SceneManager.LoadScene(LEVEL5W1L);
                break;
            case EnumCambiarEscena.LEVEL1W2L:
                SceneManager.LoadScene(LEVEL1W2L);
                break;
            case EnumCambiarEscena.LEVEL2W2L:
                SceneManager.LoadScene(LEVEL2W2L);
                break;
            case EnumCambiarEscena.LEVEL3W2L:
                SceneManager.LoadScene(LEVEL3W2L);
                break;
            case EnumCambiarEscena.LEVEL4W2L:
                SceneManager.LoadScene(LEVEL4W2L);
                break;
            case EnumCambiarEscena.LEVEL5W2L:
                SceneManager.LoadScene(LEVEL5W2L);
                break;


            default:
                Debug.Log("El index agregado esta erroneo");
                break;
        }

    }

    public void changeLevelwithParameter(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void RetryLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void quitApp()
    {
        Application.Quit();
    }
}