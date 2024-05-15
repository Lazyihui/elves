using System;
using UnityEngine;

public class GoldEntity : MonoBehaviour {

    [SerializeField] SpriteRenderer spriteRenderer;

    public int typeID;
    public int id;

    public bool isWin;
    public bool ishp;


    public GoldEntity() { }
    public void Ctor() { }
    public void Init(Sprite sprite){
        spriteRenderer.sprite = sprite;
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
}