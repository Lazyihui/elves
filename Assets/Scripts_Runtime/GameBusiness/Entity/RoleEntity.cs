using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;

    [SerializeField] public Animator animator;

    public RoleFSMStatus fsmStatus;

    public bool idle_isEntering;

    public bool die_isEntering;
    public float die_maintainTime;

    public int id;
    public float moveSpeed;
    public float hp;

    public float maxhp;

    public RoleEntity() { }

    public void Ctor() { }

    public void Move(Vector2 MoveAxis, float dt) {
        Move(MoveAxis, 10, dt);
    }
    public void Move(Vector2 MoveAxis, float moveSpeed, float dt) {
        var velo = rb.velocity;
        velo.x = MoveAxis.x * moveSpeed;
        rb.velocity = velo;
    }

    public void Enter_Idle() {
        fsmStatus = RoleFSMStatus.Idle;
        idle_isEntering = true;
    }

    public void Enter_Die(float die_maintainTime) {
        fsmStatus = RoleFSMStatus.Die;
        die_isEntering = true;
        this.die_maintainTime = die_maintainTime;
    }

}