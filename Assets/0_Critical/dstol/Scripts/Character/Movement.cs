using UnityEngine;
/*
 * 行動に関する変数、メソッド、は全部ここにある
 */
public class Movement : MonoBehaviour
{
    private float lateralMovement; //右左行動入力
    private bool jumpInput; //ジャンプ入力
    private bool jumpHeld; //ジャンプボタン長押ししてるか
    private bool jumpReleased; //ジャンプ入力が消えたらこれが一瞬だけTrueになる。長押しの高いジャンプのメソッドに使う
    private bool stepInput;

    [SerializeField] private Character owner;//どのキャラに繋がってる

    [SerializeField] private float speed; //右左行動の速さ
    [SerializeField] private float jumpPower; //ジャンプの最初速度
    [SerializeField] private float conservedVerticalMomentum; /* ０から１までにしてください
                                                               * ０なら、上向速度はどんなに高くても、ジャンプしたら普通のジャンプ速度になる。
                                                               * １だったら、新しい上向速度はジャンプ＋前の速度になる*/
    [SerializeField] private float stepDistance;
    [SerializeField] private float stepSpeed;
    private float stepInitialPosition;
    private bool stepping;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private bool grounded; //地面に立ってるか、ジャンプ回数を数えるに使う
    [SerializeField] private float groundedCheckDistance;　//groundedを調べるRaycastはどこまで進む
    [SerializeField] private LayerMask groundLayer; //地面のレーヤー、groundedのRaycastはこれしか触れない
    [SerializeField] private GameObject feet; //Raycastはどこから出す

    [SerializeField] private bool canJump; //ジャンプが可能か
    [SerializeField] private int maxJumps; //何回ジャンプを連続できるか
    [SerializeField] private int previousJumps; //今まで何回ジャンプした

    [SerializeField] private float fallSpeedModifier; //落ちる速度をこれで乗じる
    [SerializeField] private float terminalVelocity; //落ちる速度の限界

    [SerializeField] private float jumpReleaseModifier; //ジャンプ入力長押しやめたらこの変数で乗じる
    
    public void Move()
    {
        /*
         * 動く
         */
        Debug.Log("Step input: " + stepInput + "\nStepping: " + stepping);
        Debug.Log("Lateral Velocity: " + rb.linearVelocity.x);
        if (owner.Alive)
        {
            rb.linearVelocity = new Vector3(lateralMovement * speed, rb.linearVelocity.y, 0f);
            if(jumpInput)
            {
                Jump();
            }
            ReduceJumpSpeedOnRelease();
            if(stepInput && !stepping)
            {
                Step();
            }
            if(stepping)
            {
                ManageStep();
            }
            ManageJumps();
        }
        FallFast();
    }
    public void Jump()
    {
        /*
         * ジャンプする。
         * 先ずはジャンプできるかどうか確認する
         */
        if(canJump)
        {
            previousJumps++;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower + rb.linearVelocity.y * conservedVerticalMomentum, rb.linearVelocity.z);
        }
    }
    public float LateralMovement
    {
        /*
         * プレーヤーやNPCの入力は右左行動変えられるようにする
         */
        get { return lateralMovement; }
        set { lateralMovement = value; }
    }
    public bool Grounded()
    {
        /*
         * キャラが地面に触れてるか探索する
         */
        grounded = Physics.Raycast(feet.transform.position, Vector3.down, groundedCheckDistance, groundLayer) && rb.linearVelocity.y < jumpPower * 0.3f;
        return grounded;
    }
    public void ManageJumps()
    {
        /*
         * ジャンプの回数管理する
         */
        if(!Grounded() && previousJumps == 0)
        {
            previousJumps = 1;
        }
        if(Grounded())
        {
            previousJumps = 0;
        }
        if(previousJumps >= maxJumps)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }
    private void ReduceJumpSpeedOnRelease()
    {
        /*
         * ジャンプ入力の長押しやめたらジャンプの速度が低くなる
         */
        if (rb.linearVelocity.y > 0f && !jumpHeld && jumpReleased)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * jumpReleaseModifier, 0f);
            jumpReleased = false;
        }
    }
    private void FallFast()
    {
        /*
         * 落ちる速度を普通の重力より高くする
         */
        if (rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity = rb.linearVelocity + Vector3.down * fallSpeedModifier * fallSpeedModifier * Time.deltaTime;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -terminalVelocity, 0f), 0f);
        }
    }
    private void Step()
    {
        if(lateralMovement > 0f)
        {
            rb.linearVelocity += Vector3.right * stepSpeed;
        }
        if(lateralMovement <0f)
        {
            rb.linearVelocity += Vector3.left * stepSpeed;
        }
        stepping = true;
    }
    private void ManageStep()
    {
        if(stepping && Mathf.Abs(transform.position.x - stepInitialPosition) >= stepDistance)
        {
            rb.linearVelocity = Vector3.zero;
            stepping = false;
        }
        if(rb.linearVelocity.x == 0f)
        {
            stepping = false;
        }
    }
    public bool StepInput
    {
        set { stepInput = value; }
    }
    public bool JumpInput
    {
        /*
         * プレーヤーやNPCがジャンプできるようにする
         */
        get { return jumpInput; }
        set { jumpInput = value; }
    }
    public bool JumpHeld
    {
        set { jumpHeld = value; }
    }
    public bool JumpReleased
    {
        set { jumpReleased = value; }
    }
    public bool Stepping
    {
        set { stepping = value; }
    }
}
