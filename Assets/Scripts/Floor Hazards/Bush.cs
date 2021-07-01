using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            myAnimator.SetTrigger("PlayerHit");
        }
    }
}
