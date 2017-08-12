using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject Player;

    public NavMeshAgent navi;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        navi.SetDestination(Player.transform.position);
    }
}
