using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToAddButtonScript : MonoBehaviour
{
    public BaseBuilding build;
    public Image buildImage;
    public GameObject actionUI;
    public GameObject shop;
    public Text nameText;
    public SingletonGame state;
    public PriceDisplay priceDisplay;
    GameAttributes price;


    void Start()
    {
        buildImage.sprite = build.tile.sprite;
        nameText.text = build.name;
        price = build.GetPrice(state.buildQunatity.ContainsKey(build.name) ? state.buildQunatity[build.name] : 0);
        priceDisplay.SetPrice(price);
    }

    private void UpdatePrice()
    {
        nameText.text = build.name;
        price = build.GetPrice(state.buildQunatity.ContainsKey(build.name) ? state.buildQunatity[build.name] : 0);
        priceDisplay.SetPrice(price);
    }

    public void ClickEvent()
    {
        if (state.gold >= price.gold && state.wood >= price.wood && state.food >= price.food)
        {
            actionUI.SetActive(true);
            AddBuildingScript other = (AddBuildingScript)actionUI.GetComponent(typeof(AddBuildingScript));
            other.setBuild(build);
            shop.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        UpdatePrice();
    }

    void SetBuild(BaseBuilding build, GameObject actionUI)
    {
        this.build = build;
        this.actionUI = actionUI;
        buildImage.sprite = build.tile.sprite;
    }
}
