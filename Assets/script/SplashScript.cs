using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

}
