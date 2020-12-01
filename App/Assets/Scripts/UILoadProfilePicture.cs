using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoadProfilePicture : MonoBehaviour
{
    private void Awake()
    {
        string[] spriteId = LeerlingObject.Avatar.Split('-');
        GetComponent<Image>().sprite = ApplicationSettings.Instance.avatarPack.avatars[int.Parse(spriteId[1]) - 1];
    }
}
