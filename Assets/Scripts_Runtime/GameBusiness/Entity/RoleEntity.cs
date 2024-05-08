using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;

    [SerializeField] public Animator animator;
    // 委托
    public Action<RoleEntity, Collision2D> OnCollisionEnterHandle;

    public Action<RoleEntity, Collision2D> OnCollisionStayHandle;

    public Action<RoleEntity, Collision2D> OnCollisionExitHandle;

    public Action<RoleEntity, Collider2D> OnTriggerEnterHandle;


    public RoleFSMStatus fsmStatus;

    public bool idle_isEntering;

    public bool die_isEntering;
    public bool isDie;

    public bool run_isEntering;
    // 跳跃
    public bool isGrounded;
    // 
    public float die_maintainTime;

    public int id;
    public float moveSpeed;
    public float hp;

    public float maxhp;

    // 用于记录
    public int rulerTypeID;
    public int rulerID;

    public bool isRoleHadNoStanding;

    public float fadeTimer;
    public float fade;

    public RoleEntity() { }

    public void Ctor() { }

    public void Move(Vector2 MoveAxis, float dt) {
        Move(MoveAxis, this.moveSpeed, dt);
    }
    public void Move(Vector2 MoveAxis, float moveSpeed, float dt) {
        var velo = rb.velocity;
        velo.x = MoveAxis.x * moveSpeed;
        rb.velocity = velo;
        if (MoveAxis.x > 0) {
            this.transform.localScale = new Vector3(1, 1, 1);
        } else if (MoveAxis.x < 0) {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump(bool isJumpingKeyDown) {
        if (isJumpingKeyDown && isGrounded) {
            Vector2 velo = rb.velocity;
            velo.y = 6;
            rb.velocity = velo;
            isGrounded = false;
        }
    }
    public void SetGround(bool isGround) {
        this.isGrounded = isGround;
    }

    // 和地面的检测

    public void Enter_Idle() {
        fsmStatus = RoleFSMStatus.Idle;
        idle_isEntering = true;
    }

    public void Enter_Die(float die_maintainTime) {
        fsmStatus = RoleFSMStatus.Die;
        die_isEntering = true;
        this.die_maintainTime = die_maintainTime;
    }

    public void Enter_Run() {
        fsmStatus = RoleFSMStatus.Run;
        run_isEntering = true;
    }
    // 赢碰撞F
    void OnCollisionEnter2D(Collision2D other) {
        OnCollisionEnterHandle.Invoke(this, other);
    }
    void OnCollisionStay2D(Collision2D other) {
        OnCollisionStayHandle.Invoke(this, other);
    }
    void OnCollisionExit2D(Collision2D other) {
        OnCollisionExitHandle.Invoke(this, other);
    }

    void OnTriggerEnter2D(Collider2D other) {
        OnTriggerEnterHandle.Invoke(this, other);
    }
    void OnTriggerStay2D(Collider2D other) {
    }
    void OnTriggerExit2D(Collider2D other) {
    }

}