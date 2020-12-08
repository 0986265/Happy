using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dashboard : MonoBehaviour
{

    public TMP_Text feelingStatus;
    public Color ErrorColorText;

    private void Awake()
    {
        UpdateFeeling();
    }

    void UpdateFeeling()
    {
        if(LeerlingObject.Commented == "false")
        {
            feelingStatus.text = "Je hebt het vandaag al ingevuld!";
        } else
        {
            feelingStatus.text = "Je kan weer een gevoel invullen!";
        }
    }

    public void OpenFeelingScreen(GameObject screen)
    {
        if (LeerlingObject.Commented == "false")
        {
            feelingStatus.color = ErrorColorText;
        } else
        {
            ScreenManager.Instance.OpenScreen(screen);
        }
    }
}
