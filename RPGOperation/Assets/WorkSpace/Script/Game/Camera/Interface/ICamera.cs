using UnityEngine;

namespace Game
{
    interface ICamera
    {
        //�^�[�Q�b�g
        GameObject targetObj { get; }

        void CameraSystem(GameObject target,float h,float v);
    }
}