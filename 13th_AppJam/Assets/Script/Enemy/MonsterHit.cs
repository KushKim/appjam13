using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {

    private Animator MonsterAnimator;

    

    // Use this for initialization
    void Start()
    {
        MonsterAnimator = transform.GetComponent<Animator>();
    }

    void Hit()
    {
        MonsterAnimator.SetTrigger("Hit");

        
    }
}
