using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    class VelocityMove : IMove
    {
        Rigidbody _rb;

        //�ړ����x
        [SerializeField]
        float _speed = 3f;

        //���񑬓x
        [SerializeField]
        float _smooth;

        //�J����
        [SerializeField]
        Camera _camera;
        
        //�J�����Ώ�
        public Camera targetCamera => _camera;

        //�Ώ�
        [SerializeField]
        public GameObject _target;

        //�ړ��Ώ�
        public GameObject targetObj
        {
            get => _target;
            set => _rb = value.GetComponent<Rigidbody>();
        }

        //�ړ��֐�
        public void Move(GameObject t,Camera c,float h,float v)
        {
            Vector3 cameraForward = Vector3.Scale(c.transform.forward, new Vector3(1, 0, 1));
            Vector3 moveForward = cameraForward * v + c.transform.right * h;

            if (moveForward.sqrMagnitude > 0.1f)
            {
                //�ړ�
                _rb.velocity = moveForward.normalized * _speed + new Vector3(0, _rb.velocity.y, 0);

                //����
                Quaternion rotation = Quaternion.LookRotation(moveForward);
                t.transform.rotation = Quaternion.Lerp(t.transform.rotation, rotation, Time.deltaTime * _smooth);
            }
        }
    }
}


