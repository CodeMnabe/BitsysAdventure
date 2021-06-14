using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private Vector3 firstPosition;
    [SerializeField] private Vector3 secondPosition;
    [SerializeField] private Vector3 goToPosition;
    [SerializeField] private float speed;
    private float waitTime;
    [SerializeField] private float startingWaitTime;

    private void Start()
    {
        waitTime = startingWaitTime;
        firstPosition = this.transform.position;
        goToPosition = secondPosition;
    }

    private void LateUpdate()
    {
        if (waitTime <= 0.01f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, goToPosition, step);

            if (Vector3.Distance(transform.position, goToPosition) <= 0.01f)
            {
                if (goToPosition == secondPosition)
                {
                    goToPosition = firstPosition;
                    waitTime = startingWaitTime;
                    return;
                }
                if (goToPosition == firstPosition)
                {
                    goToPosition = secondPosition;
                    waitTime = startingWaitTime;
                    return;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

}
