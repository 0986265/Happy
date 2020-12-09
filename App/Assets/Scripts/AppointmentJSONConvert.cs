using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//{"id":"96","student_id":"9","counselor_id":"2","appointment_date":null,"attending":"1","subject":"Testsubject"}
public class AppointmentJSONConvert
{
    public int id;

    public int student_id;
    public int counselor_id;

    public string appointment_date;
    public int attending;
    public string subject;


    public static AppointmentJSONConvert CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<AppointmentJSONConvert>(jsonString);
    }
}
