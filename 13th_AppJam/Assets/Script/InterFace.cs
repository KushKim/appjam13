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
    bool check = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Checker();

    }

    void Checker()
    {
        if (!check && playerStatus.Star >= 26)
            Win();

        if (!check && playerStatus.Hp <= 0)
            Lose();
    }

    void Win()
    {
        SucFail.gameObject.SetActive(true);
        Fail.gameObject.SetActive(false);
        StarText.text = playerStatus.Star.ToString();
        check = true;
    }

    void Lose()
    {
        SucFail.gameObject.SetActive(true);
        Suc.gameObject.SetActive(false);
        StarText.text = playerStatus.Star.ToString();
        check = true;

    }

    public void SceneChangerer()
    {
        SceneChanger.Instance.ChangeScene("Title");
    }
}
