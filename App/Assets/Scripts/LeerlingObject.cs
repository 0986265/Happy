using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeerlingObject
{
    public int id;

    public string firstname;
    public string lastname;

    public string email;
    public string nickname;

    //public string color;
    //public string interests;

    ///public string avatar;

    public static LeerlingObject CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<LeerlingObject>(jsonString);
    }
}
