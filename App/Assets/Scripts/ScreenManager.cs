using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScreenManager : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject startScreen;

    public GameObject dashboard;

    private static ScreenManager _instance;

    public static ScreenManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
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

    public void OpenDashboard()
    {
        currentScreen.SetActive(false);
        currentScreen = dashboard;
        currentScreen.SetActive(true);
    }
}
