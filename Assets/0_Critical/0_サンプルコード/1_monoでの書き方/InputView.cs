using UnityEngine;

// Unity�̃��C�t�T�C�N�����g���N���X
// ��̓I�Ȏ������������A���̃N���X�̃��\�b�h���g������
public class InputView : MonoBehaviour
{
    // MessageSender�Ƃ����^��messageSender�̐錾�A�C���X�y�N�^�[�ŎQ�Ƃ�ݒ肷��
    [SerializeField]
    private MessageSender messageSender;
    
    // �Q�[���̍Đ����n�߂��Ƃ��ɌĂ΂��Unity�̃��C�t�T�C�N��
    void Start()
    {
        //messageSender��Greed()�Ƃ������\�b�h���Ăяo���Ă���
        messageSender.Greed();
    }

    //���t���[���Ăяo�����Unity�̃��C�t�T�C�N��
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            messageSender.Greed2();
        }
    }
}
