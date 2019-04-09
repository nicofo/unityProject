using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject maintool;
    public GameObject message;
    public GameObject options;
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
        endGame.SetActive(false);
        options.SetActive(false);
        message.SetActive(true);
        messageText.text = text;
    }

    public void CloseOptions()
    {
        options.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        message.SetActive(false);
        endGame.SetActive(false);
        options.SetActive(true);
    }

    public void SetEndGame(string text, string time)
    {
        message.SetActive(false);
        options.SetActive(false);
        endGame.SetActive(true);
        endGameText.text = text;
        timeText.text = time;
    }
}
