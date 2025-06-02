using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContent : MonoBehaviour
{
    public TextMeshProUGUI headerText, contentText;
    public Image bgImage, icon;
    public ScrollRect scroll;
    public AudioSource audi;
    float audioLength;

    public void SetData(ChalisaData chalisaData, Sprite sprite, AudioClip audioClip)
    {
        scroll.content.transform.localPosition = new Vector3(scroll.content.transform.localPosition.x, 0, scroll.content.transform.localPosition.z);
        if (HomeManager.language == CustomLanguage.english)
        {
            headerText.text = chalisaData.display_name_eng;
            contentText.text = chalisaData.content_eng;
        }
        else
        {
            headerText.text = chalisaData.display_name_hindi;
            contentText.text = chalisaData.content_hindi;
        }
        icon.sprite = sprite;
        audi.clip = audioClip;
        audi.Play();
        audioLength = audioClip.length;
    }

    // float cutomeValue;
    // void LateUpdate()
    // {
    //     cutomeValue += Time.deltaTime;
    //     scroll.verticalScrollbar.value = 1 - (cutomeValue / audioLength);
    // }
}
