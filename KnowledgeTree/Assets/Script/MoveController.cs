using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speedMove;
    public float rotationMove;
    private Vector3 moveVector;
    private CharacterController ch_controller;
    private Animator ch_animator;

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterMove();
    }
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        if (moveVector.x != 0 || moveVector.z != 0)
            ch_animator.SetBool("Move", true);
        else ch_animator.SetBool("Move", false);

        transform.Rotate(0, moveVector.x * rotationMove, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSpedd = speedMove * moveVector.z;
        ch_controller.SimpleMove(forward * curSpedd);
    }
}