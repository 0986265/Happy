using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeerlingJSONConvert
{
    public int id;

    public string firstname;
    public string lastname;

    public string email;
    public string nickname;
    public string avatar;
    public string color;

    public int active;

    public static LeerlingJSONConvert CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<LeerlingJSONConvert>(jsonString);
    }
}
