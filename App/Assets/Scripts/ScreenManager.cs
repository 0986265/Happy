using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScreenManager : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject startScreen;

    void Start()
    {
        currentScreen = startScreen;
        currentScreen.SetActive(true);
    }

    public void OpenScreen(GameObject screen)
    {
        currentScreen.SetActive(false);
        currentScreen = screen;
        currentScreen.SetActive(true);
    }

}
