using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIft_Script : MonoBehaviour
{
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        myAnimator.SetBool("LiftOpene", true);
        myAnimator.SetBool("LiftClose", false);
    }

    private void OnTriggerExit(Collider other)
    {
        myAnimator.SetBool("LiftOpene", false);
        myAnimator.SetBool("LiftClose", true);
    }
}
