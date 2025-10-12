using UnityEngine;

// Unityのライフサイクルを使うクラス
// 具体的な実装を持たず、他のクラスのメソッドを使うだけ
public class InputView : MonoBehaviour
{
    // MessageSenderという型のmessageSenderの宣言、インスペクターで参照を設定する
    [SerializeField]
    private MessageSender messageSender;
    
    // ゲームの再生を始めたときに呼ばれるUnityのライフサイクル
    void Start()
    {
        //messageSenderのGreed()というメソッドを呼び出している
        messageSender.Greed();
    }

    //毎フレーム呼び出されるUnityのライフサイクル
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            messageSender.Greed2();
        }
    }
}
