using System;
using UnityEngine;

public class MstEntity : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;

    public int typeID;

    public int id;

    public float moveSpeed;

    public MstEntity() { }

    public void Ctor() { }

    public void Move() { 
    }

    //    public void Move(Vector2 MoveAxis, float moveSpeed, float dt) {
    //     var velo = rb.velocity;
    //     velo.x = MoveAxis.x * moveSpeed;
    //     rb.velocity = velo;
    //     if (MoveAxis.x > 0) {
    //         this.transform.localScale = new Vector3(1, 1, 1);
    //     } else if (MoveAxis.x < 0) {
    //         this.transform.localScale = new Vector3(-1, 1, 1);
    //     }
    // }

}