using System;
using UnityEngine;
using UnityEngine.UI;

public class MstEntity : MonoBehaviour {

    [SerializeField] SpriteRenderer spriteRenderer;


    public int typeID;

    public int id;

    public float moveSpeed;

    public bool isMoveRight;

    public MstEntity() { }

    public void Ctor() { }

    public void Init(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }

    public void Move( float right, float left,float dt) {

        if (isMoveRight) {
            transform.Translate(Vector2.right * moveSpeed * dt);
            if (transform.position.x > right) {
                isMoveRight = false;
            }
        } else {
            transform.Translate(Vector2.left * moveSpeed * dt);
            if (transform.position.x < left) {
                isMoveRight = true;
            }


        }

    }
}