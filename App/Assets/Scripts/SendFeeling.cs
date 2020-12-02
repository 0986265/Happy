using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class SendFeeling : MonoBehaviour
{
    public GameObject feelingScreen;
    public GameObject commentScreen;

    public TMP_InputField commentField;
    public Image FeelingImage;

    private int selectedFeeling = 1;

    public Sprite[] emojies;

    public Image selectedAvatarImage;

    private void Awake()
    {
        feelingScreen.SetActive(true);
        commentScreen.SetActive(false);
        string[] selectedAvatarId = LeerlingObject.Avatar.Split('-');
        selectedAvatarImage.sprite = ApplicationSettings.Instance.avatarPack.avatars[int.Parse(selectedAvatarId[1]) - 1];
    }

    public void Update()
    {
        switch (selectedFeeling) {
            case 1:
                FeelingImage.sprite = emojies[0];
                break;
            case 2:
                FeelingImage.sprite = emojies[1];
                break;
            case 3:
                FeelingImage.sprite = emojies[2];
                break;
            case 4:
                FeelingImage.sprite = emojies[3];
                break;
            case 5:
                FeelingImage.sprite = emojies[4];
                break;
        }
    }

    public void SubmitFeeling(int feeling)
    {
        selectedFeeling = feeling;
        commentScreen.SetActive(true);
        feelingScreen.SetActive(false);
    }

    public void SendComment()
    {
        StartCoroutine(SendFeelingCo(LeerlingObject.Id, selectedFeeling, commentField.text));
    }


    IEnumerator SendFeelingCo(int id, int feeling, string comment)
    {
        WWWForm form = new WWWForm();
        form.AddField("studentId", id);
        form.AddField("feelingScore", feeling);
        form.AddField("feelingComment", comment);

        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/SendFeeling.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            } else
            {
                Debug.Log(www.downloadHandler.text);
                ScreenManager.Instance.OpenDashboard();
            }

        }
    }
}
