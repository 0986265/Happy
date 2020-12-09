using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;

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

    public void SubmitAppointment()
    {
        // StartCoroutine(SubmitAppointmentCo());
        StartCoroutine(GetCounselors());
    }

    IEnumerator GetCounselors()
    {
        UnityWebRequest counselors = UnityWebRequest.Get("http://tle_app_scripts.test/GetCounselors.php");

        yield return counselors.SendWebRequest();

        if(counselors.isNetworkError || counselors.isHttpError)
        {
            Debug.Log(counselors.error);
        }
        else
        {
            // Debug.Log(counselors.downloadHandler.text);
            CounselorsInfo[] counselorsData = JsonConvert.DeserializeObject<CounselorsInfo[]>(counselors.downloadHandler.text);

            foreach(CounselorsInfo counselor in counselorsData)
            {
                Debug.Log(counselor.name);
            }
        }
    }

    IEnumerator SubmitAppointmentCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentId", LeerlingObject.Id);
        form.AddField("counselorId", councerlor.text);
        form.AddField("subject", subject.itemText.text);
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
            }

        }
    }
}
