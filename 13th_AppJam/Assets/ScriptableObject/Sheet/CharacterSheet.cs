using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class CharacterData
{
    public string name;

    public GameObject prefab;

    [Space(15f)]

    public int hp;
    public float moveSpeed;

    public Attack attack;

    [Serializable]
    public struct Attack
    {
        public float demage;
        public float delay;
    }
}

public class CharacterSheet : Sheet<CharacterData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/CharacterSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<CharacterSheet>();
    }
#endif
}