using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingPlant : MonoBehaviour
{
    [SerializeField] private float timer;
    private IEnumerator coroutine;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerMask;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coroutine = StartTimer(timer, other);
            StartCoroutine(coroutine);
        }
        
    }

    private IEnumerator StartTimer(float time, Collider player)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(CheckForPlayer(player));
    }


    private IEnumerator CheckForPlayer(Collider player)
    {
        if (!myAnimator)
        {
            
        }
        else
        {
            Collider[] hitCollider = Physics.OverlapSphere(transform.position, radius, playerMask);
            foreach (Collider colliders in hitCollider)
            {
                myAnimator.SetBool("SomethingIsInside", true);
                yield return new WaitForSeconds(.1f);
                player.GetComponent<ThirdPersonMovement>().Die();
                myAnimator.SetBool("SomethingIsInside", false);
            }
        }        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
