using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Stab", menuName = "Template/StabTM")]
public class StabTM : ScriptableObject {
    public int typeID;

    public int id;

    public Vector2 pos;

    public StabTM() { }

    public void Ctor() { }

}