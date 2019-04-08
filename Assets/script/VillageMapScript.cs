using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class VillageMapScript : MonoBehaviour
{
    // Start is called before the first frame update


    public Tile tileInput;

    Tilemap tilemap;
    Vector2Int temporalTilePosition;
    Vector2Int temporalTileDimension;
    Tile temporalTile;

    public SingletonGame state;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemap.SetTile(new Vector3Int(0, 0, 0), tileInput);
        Tile temporal = Tile.Instantiate(tileInput);
        temporal.color = Color.red;
        tilemap.SetTile(new Vector3Int(0, 2, 0), temporal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2Int getTemporalTilePosition()
    {
        return new Vector2Int(temporalTilePosition.x , temporalTilePosition.y);
    }

    public bool existsTile()
    {
        for (int x = temporalTilePosition.x; x < temporalTileDimension.x + temporalTilePosition.x; x++)
        {
            for (int y = temporalTilePosition.y; y < temporalTileDimension.y + temporalTilePosition.y; y++)
            {
                if (state.getBuildPosition(x, y) != null)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public void setTile(Tile tile, Vector2Int position)
    {
        temporalTile = Tile.Instantiate(tile);
        tilemap.SetTile(new Vector3Int(position.x, position.y, 0), tile);
    }

    public void setTemporalTile(Tile tile, Vector2Int position, Vector2Int dimenion)
    {
        temporalTile = Tile.Instantiate(tile);
        temporalTilePosition = position;
        temporalTile.color = existsTile() ? Color.red : Color.gray;
        temporalTileDimension = dimenion;
        tilemap.SetTile(new Vector3Int(temporalTilePosition.x, temporalTilePosition.y, -1),temporalTile);
    }

    public void moveTemporalTile(Vector2Int newPosition)
    {
        if (temporalTile == null) return;
        tilemap.SetTile(new Vector3Int(temporalTilePosition.x, temporalTilePosition.y, -1), null);
        temporalTilePosition = newPosition;
        temporalTile.color = existsTile() ? Color.red : Color.gray;
        tilemap.SetTile(new Vector3Int(temporalTilePosition.x, temporalTilePosition.y, -1), temporalTile);
    }

    public void removeTemporalTile()
    {
        tilemap.SetTile(new Vector3Int(temporalTilePosition.x, temporalTilePosition.y, -1), null);
        temporalTile = null;
    }
}
