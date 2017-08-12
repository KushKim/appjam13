using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InterFace : MonoBehaviour {
    public GameObject Monsters;
    public PlayerStatus playerStatus;

    public Canvas SucFail;
    public Text StarText;
    public Image Suc;
    public Image Fail;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Checker();

    }

    void Checker()
    {
        if (WaveManager.Instance.WaveNum == 3 && Monsters.transform.childCount == 0)
            Win();

        if (playerStatus.Hp <= 0)
            Lose();
    }

    void Win()
    {
        SucFail.gameObject.SetActive(true);
        Fail.gameObject.SetActive(false);
        StarText.text = playerStatus.Star.ToString();
    }

    void Lose()
    {
        SucFail.gameObject.SetActive(true);
        Suc.gameObject.SetActive(false);
        StarText.text = playerStatus.Star.ToString();
    }

    public void SceneChangerer()
    {
        SceneChanger.Instance.ChangeScene("Title");
    }
}
