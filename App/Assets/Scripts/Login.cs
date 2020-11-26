using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    public GameObject feelingScreen;
    public GameObject accountScreen;

    void Start()
    {

    }

    public void LoginUser()
    {
        StartCoroutine(LoginUserCo(usernameField.text, passwordField.text));
        // Debug.Log(usernameField.text);
    }

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://boostworks.online/GetStudents.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
    IEnumerator LoginUserCo(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                try
                {

                    LeerlingJSONConvert leerling = LeerlingJSONConvert.CreateFromJSON(www.downloadHandler.text);

                    //Setup Logged in Leerling
                    LeerlingObject.Id = leerling.id;
                    LeerlingObject.Firstname = leerling.firstname;
                    LeerlingObject.Lastname = leerling.lastname;
                    LeerlingObject.Email = leerling.email;
                    LeerlingObject.Nickname = leerling.nickname;
                    LeerlingObject.Active = leerling.active;

                    //Continue to next screen
                    if (LeerlingObject.Active == 1)
                    {
                        FindObjectOfType<ScreenManager>().OpenScreen(feelingScreen);
                    } else
                    {
                        FindObjectOfType<ScreenManager>().OpenScreen(accountScreen);
                    }
                }
                catch
                {

                    Debug.LogWarning("Credentials not correct");
                }


            }
        }
    }
}
