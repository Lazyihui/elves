using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D  rb;
    public int id;
    public float moveSpeed;
    public float hp;

    public float maxhp;

    public RoleEntity() { }

    public void Ctor() { }

    public void Move(Vector3 MoveAxis, float dt) {
        Move(MoveAxis, this.moveSpeed, dt);
    }
    public void Move(Vector3 MoveAxis, float moveSpeed, float dt) {
        // rb.MovePosition(rb.position + MoveAxis * dt);
        Vector2 velo = rb.velocity;
        Vector2 moveDir = new Vector2(MoveAxis.x, MoveAxis.y);
        moveDir.Normalize();
        velo = moveDir * moveSpeed;
        rb.velocity = velo;
    }
}