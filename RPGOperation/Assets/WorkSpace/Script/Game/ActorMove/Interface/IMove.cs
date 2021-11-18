using UnityEngine;

namespace Game
{
    //移動機能提供インターフェイス
    interface IMove
    {
        //移動ターゲット
        GameObject targetObj { get; set; }

        //カメラ
        Camera targetCamera { get; }

        //移動関数
        void Move(GameObject targetObj,Camera camera,float h,float v);
    }
}