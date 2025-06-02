using UnityEngine;

public enum CustomLanguage
{
    hindi,
    english
}

public class HomeManager : MonoBehaviour
{
    public static CustomLanguage language = CustomLanguage.english;
    public GameObject MainPage;

    public void OnHindiClick()
    {
        SetMainPage(CustomLanguage.hindi);
    }

    public void OnEnglishClick()
    {
        SetMainPage(CustomLanguage.english);
    }

    private void SetMainPage(CustomLanguage lang)
    {
        language = lang;
        MeenuManager.instance.PopulateItems();
        MainPage.SetActive(true);
        gameObject.SetActive(false);
    }
}
