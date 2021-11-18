using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    class CameraManager : ICamera
    {
        //回転軸
        float x_Axis, y_Axis;

        //ターゲット
        [SerializeField]
        GameObject cameraTarget;

        public GameObject targetObj => cameraTarget;

        //カメラ感度
        [SerializeField]
        float x_Sensi, y_Sensi;

        //カメラ最大角度
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