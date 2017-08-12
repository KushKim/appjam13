using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {

    public GameObject Ragdoll;
    public GameObject Star;

    private Animator MonsterAnimator;
    private MonsterSheet monsterSheet;

    private CharacterSheet characterSheet;
    private CharacterData characterData;

    private WeaponSheet weaponSheet;

    
    public float Hp;

    // Use this for initialization
    void Start()
    {
        MonsterAnimator = transform.GetChild(0).transform.GetComponent<Animator>();
        monsterSheet = InGameManager.Instance.MonsterSheet_readonly;
        characterSheet = InGameManager.Instance.CharacterSheet_readonly;
        characterData = characterSheet.m_data[0];

        weaponSheet = InGameManager.Instance.WeaponSheet_readonly;


        Hp = monsterSheet.m_data[0].hp;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Hit();
        }
    }

    void Hit()
    {
        MonsterAnimator.SetTrigger("Hit");

        Hp -= PlayerDamage();

        if(Hp <= 0)
        {
            GameObject obj = Instantiate(Ragdoll);

            obj.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            obj.transform.rotation = transform.rotation;

            if(Random.Range(0,5) == 0)
            {
                GameObject starobj = Instantiate(Star);
                starobj.transform.position = transform.position;
            }

            Destroy(gameObject);
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
