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
    Camera cam;
    [SerializeField]
    float m_Speed;
    [SerializeField]
    float rollPower;
    [SerializeField]
    float smooth;
    [SerializeField]
    float lerpDuration;

    float lerpProb;
    float horizontal, vertical;

    bool isRoll = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !isRoll)
        {
            Rolling();
        }
    }

    private void FixedUpdate()
    {
        if (!isRoll)
        {
            Move();
        }
    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * vertical + cam.transform.right * horizontal;

        float value = Mathf.Lerp(moveForward.magnitude, 1, lerpProb);

        if (moveForward.sqrMagnitude > 0.1f)
        {
            lerpProb += Time.deltaTime / lerpDuration;
            lerpProb = Mathf.Clamp01(lerpProb);
            rb.velocity = moveForward.normalized * m_Speed * value + new Vector3(0, rb.velocity.y, 0);
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

    void Rolling()
    {
        anim.SetBool("Roll", true);
        rb.velocity = Vector3.zero;
        Vector3 rollVec = gameObject.transform.rotation * new Vector3(0, 0, rollPower);
        rb.AddForce(rollVec, ForceMode.Impulse);
    }

    //--------------//
    //AnimationEvent//
    //--------------//
    void roll_End()
    {
        anim.SetBool("Roll", false);
        isRoll = false;
    }
}
