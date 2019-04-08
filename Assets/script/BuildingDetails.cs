using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDetails : MonoBehaviour
{

    int index = -1;
    InstanitiatedBuilding buildInst;

    public GameObject mainTool;
    public GameObject buildingDetails;

    public GameObject workers;

    public Text textName;
    public Image buildImage;

    public Button upgradeButton;

    public Text textPersons;

    public CustomAudioManager audioManager;
    public AudioClip clip;

    public PriceDisplay priceButton;

    public SingletonGame state;

    public void SetBuild(InstanitiatedBuilding b, int index)
    {
        this.index = index;
        buildInst = b;
        textName.text = buildInst.build.name;
        buildImage.sprite = buildInst.build.tile.sprite;
    }

    public void Close()
    {
        buildingDetails.SetActive(false);
        mainTool.SetActive(true);
        audioManager.PlayFx(clip);
    }


    public void AddPerson()
    {
        state.AddPersonToBuild(index);
    }

    public void RemovePerson()
    {
        state.RestPersonToBuild(index);
    }

    public void ClickUpgrade()
    {
        if (state.food >= buildInst.build.upgradeCost.food
            && state.gold >= buildInst.build.upgradeCost.gold
            && state.wood >= buildInst.build.upgradeCost.wood) {
            state.food -= buildInst.build.upgradeCost.food;
            state.gold -= buildInst.build.upgradeCost.gold;
            state.wood -= buildInst.build.upgradeCost.wood;
            buildInst.upgraded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buildInst != null) {
            textPersons.text = ((int)buildInst.people).ToString() + "/" + ((int)buildInst.build.space.population).ToString();
            if (buildInst.upgraded || !buildInst.build.hasUpgrade)
            {
                upgradeButton.gameObject.SetActive(false);
            } else
            {
                upgradeButton.gameObject.SetActive(true);

                priceButton.SetPrice(buildInst.build.upgradeCost);
            }

            workers.SetActive(!buildInst.build.isHouse);
            
        }
    }
}
