using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PasswordReset : MonoBehaviour
{

    public TMP_InputField emailField;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ResetPassword()
    {
        StartCoroutine(PasswordResetFunction(emailField.text));
        // Debug.Log(emailField.text);
    }

    IEnumerator PasswordResetFunction(string email)
    {
    
        

        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);

        UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/Reset.php", form);

        yield return www.SendWebRequest();

       
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
        
    }
}
