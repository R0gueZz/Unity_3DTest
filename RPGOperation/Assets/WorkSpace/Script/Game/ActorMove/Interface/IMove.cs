using UnityEngine;

namespace Game
{
    //�ړ��@�\�񋟃C���^�[�t�F�C�X
    interface IMove
    {
        //�ړ��^�[�Q�b�g
        GameObject targetObj { get; set; }

        //�J����
        Camera targetCamera { get; }

        //�ړ��֐�
        void Move(GameObject targetObj,Camera camera,float h,float v);
    }
}