using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuCanvas : MonoBehaviour {
    public GameObject Logo;
    public GameObject Touch2Start;

    public Animator MainCamera_Animator;

    public List<Image> Chapters;
    public List<Text> ChaptersText;

    public RectTransform Recttransform;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuActive()
    {
        Logo.SetActive(false);
        Touch2Start.SetActive(false);

        MainCamera_Animator.SetTrigger("Menu");

        StartCoroutine(FadeIn());
    }

    public void ButtonClicked(int num)
    {
        if (num == 1)
            SceneChanger.Instance.ChangeScene("InGame");
    }

    IEnumerator FadeIn()
    {
        while(Chapters[0].color.a < 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Chapters[i].color = new Color(Chapters[i].color.r, Chapters[i].color.g, Chapters[i].color.b, Chapters[i].color.a + 0.01f);
                ChaptersText[i].color = new Color(ChaptersText[i].color.r, ChaptersText[i].color.g, ChaptersText[i].color.b, ChaptersText[i].color.a + 0.01f);
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}
