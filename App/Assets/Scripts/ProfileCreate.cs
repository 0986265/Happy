using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ProfileCreate : MonoBehaviour
{
    private string selectedAvatar = "monster1";

    public Image selectedAvatarImage;
    public Sprite[] avatarImages;

    public GameObject feelingScreen;


    public void ChooseAvatar(string avatarId)
    {
        selectedAvatar = avatarId;
        string[] selectedAvatarId = avatarId.Split('r');
        selectedAvatarImage.sprite = avatarImages[int.Parse(selectedAvatarId[1]) - 1];
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
                FindObjectOfType<ScreenManager>().OpenScreen(feelingScreen);
            }

        }
    }
}
