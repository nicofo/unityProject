using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject maintool;
    public GameObject message;
    public Text messageText;
    public SingletonGame state;

    public GameObject endGame;
    public Text endGameText;
    public Text timeText;

    void OnDisable()
    {
        maintool.SetActive(true);
        state.active = true;
    }

    void OnEnable()
    {
        maintool.SetActive(false);
        state.active = false;
    }

    public void CloseMessage()
    {
        message.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void SetMessage(string text)
    {
        message.SetActive(true);
        messageText.text = text;
    }

    public void SetEndGame(string text, string time)
    {
        endGame.SetActive(true);
        endGameText.text = text;
        timeText.text = time;
    }
}
