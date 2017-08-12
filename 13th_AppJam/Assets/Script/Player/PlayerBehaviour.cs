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


    public void Move(Vector3 direction)
    {
        playerMove.Move(direction, transform, rigidbody);
    }
}