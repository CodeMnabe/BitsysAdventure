using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform otherPortal;

    private void Update()
    {
        //Get the offset of the position from the player's camera to the portal its linked to
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        //Set the camera position to the camera's portal position plus the offset previously got
        transform.position = portal.position + playerOffsetFromPortal;

        //Get the angular difference between the portals
        float angularDiffBtwPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        //Get the rotational difference between the portals
        Quaternion portalRotationalDiff = Quaternion.AngleAxis(angularDiffBtwPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDiff * playerCamera.forward;
        //Set the rotation of the camera
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);


        //Alternative way of doing it
        /*
        Matrix4x4 m = portal.localToWorldMatrix * otherPortal.transform.worldToLocalMatrix * playerCamera.transform.localToWorldMatrix;
        transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);*/
    }
}
