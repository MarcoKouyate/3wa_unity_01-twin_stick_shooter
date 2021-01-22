using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField] private float deadZone = 0f;

    private Vector3 offset;

    private void Update()
    {
        offset =  transform.position - playerTransform.position;

        if(offset.sqrMagnitude > deadZone * deadZone)
        {
            offset.Normalize(); 
            offset *= deadZone;

            Debug.Log("camera offset :" + offset);
            transform.position = playerTransform.position + offset;
            Debug.Log("camera transform :" + transform.position);
        }

    }
}
