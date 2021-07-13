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
    private AudioSource m_AudioSource;
    public AudioClip[] step;
    private float nextActionTime = 0f;
    private float period = 0.3f;
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
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
{
            ch_animator.SetBool("Move", true);
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                PlayFootStepAudio();
            }
        }
        else ch_animator.SetBool("Move", false);

        transform.Rotate(0, moveVector.x * rotationMove, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSpedd = speedMove * moveVector.z;
        ch_controller.SimpleMove(forward * curSpedd);
    }
    private void PlayFootStepAudio()
    {
        int n = Random.Range(1, step.Length);
        m_AudioSource.clip = step[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        step[n] = step[0];
        step[0] = m_AudioSource.clip;
    }

}