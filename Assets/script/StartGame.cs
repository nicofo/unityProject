using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public BaseBuilding startBuild1;
    public BaseBuilding startBuild2;
    public Tilemap map;
    public VillageMapScript village;
    public SingletonGame state;

    public CustomAudioManager audioManager;
    public AudioClip clip;
    public AudioClip startSong;


    void LateUpdate()
    {
        //audioManager.PlayFx(clip, 0.04f);
        //audioManager.PlaySong(startSong, 0.6f);
        InstanitiatedBuilding inst1 = ScriptableObject.CreateInstance<InstanitiatedBuilding>();
        inst1.build = startBuild1;
        inst1.position = new Vector2Int(152, -82);
        state.AddBuilding(inst1);
        village.setTile(Tile.Instantiate(startBuild1.tile), inst1.position);

        InstanitiatedBuilding inst2 = ScriptableObject.CreateInstance<InstanitiatedBuilding>();
        inst2.build = startBuild2;
        inst2.position = new Vector2Int(156, -89);
        state.AddBuilding(inst2);
        village.setTile(Tile.Instantiate(startBuild2.tile), inst2.position);
        state.population = 1;
        state.freePeople = 1;
        int index = state.getIndex(inst1);
        state.AddPersonToBuild(index);
        Destroy(this);
    }

}
