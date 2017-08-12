using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public NavMeshAgent navi;

    public PlayerStatus playerStatus;

    public float AttackRange;

    private Animator MonsterAnimator;

    private bool canAttack;

    private PlayerDataContainer playerdataContainer;

    // Use this for initialization
    void Start()
    {
        MonsterAnimator = transform.GetChild(0).GetComponent<Animator>();
        canAttack = true;

        playerdataContainer = InGameManager.Instance._PlayerDataContainer;
    }

    // Update is called once per frame
    void Update()
    {
        navi.SetDestination(playerdataContainer._Transform.position);

        AttackPlayer();
    }

    void AttackPlayer()
    {
        float distance = PlayerDistance();

        if (distance <= AttackRange && canAttack)
        {
            MonsterAnimator.SetTrigger("Attack");
            navi.speed = 0;
            Invoke("AttackCheck", 1f);
            canAttack = false;

        }
        else
            navi.speed = 3.5f;

    }

    float PlayerDistance()
    {
        return Vector3.Distance(playerdataContainer._Transform.position, transform.position);
    }

    void AttackCheck()
    {
        float distance = PlayerDistance();

        if (distance <= AttackRange)
        {
            playerStatus.Hp -= InGameManager.Instance.MonsterSheet_readonly.m_data[0].attack.demage;
        }
        Invoke("AttackDelay", 1f);
    }

    void AttackDelay()
    {
        canAttack = true;
    }
}
