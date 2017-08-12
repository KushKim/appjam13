using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private HpBar hpBar;
    [SerializeField]
    private Text starText;

    private float hp;
    private int star;
 
    private PlayerDataContainer playerContainer;

    private CharacterSheet characterSheet;
    private CharacterData characterData;

    public float Hp
    {
        set
        {
            hp = value;
            hpBar.UpdateHpBar(hp);
        }
        get
        {
            return hp;
        }
    }
    public int Star
    {
        set
        {
            star = value;
            starText.text = star.ToString();
        }
        get
        {
            return star;
        }
    }

    private void Awake()
    {
        playerContainer = InGameManager.Instance._PlayerDataContainer;

        characterSheet = InGameManager.Instance.CharacterSheet_readonly;

        for(int i = 0; i < characterSheet.m_data.Count; i++)
        {
            if(characterSheet.m_data[i].name == playerContainer.CharacterName)
                characterData = characterSheet.m_data[i];
        }

        Hp = characterData.hp;

        star = 0;
    }
}