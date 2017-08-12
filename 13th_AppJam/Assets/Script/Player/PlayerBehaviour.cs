using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform transform;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    private PlayerAttack playerAttack;

    [SerializeField]
    private PlayerAnimation playerAni;

    private PlayerState state;

    public PlayerAnimation PlayerAni { get { return playerAni; } }

    private void OnEnable()
    {
        state = PlayerState.Idle;
    }

    private void Awake()
    {
        state = PlayerState.Idle;
    }

    public void Attack()
    {
        playerAttack.Attack();

        playerAni.ChangeAni(PlayerState.Attack);
    }
    
    public void Move(Vector3 direction)
    {
        playerMove.Move(direction, transform, rigidbody);
    }
}