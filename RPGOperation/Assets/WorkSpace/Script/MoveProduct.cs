using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class MoveProduct : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    [SerializeField]
    float m_Speed;
    [SerializeField]
    float smooth;
    [SerializeField]
    float lerpDuration;

    float lerpProb;
    float horizontal, vertical;

    public static float CubicIn(float t, float totaltime, float min, float max)
    {
        max -= min;
        t /= totaltime;
        return max * t * t * t + min;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void MoveInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Move()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * vertical + Camera.main.transform.right * horizontal;

        float value = Mathf.Lerp(moveForward.magnitude, 1, lerpProb);

        if (moveForward.magnitude > 0.01f)
        {
            lerpProb += Time.deltaTime / lerpDuration;
            lerpProb = Mathf.Clamp01(lerpProb);
            rb.velocity = moveForward * m_Speed * lerpProb + new Vector3(0, rb.velocity.y, 0);
            Quaternion rotation = Quaternion.LookRotation(moveForward);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smooth);
            anim.SetFloat("Blend", value);
        }
        else
        {
            lerpProb -= Time.deltaTime / lerpDuration;
            lerpProb = Mathf.Clamp01(lerpProb);
            anim.SetFloat("Blend", value);
        }
    }
}
