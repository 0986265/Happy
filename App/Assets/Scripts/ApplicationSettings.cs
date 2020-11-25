using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    private static ApplicationSettings _instance;

    public static ApplicationSettings Instance { get { return _instance; } }

    public AvatarManagerScriptableObject avatarPack;

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
}
