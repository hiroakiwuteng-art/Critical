using UnityEngine;

// StartやUpdateなどのUntiyライフサイクルを使わないクラス
//メソッドだけを持つ
public class MessageSender : MonoBehaviour
{
    public void Greed()
    {
        Debug.Log("Hello World");
    }

    public void Greed2()
    {
        Debug.Log("Hello Space");
    }
}
