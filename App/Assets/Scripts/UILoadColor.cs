using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoadColor : MonoBehaviour
{
    public enum ColorType { Primary, Secondary };
    public ColorType colorType;

    public Button selectButtonElement;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("Color"))
        {
            PlayerPrefs.SetString("Color", "0");
        }

        UpdateColors();
    }

    public void UpdateColors()
    {
        if(selectButtonElement == null)
        {
            if (colorType == ColorType.Primary)
            {
                GetComponent<Image>().color = ApplicationSettings.Instance.colorPack.primaryColorCodes[int.Parse(PlayerPrefs.GetString("Color"))];
            }
            else
            {
                GetComponent<Image>().color = ApplicationSettings.Instance.colorPack.secondaryColorCodes[int.Parse(PlayerPrefs.GetString("Color"))];
            }
        } else
        {
            if (colorType == ColorType.Primary)
            {
                ColorBlock buttonColors = selectButtonElement.colors;
                buttonColors.selectedColor = ApplicationSettings.Instance.colorPack.primaryColorCodes[int.Parse(PlayerPrefs.GetString("Color"))];
                selectButtonElement.colors = buttonColors;
            }
            else
            {
                ColorBlock buttonColors = selectButtonElement.colors;
                buttonColors.selectedColor = ApplicationSettings.Instance.colorPack.secondaryColorCodes[int.Parse(PlayerPrefs.GetString("Color"))];
                selectButtonElement.colors = buttonColors;
            }
        }
        
    }
}
