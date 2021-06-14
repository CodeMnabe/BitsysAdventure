using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpenFlowerMenu : MonoBehaviour
{
    [SerializeField] private GameObject stopPlayer;
    [SerializeField] private GameObject flowerChangerUI;
    [SerializeField] private CinemachineFreeLook thirdPersonCamera;
    public void OpenMenu()
    {
        flowerChangerUI.SetActive(true);
        stopPlayer.GetComponent<ThirdPersonMovement>().isTalkingToSomeone = true;
        thirdPersonCamera.m_XAxis.m_MaxSpeed = 0;
        thirdPersonCamera.m_YAxis.m_MaxSpeed = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void NormalizeCamera(){
        thirdPersonCamera.m_XAxis.m_MaxSpeed = 400;
        thirdPersonCamera.m_YAxis.m_MaxSpeed = 2;
    }
}
