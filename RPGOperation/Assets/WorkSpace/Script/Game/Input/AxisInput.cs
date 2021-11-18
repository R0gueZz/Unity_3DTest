using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    class AxisInput : IInput
    {
        //—˜—pƒL[
        [SerializeField]
        string _horizontalName = "Horizontal";
        [SerializeField]
        string _verticalName = "Vertical";

        //‰¡
        public float Horizontal => Input.GetAxis(_horizontalName);
        //c
        public float Vertical => Input.GetAxis(_verticalName);
    }
}