using UnityEngine;

namespace Game
{
    interface ICamera
    {
        //ターゲット
        GameObject targetObj { get; }

        void CameraSystem(GameObject target,float h,float v);
    }
}