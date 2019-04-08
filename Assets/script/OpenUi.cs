using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenUi : MonoBehaviour
{
    public GameObject actionUI;

    public void ActiveUi()
    {
        actionUI.SetActive(true);
    }
    public void DeactiveUi()
    {
        actionUI.SetActive(false);
    }

}
