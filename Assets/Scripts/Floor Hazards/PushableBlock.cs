using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    [SerializeField] private float pushPower;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (gameObject.GetComponent<FlowerPower>().weight == 2 && hit.gameObject.CompareTag("PushableObject"))
        {
            Rigidbody myRb = hit.gameObject.GetComponent<Rigidbody>();

            if (myRb == null || myRb.isKinematic)
            {
                return;
            }
            if (hit.moveDirection.y < -0.3f)
            {
                return;
            }

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            myRb.velocity = pushDir * pushPower;

            Debug.Log(myRb.name);
        }
    }
}
