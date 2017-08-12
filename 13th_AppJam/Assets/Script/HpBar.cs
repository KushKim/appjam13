using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour {
    private CharacterSheet characterSheet;
    private CharacterData characterData;

    private Image image;

	// Use this for initialization
	void Start () {
        characterData = characterSheet.m_data[0];

    }
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = characterData.hp / 100;
    }
}
