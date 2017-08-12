using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class WeaponData
{
    public string name;

    //public GameObject prefab;

    [Space(15f)]


    public float demage;
    public float delay;

}

public class WeaponSheet : Sheet<WeaponData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/WeaponSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<WeaponSheet>();
    }
#endif
}