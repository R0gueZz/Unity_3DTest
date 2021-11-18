using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    class CameraManager : ICamera
    {
        //��]��
        float x_Axis, y_Axis;

        //�^�[�Q�b�g
        [SerializeField]
        GameObject cameraTarget;

        public GameObject targetObj => cameraTarget;

        //�J�������x
        [SerializeField]
        float x_Sensi, y_Sensi;

        //�J�����ő�p�x
        [SerializeField]
        float min_Angle, max_Angle;

        public void CameraSystem(GameObject cameraTarget,float h,float v)
        {
            x_Axis += h * x_Sensi;
            y_Axis += v * y_Sensi;
                
            y_Axis = Mathf.Clamp(y_Axis, min_Angle,max_Angle);
            cameraTarget.transform.rotation = Quaternion.Euler(y_Axis, x_Axis, 0);
        }
    }
}