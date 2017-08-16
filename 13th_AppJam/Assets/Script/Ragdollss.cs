using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdollss : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(die());
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator die()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
