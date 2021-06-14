using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalPlayerDetection : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject firstPersonCamera;

    private void Awake() 
    {
        firstPersonCamera.GetComponent<CinemachineVirtualCamera>().Priority = thirdPersonCamera.GetComponent<CinemachineFreeLook>().Priority - 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ThirdPersonMovement>().SwitchState();
            firstPersonCamera.GetComponent<CinemachineVirtualCamera>().Priority = thirdPersonCamera.GetComponent<CinemachineFreeLook>().Priority + 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ThirdPersonMovement>().SwitchState();
            firstPersonCamera.GetComponent<CinemachineVirtualCamera>().Priority = thirdPersonCamera.GetComponent<CinemachineFreeLook>().Priority - 1;
        }
    }
}
