using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeerlingInfo : MonoBehaviour
{
    void Awake()
    {
        try
        {
            GetComponent<TMP_Text>().text = LeerlingObject.Firstname + " " + LeerlingObject.Lastname;
        } catch
        {

        }
    }
}
