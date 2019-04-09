using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Field", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
