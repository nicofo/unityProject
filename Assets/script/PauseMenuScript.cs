using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject popup;
    public GameObject optionMenu;


    public void openOptions()
    {
        popup.SetActive(true);
        optionMenu.SetActive(true);
    }

    public void closeOptions()
    {
        popup.SetActive(false);
        optionMenu.SetActive(false);
    }

    public void ExitOptions()
    {
        SceneManager.LoadScene("Splash", LoadSceneMode.Single);
    }

    public void ResetOptions()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

}
