using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private bool isCanNext;
    public MenuCanvas menuCanvas;

    private void Awake()
    {
        isCanNext = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanNext)
            menuCanvas.MenuActive();
    }

    public void Complete()
    {
        isCanNext = true;
    }
}