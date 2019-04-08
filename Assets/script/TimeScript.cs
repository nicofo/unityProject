using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float timer;
    public bool timeStarted = false;
    public int years;
    public int days;
    public Text daysText;
    public Text yearsText;
    int daysYear = 364;
    int daysSeason = 91;
    public int season = 2; // 0 - winter, 1 -spring, 2 - summer, 3 - autumn
    public float actualMultiplier;

    public PopUpScript popup;

    public Image actualImage;

    public Sprite winter;
    public Sprite spring;
    public Sprite summer;
    public Sprite autumn;

    public float winterMultiplier;
    public float springMultiplier;
    public float summerMultiplier;
    public float autumnMultiplier;
    public bool changedSeason = true;
    bool firstWinter = true;
    bool firstSpring = true;
    public void Start()
    {
        actualImage.sprite = summer;
        actualMultiplier = summerMultiplier;
        days = daysSeason * 2 + 1;
        timer = days;
        yearsText.text = "0Y";
    }

    void Update()
    {
        if (timeStarted)
        {
            timer += Time.deltaTime;
        }

        float minutes = Mathf.Floor(timer / 60);
        days = Mathf.RoundToInt(timer) % daysYear;
        if (!changedSeason && days % daysSeason == 0)
        {
            season = (season + 1) % 4;
            switch (season)
            {
                case 0:
                    actualImage.sprite = winter;
                    actualMultiplier = winterMultiplier;
                    if (firstWinter)
                    {
                        PopupMessage("Its Winter. The production is lower in winter");
                        firstWinter = false;
                    }
                    break;
                case 1:
                    actualImage.sprite = spring;
                    actualMultiplier = springMultiplier;
                    if (firstSpring)
                    {
                        PopupMessage("Its Spring. The production is higher at Spring");
                        firstSpring = false;
                    }
                    break;
                case 2:
                    actualImage.sprite = summer;
                    actualMultiplier = summerMultiplier;
                    break;
                case 3:
                    actualImage.sprite = autumn;
                    actualMultiplier = autumnMultiplier;
                    
                    break;
            }
            if (days % daysYear == 0)
            {
                years += 1;
                yearsText.text = years.ToString() + "Y";
            }
            
            
            changedSeason = true;
        } else if (days % daysSeason == 1)
        {
            changedSeason = false;
        }

        daysText.text = days != 0 ? days.ToString() + "D" : "365D";
    }

    void PopupMessage(string text)
    {
        popup.gameObject.SetActive(true);
        popup.SetMessage(text);
    }
}
