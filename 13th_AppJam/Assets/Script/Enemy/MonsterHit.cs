using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {

    private Animator MonsterAnimator;
    private MonsterSheet monsterSheet;

    private CharacterSheet characterSheet;
    private CharacterData characterData;

    private WeaponSheet weaponSheet;


    private float Hp;
    // Use this for initialization
    void Start()
    {
        MonsterAnimator = transform.GetComponent<Animator>();
        monsterSheet = InGameManager.Instance.MonsterSheet_readonly;
        characterSheet = InGameManager.Instance.CharacterSheet_readonly;
        characterData = characterSheet.m_data[0];

        weaponSheet = InGameManager.Instance.WeaponSheet_readonly;


        Hp = monsterSheet.m_data[0].hp;
    }

    void Hit()
    {
        MonsterAnimator.SetTrigger("Hit");

        Hp -= PlayerDamage();

        if(Hp < 0)
        {
            MonsterAnimator.SetTrigger("Dead");
        }
    }

    float PlayerDamage()
    {
        for (int i = 0; i < weaponSheet.m_data.Count; i++) 
        {
            if(characterData.WeaponName == weaponSheet.m_data[i].name)
            {
                return weaponSheet.m_data[i].demage;
            }
        }
        return 0;
    }
}
