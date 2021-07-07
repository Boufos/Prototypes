using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordTrigger : MonoBehaviour
{
     [SerializeField]private Animator textAnimation;

    private void OnTriggerEnter(Collider other)
    {
        textAnimation.SetTrigger("Trig");
    }
}
