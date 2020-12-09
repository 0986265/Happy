using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class AppointmentInvite : MonoBehaviour
{
    public TMP_Dropdown subject;
    public TMP_InputField message;
    public TMP_InputField councerlor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(GetCounsloursCo());
    }

    IEnumerator GetCounsloursCo()
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/GetCounselors.php", form))
        {
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

    public void SubmitAppointment()
    {
        StartCoroutine(SubmitAppointmentCo());
    }

    IEnumerator SubmitAppointmentCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentId", LeerlingObject.Id);
        form.AddField("counselorId", councerlor.text);
        form.AddField("subject", subject.options[subject.value].text);
        form.AddField("message", message.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://boostworks.online/AppointmentInvite.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                ScreenManager.Instance.OpenDashboard();
            }

        }
    }
}
