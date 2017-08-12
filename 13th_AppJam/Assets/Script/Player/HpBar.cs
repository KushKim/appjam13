using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour {
    private CharacterSheet characterSheet;

    private Image image;

    private float PlayerHp;
	// Use this for initialization
	void Start () {
        image = transform.GetComponent<Image>();

        characterSheet = InGameManager.Instance.CharacterSheet_readonly;
        PlayerHp = characterSheet.m_data[0].hp;

    }
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = PlayerHp / 100f;
    }
}
