using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    [Header("Speed")] public float rotateSpeed = 100;

    [Header("Limit Rot")] 
    [SerializeField] private float minRot = -15f;
    [SerializeField] private float maxRot = 15f;

    private Transform _localTrans;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        transform.Rotate(moveX * Vector3.left * Time.deltaTime * rotateSpeed, Space.World);
        transform.Rotate(moveZ * Vector3.forward * Time.deltaTime * rotateSpeed, Space.World);

        Vector3 rotation = transform.localEulerAngles;
        //rotation.x = Mathf.Clamp(rotation.x, minRot, maxRot);

        Debug.Log(rotation.x);
        rotation.x = Mathf.Clamp(rotation.x, minRot, maxRot);
        rotation.y = Mathf.Clamp(rotation.y, -1, 1);
        rotation.z = Mathf.Clamp(rotation.z, minRot, maxRot);
        //transform.localRotation = Quaternion.Euler(currentRotation);
        //transform.localEulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
    }

    /*void LockedRotation()
    {
    }*/
}
}
