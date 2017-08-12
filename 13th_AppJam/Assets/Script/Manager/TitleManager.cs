using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private bool isCanNext;

    private void Awake()
    {
        isCanNext = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanNext)
            SceneChanger.Instance.ChangeScene(SceneType.Menu);
    }

    public void Complete()
    {
        isCanNext = true;
    }
}