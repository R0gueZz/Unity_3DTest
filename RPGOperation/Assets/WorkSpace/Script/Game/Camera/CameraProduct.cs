using UnityEditor;
using UnityEngine;

namespace Game
{
    public class CameraProduct : MonoBehaviour
    {
        [SerializeReference]
        //“ü—Í
        IInput _input;

        [SerializeReference]
        //ƒJƒƒ‰‹@”\
        ICamera _camera;

#if UNITY_EDITOR
        internal IInput Input { set => _input = value; }
        internal ICamera Camera { set => _camera = value; }
#endif

        void LateUpdate()
        {
            _camera.CameraSystem(_camera.targetObj, _input.Horizontal, _input.Vertical);
        }
    }

#if UNITY_EDITOR
    public static class CameraMenu
    {
        [MenuItem("CONTEXT/CameraProduct/CameraManager")]
        public static void CameraSet(MenuCommand command)
        {
            CameraProduct product = (CameraProduct)command.context;
            product.Camera = new CameraManager();
        }

        [MenuItem("CONTEXT/CameraProduct/AxisInput")]
        public static void CameraInputSet(MenuCommand command)
        {
            CameraProduct product = (CameraProduct)command.context;
            product.Input = new AxisInput();
        }
    }
#endif
}
