using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float x, y;
    [SerializeField]
    float xsensi, ysensi;
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
        x += Input.GetAxis("Horizontal2") * xsensi;
        y += Input.GetAxis("Vertical2") * ysensi;

        transform.rotation = Quaternion.Euler(y, x, 0);
    }
}
