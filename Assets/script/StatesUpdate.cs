using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatesUpdate : MonoBehaviour
{
    public Text goldText;
    public Text woodText;
    public Text foodText;
    public Text populationText;
    public SingletonGame state;
    // Start is called before the first frame update


    public Image goldStateImage;
    public Image woodStateImage;
    public Image foodStateImage;
    public Image populationStateImage;
    public Sprite up;
    public Sprite equals;
    public Sprite down;

    float lastGold = 0;
    float lastWood = 0;
    float lastFood = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        goldText.text = ((int)state.gold).ToString() + " /" + ((int)state.maxGold).ToString();
        woodText.text = ((int)state.wood).ToString() + " /" + ((int)state.maxWood).ToString();
        foodText.text = ((int)state.food).ToString() + " /" + ((int)state.maxFood).ToString();

        if (lastFood > state.food)
        {
            foodStateImage.sprite = down;
        } else if (lastFood < state.food)
        {
            foodStateImage.sprite = up;
        } else
        {
            foodStateImage.sprite = equals;
        }
        lastFood = (float)state.food;

        if (lastGold > state.gold)
        {
            goldStateImage.sprite = down;
        }
        else if (lastGold < state.gold)
        {
            goldStateImage.sprite = up;
        }
        else
        {
            goldStateImage.sprite = equals;
        }
        lastGold = (float)state.gold;

        if (lastWood > state.wood)
        {
            woodStateImage.sprite = down;
        }
        else if (lastWood < state.wood)
        {
            woodStateImage.sprite = up;
        }
        else
        {
            woodStateImage.sprite = equals;
        }
        lastWood = (float)state.wood;

        if (state.birthDeadState < 0)
        {
            populationStateImage.sprite = down;
        }
        else if (state.birthDeadState > 0)
        {
            populationStateImage.sprite = up;
        }
        else
        {
            populationStateImage.sprite = equals;
        }

        populationText.text = ((int)state.population).ToString() + " /" + ((int)state.maxPoulation).ToString();
    }
}
