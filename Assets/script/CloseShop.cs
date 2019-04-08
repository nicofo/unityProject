using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShop : MonoBehaviour
{
    public GameObject shop;
    public GameObject mainTool;
    // Start is called before the first frame update
    public void Close()
    {
        shop.SetActive(false);
        mainTool.SetActive(true);
    }
}
