using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickBuild : MonoBehaviour
{
    public SingletonGame state; 
    public GameObject mainTool;
    public GameObject buildingDetails;
    public Tilemap map;

    private Vector3 clickPosition;
    System.DateTime downTime = System.DateTime.Now;

    public CustomAudioManager audioManager;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            downTime = System.DateTime.Now;
        }

        
        if (Input.GetMouseButtonUp(0) && (System.DateTime.Now - downTime).TotalMilliseconds <= 600)
        {
            clickPosition.z = 10.0f;
            var v3 = Camera.main.ScreenToWorldPoint(clickPosition);
            Vector3Int coordinate = map.WorldToCell(v3);
            InstanitiatedBuilding b = state.getBuildPosition(coordinate.x, coordinate.y);
            if (b != null)
            {
                buildingDetails.SetActive(true);
                BuildingDetails other = (BuildingDetails)buildingDetails.GetComponent(typeof(BuildingDetails));
                other.SetBuild(b, state.getIndex(b));
                audioManager.PlayFx(clip);
                mainTool.SetActive(false);

            } else
            {
                Debug.Log("Not clicked " + coordinate.x+ " " +
                    coordinate.y);
            }
        }

    }
}
