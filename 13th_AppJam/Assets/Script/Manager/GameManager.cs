﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("GameManager").AddComponent<GameManager>();
        }
    }

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this);
    }
}