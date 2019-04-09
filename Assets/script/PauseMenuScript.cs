using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    
    public GameObject optionMenu;
    public PopUpScript popup;


    public void openOptions()
    {
        popup.gameObject.SetActive(true);
        popup.OpenOptions();
    }

    public void ExitOptions()
    {
        SceneManager.LoadScene("Splash", LoadSceneMode.Single);
    }

    public void ResetOptions()
    {
       SceneManager.LoadScene("Field", LoadSceneMode.Single);
    }   

}
