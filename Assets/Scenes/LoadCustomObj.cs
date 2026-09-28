using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadCustomObj", menuName = "Scriptable Objects/LoadCustomObj")]
public class LoadCustomObj : ScriptableObject
{
    public List<ChalisaAssetData> chalisaAssetDatas;
}
[Serializable]
public class ChalisaAssetData
{
    public string id;
    public AudioClip clip;
    public Sprite image;
}
