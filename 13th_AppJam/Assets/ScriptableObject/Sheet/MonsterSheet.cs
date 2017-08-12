using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class MonsterData
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

public class MonsterSheet : Sheet<MonsterData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/MonsterSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<MonsterSheet>();
    }
#endif
}