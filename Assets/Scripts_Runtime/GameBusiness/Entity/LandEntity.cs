using System;
using UnityEngine;

public class LandEntity : MonoBehaviour {

    [SerializeField] public Rigidbody2D rb;

    public int typeID;

    public int id;

    public bool isEraser;

    public LandEntity() {

    }

    public void Ctor() { }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
     }
}