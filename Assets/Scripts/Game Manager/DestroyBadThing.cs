using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBadThing : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    [SerializeField]private GameObject turtle;
    
    public void Die()
    {
        Destroy(gameObject);
        Destroy(turtle);
    }
}
