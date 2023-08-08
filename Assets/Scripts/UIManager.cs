using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OpenMenu(GameObject menu)
    {
        menu.gameObject.SetActive(true);
    }
    public void CloseMenu(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }
}
