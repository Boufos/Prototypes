using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordTrigger : MonoBehaviour
{
     [SerializeField]private Animator textAnimation;
      public GameObject sword;


    private void OnTriggerEnter(Collider other)
    {
        textAnimation.SetTrigger("Trig");
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            Destroy(sword);
            textAnimation.SetTrigger("Trig");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        textAnimation.SetTrigger("Trig");
    }

   
}
