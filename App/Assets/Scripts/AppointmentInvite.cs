using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;
using System;


public class AppointmentInvite : MonoBehaviour
{
    public TMP_Dropdown subject;
    public TMP_InputField message;
    public TMP_InputField councerlor;
    public TMP_Dropdown counselorDropdown;

    void Start()
    {

        StartCoroutine(FillDropdown());
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
        // StartCoroutine(SubmitAppointmentCo());
        
    }

    IEnumerator GetCounselors(Action<string> data)
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

            data(counselors.downloadHandler.text);

        }
    }

    IEnumerator FillDropdown()
    {
        counselorDropdown.options.Clear();

        CounselorsInfo[] counselorsData = null;

        yield return StartCoroutine(GetCounselors(data => counselorsData = JsonConvert.DeserializeObject<CounselorsInfo[]>(data)));

        foreach(CounselorsInfo counselor in counselorsData)
        {
            // Debug.Log(counselor.name);
            counselorDropdown.options.Add(new TMP_Dropdown.OptionData() { text = counselor.name });
        }
         
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
