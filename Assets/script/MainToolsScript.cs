using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToolsScript : MonoBehaviour
{
    public GameObject addBuild;
    public GameObject self;
    public CameraPanning camera;

    public CustomAudioManager audioManager;

    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    void OnDisable()
    {
        camera.active = false;
        
        audioManager.LowerPass(true);
    }

    void OnEnable()
    {
        camera.active = true;
        audioManager.LowerPass(false);
        addBuild.SetActive(false);
    }

    public void AddBuild()
    {
        addBuild.SetActive(true);
        self.SetActive(false);
        
    }



}
