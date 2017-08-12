using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject collObject;

    [SerializeField]
    private PlayerBehaviour playerBehaviour;

    private void Awake()
    {
        collObject.SetActive(false);
    }

    public void Attack()
    {
        StartCoroutine(_Attack());
    }

    private IEnumerator _Attack()
    {
        collObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        collObject.SetActive(false);

        playerBehaviour.PlayerAni.ChangeAni(PlayerState.Idle);
    }
}