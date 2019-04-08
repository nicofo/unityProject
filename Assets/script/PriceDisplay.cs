using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceDisplay : MonoBehaviour
{
    public GameObject goldObject;
    public Text goldText;
    public GameObject foodObject;
    public Text foodText;
    public GameObject woodObject;
    public GameObject goldImage;
    public GameObject foodImage;
    public GameObject woodImage;
    public Text woodText;


    public void SetPrice(GameAttributes price)
    {
        if (price.gold > 0)
        {
            goldObject.SetActive(true);
            goldText.text = ((int)price.gold).ToString();
        }
        else
        {
            goldObject.SetActive(false);
            goldImage.SetActive(false);
        }

        if (price.wood > 0)
        {
            woodObject.SetActive(true);
            woodText.text = ((int)price.wood).ToString();
        }
        else
        {
            woodObject.SetActive(false);
            woodImage.SetActive(false);
        }

        if (price.food > 0)
        {
            foodObject.SetActive(true);
            foodText.text = ((int)price.food).ToString();
        }
        else
        {
            foodObject.SetActive(false);
            foodImage.SetActive(false);
        }
    }


}
