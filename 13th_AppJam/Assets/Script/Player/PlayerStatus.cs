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

    private float hp = 100f;
    private int star = 0;
 
    private PlayerDataContainer playerContainer;

    private CharacterSheet characterSheet;
    private CharacterData characterData;

    public GameObject Block;
    public GameObject ch;

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
        //playerContainer = InGameManager.Instance._PlayerDataContainer;

        //characterSheet = InGameManager.Instance.CharacterSheet_readonly;

        //for(int i = 0; i < characterSheet.m_data.Count; i++)
        //{
        //    if(characterSheet.m_data[i].name == playerContainer.CharacterName)
        //        characterData = characterSheet.m_data[i];
        //}

        Hp = 100f; // 나중에 고치자

        star = 0;
    }

    public void HitTT()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject obj = Instantiate(Block);
            obj.SetActive(true);
            obj.transform.position = ch.transform.position;
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-200, 200), Random.Range(100, 200), Random.Range(-200, 200)));
        }
    }
}