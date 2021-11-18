using UnityEngine;
using UnityEditor;


namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    class Move : MonoBehaviour 
    {
        //ˆÚ“®‹@”\
        [SerializeReference]
        IMove _move;

        //“ü—Í
        [SerializeReference]
        IInput _input;

#if UNITY_EDITOR
        internal IInput input { set => _input = value; }
        internal IMove move { set => _move = value; }
#endif

        void Start()
        {
            _move.targetObj = this.gameObject;
        }

        void Update()
        {
            _move.Move(_move.targetObj,_move.targetCamera,_input.Horizontal, _input.Vertical);
        }
    }


#if UNITY_EDITOR
    public static class MoveMenu
    {

        [MenuItem("CONTEXT/Move/VelocityMove")]
        public static void VelocityMoveSet(MenuCommand command)
        {
            Move product = (Move)command.context;
            product.move = new VelocityMove();
        }

        [MenuItem("CONTEXT/Move/AxisInput")]
        public static void AxisInputSet(MenuCommand command)
        {
            Move product = (Move)command.context;
            product.input = new AxisInput();
        }
    }
#endif

}