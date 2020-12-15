using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Dashboard : MonoBehaviour
{

    public TMP_Text feelingStatus;
    public Image avatar;
    public Color ErrorColorText;

    private void Awake()
    {
        UpdateFeeling();
        GetAppointments();

        //Check for new Image
        string[] spriteId = LeerlingObject.Avatar.Split('-');
        avatar.sprite = ApplicationSettings.Instance.avatarPack.avatars[int.Parse(spriteId[1]) - 1];
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

    public void GetAppointments()
    {
        StartCoroutine(GetAppointmentsCo());
    }

    IEnumerator GetAppointmentsCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentId", LeerlingObject.Id);

        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/GetAppointments.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                AppointmentJSONConvert leerling = AppointmentJSONConvert.CreateFromJSON(www.downloadHandler.text);

            }

        }
    }
}
