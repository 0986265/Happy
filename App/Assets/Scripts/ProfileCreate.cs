using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ProfileCreate : MonoBehaviour
{
    private string selectedAvatar = "monster-1";
    private string selectedColor = "blue";

    public Image selectedAvatarImage;

    public GameObject colorScreen;

    public GameObject feelingScreen;
    public GameObject dashboardScreen;

    public void Awake()
    {
        string[] selectedAvatarId = LeerlingObject.Avatar.Split('-');
        selectedAvatarImage.sprite = ApplicationSettings.Instance.avatarPack.avatars[int.Parse(selectedAvatarId[1]) - 1];
    }

    public void ChooseAvatar(string avatarId)
    {
        selectedAvatar = avatarId;
        string[] selectedAvatarId = avatarId.Split('-');
        selectedAvatarImage.sprite = ApplicationSettings.Instance.avatarPack.avatars[int.Parse(selectedAvatarId[1]) - 1];
    }

    public void SubmitAvatar()
    {
        StartCoroutine(SubmitAvatarCo());
    }

    IEnumerator SubmitAvatarCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentId", LeerlingObject.Id);
        form.AddField("avatarId", selectedAvatar);

        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/StudentAvatar.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                LeerlingObject.Avatar = selectedAvatar;
                ScreenManager.Instance.OpenScreen(colorScreen);
            }

        }
    }

    public void ChooseColor(string color)
    {
        selectedColor = color;
    }

    public void SubmitColor()
    {
        StartCoroutine(SubmitColorCo());
    }

    IEnumerator SubmitColorCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentId", LeerlingObject.Id);
        form.AddField("selectedColor", selectedColor);

        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/StudentColor.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                LeerlingObject.Color = selectedColor;
                PlayerPrefs.SetString("Color", LeerlingObject.Color);
                Debug.Log("leerling Color: " + LeerlingObject.Color);
                if (LeerlingObject.Commented == "true")
                {
                    FindObjectOfType<ScreenManager>().OpenScreen(feelingScreen);
                }
                else
                {
                    FindObjectOfType<ScreenManager>().OpenScreen(dashboardScreen);
                }
            }

        }
    }
}
