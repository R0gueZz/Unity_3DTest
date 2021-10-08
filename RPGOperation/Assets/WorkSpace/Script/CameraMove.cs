using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float xAngle, yAngle;
    [SerializeField]
    float xsensi, ysensi;
    [SerializeField]
    float angleMin, angleMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        CameraSystem();
    }

    void CameraSystem()
    {
        xAngle += Input.GetAxis("Horizontal2") * xsensi;
        yAngle += Input.GetAxis("Vertical2") * ysensi;

        yAngle = Mathf.Clamp(yAngle,angleMin,angleMax);
        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }
}
