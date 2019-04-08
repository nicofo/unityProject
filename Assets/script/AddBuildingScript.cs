using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AddBuildingScript : MonoBehaviour
{
    // Start is called before the first frame update
    BaseBuilding build;
    public Tilemap map;
    public VillageMapScript village;
    public GameObject toClose;
    public SingletonGame state;

    public GameObject mainTools;

    public CustomAudioManager audioManager;
    public AudioClip clip;

    bool actived = false;
    void OnStart()
    {
        if (build == null) return;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = map.WorldToCell(mouseWorldPos);
        village.setTemporalTile(Tile.Instantiate(build.tile), new Vector2Int(coordinate.x, coordinate.y), build.dimension);
        actived = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!actived) OnStart();
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        Vector3Int coordinate = map.WorldToCell(v3);
        village.moveTemporalTile(new Vector2Int(coordinate.x, coordinate.y));

        if (Input.GetMouseButtonDown(0) && ! village.existsTile())
        {
            GameAttributes price = build.GetPrice(state.buildQunatity.ContainsKey(build.name) ? state.buildQunatity[build.name] : 0);
            state.gold -= price.gold;
            state.wood -= price.wood;
            state.food -= price.food;
            InstanitiatedBuilding inst = new InstanitiatedBuilding();
            inst.build = build;
            inst.position = village.getTemporalTilePosition();
            state.AddBuilding(inst);
            village.setTile(Tile.Instantiate(build.tile), village.getTemporalTilePosition());
            audioManager.PlayFx(clip);
            Quit(); 
        }

        if (Input.GetMouseButtonDown(1))
        {
            Quit();
        }
    }

    public void setBuild(BaseBuilding build)
    {
        this.build = build;
    }

    public void Quit()
    {
        village.removeTemporalTile();
        build = null;
        actived = false;
        toClose.SetActive(false);
        mainTools.SetActive(true);
    }
}
