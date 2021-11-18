using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    class VelocityMove : IMove
    {
        Rigidbody _rb;

        //移動速度
        [SerializeField]
        float _speed = 3f;

        //旋回速度
        [SerializeField]
        float _smooth;

        //カメラ
        [SerializeField]
        Camera _camera;
        
        //カメラ対象
        public Camera targetCamera => _camera;

        //対象
        [SerializeField]
        public GameObject _target;

        //移動対象
        public GameObject targetObj
        {
            get => _target;
            set => _rb = value.GetComponent<Rigidbody>();
        }

        //移動関数
        public void Move(GameObject t,Camera c,float h,float v)
        {
            Vector3 cameraForward = Vector3.Scale(c.transform.forward, new Vector3(1, 0, 1));
            Vector3 moveForward = cameraForward * v + c.transform.right * h;

            if (moveForward.sqrMagnitude > 0.1f)
            {
                //移動
                _rb.velocity = moveForward.normalized * _speed + new Vector3(0, _rb.velocity.y, 0);

                //旋回
                Quaternion rotation = Quaternion.LookRotation(moveForward);
                t.transform.rotation = Quaternion.Lerp(t.transform.rotation, rotation, Time.deltaTime * _smooth);
            }
        }
    }
}


