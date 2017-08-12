using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject Player;

    public NavMeshAgent navi;

    public float AttackRange;

    private Animator MonsterAnimator;

    // Use this for initialization
    void Start()
    {
        MonsterAnimator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        navi.SetDestination(Player.transform.position);

        AttackPlayer();
    }

    void AttackPlayer()
    {
        float distance = PlayerDistance();

        if (distance <= AttackRange)
        {
            MonsterAnimator.SetTrigger("Attack");
        }
    }

    float PlayerDistance()
    {
        return Vector3.Distance(Player.transform.position, transform.position);
    }
}
