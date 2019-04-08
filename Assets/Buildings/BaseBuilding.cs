using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class BaseBuilding : ScriptableObject
{
    public string name;
    public string id;
    public GameAttributes basePrice;
    public GameAttributes multiplierPrice;
    public GameAttributes baseScale;
    public GameAttributes space;
    public GameAttributes upgradeCost;
    public GameAttributes upgradeScales;
    public Vector2Int dimension;
    public bool hasUpgrade;
    public bool isHouse;
    public Tile tile;

    public GameAttributes GetPrice(int Quantity)
    {
        GameAttributes att = new GameAttributes();
        att.gold = (int)(Mathf.Pow(multiplierPrice.gold, Quantity) * basePrice.gold);
        att.wood = (int)(Mathf.Pow(multiplierPrice.wood, Quantity) * basePrice.wood);
        att.food = (int)(Mathf.Pow(multiplierPrice.food, Quantity) * basePrice.food);


        return att;
    }


    public GameAttributes GetSpace()
    {
        if (space == null) return new GameAttributes();
        return space;
    }

}
