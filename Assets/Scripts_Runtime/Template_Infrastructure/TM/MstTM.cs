using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Mst", menuName = "Template/Mst")]
public class MstTM : ScriptableObject {

    public int typeID;
    public int id;

    public Vector2 pos;
    public Sprite sprite;


}