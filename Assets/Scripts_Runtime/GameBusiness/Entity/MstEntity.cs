using System;
using UnityEngine;
using UnityEngine.UI;

public class MstEntity : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;

    [SerializeField] SpriteRenderer spriteRenderer;


    public int typeID;

    public int id;

    public float moveSpeed;

    public MstEntity() { }

    public void Ctor() { }

    public void Init(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }

    public void Move() {
    }

}