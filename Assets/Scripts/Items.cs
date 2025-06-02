using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    ChalisaData chalisaData;
    public Image iconImage;

    public void SetData(ChalisaData data, Sprite sp)
    {
        this.chalisaData = data;
        Debug.Log("lang:" + HomeManager.language);
        if (HomeManager.language == CustomLanguage.english)
        {
            itemNameText.text = chalisaData.display_name_eng;
        }
        else
        {
            
            itemNameText.text = chalisaData.display_name_hindi;
        }
        iconImage.sprite = sp;
    }

    public void OnButtonClick()
    {
        MeenuManager.instance.EnableContentPage(true, chalisaData);
        Debug.Log("itemclicked");
    }
}
