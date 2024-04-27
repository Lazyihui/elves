using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;
    public int id;
    public float moveSpeed;
    public float hp;

    public float maxhp;

    public RoleEntity() { }

    public void Ctor() { }

    public void Move(Vector3 MoveAxis, float dt) {
        Move(MoveAxis, 10, dt);
    }
    public void Move(Vector3 MoveAxis, float moveSpeed, float dt) {
        var velo = rb.velocity;
        velo.x = MoveAxis.x * moveSpeed;
        rb.velocity = velo;
    }
}