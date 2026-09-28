using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MeenuManager : MonoBehaviour
{
    public Items ItemPrefabs;
    public Transform ParentTransform;

    //public List<Sprite> iconSprites;

    public static MeenuManager instance;

    public GameObject mainPage;
    public ItemContent ContentPage;

    public TextAsset jsonFile;
    public AllChalisaData jsonData;

    public LoadCustomObj scriptableObject;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // byte[] bytes = Encoding.Default.GetBytes(jsonFile.ToString());
        // string myString = Encoding.UTF8.GetString(bytes);

        TextAsset textAsset = Resources.Load<TextAsset>("json_data");

        jsonData = JsonUtility.FromJson<AllChalisaData>(jsonFile.ToString());
        Debug.Log(textAsset.text);
    }

    public void PopulateItems()
    {
        GenerateItems(jsonData);
    }

    public void EnableContentPage(bool active, ChalisaData chalisaData = null)
    {
        mainPage.SetActive(!active);
        ContentPage.gameObject.SetActive(active);

        if (chalisaData != null)
            ContentPage.SetData(chalisaData, GetChalisaAssetData(chalisaData.id).image, GetChalisaAssetData(chalisaData.id).clip);
    }

    ChalisaAssetData GetChalisaAssetData(string id)
    {
        for (int i = 0; i < scriptableObject.chalisaAssetDatas.Count; i++)
        {
            if (scriptableObject.chalisaAssetDatas[i].id == id)
            {
                return scriptableObject.chalisaAssetDatas[i];
            }
        }

        Debug.Log("id-----:" + id);
        return null;
    }

    public void GenerateItems(AllChalisaData data)
    {
        for (int i = 0; i < data.chalisaData.Length; i++)
        {
            Items item = Instantiate(ItemPrefabs, ParentTransform);
            item.name = data.chalisaData[i].id;
            item.SetData(data.chalisaData[i], GetChalisaAssetData(data.chalisaData[i].id).image);
        }
    }

    public void ContentBackButtonClick()
    {
        EnableContentPage(false);
    }


}


[Serializable]
public class AllChalisaData
{
    public ChalisaData[] chalisaData;
}

[Serializable]
public class ChalisaData
{
    public string id;
    public string display_name_eng;
    public string display_name_hindi;
    public string content_eng;
    public string content_hindi;

}


