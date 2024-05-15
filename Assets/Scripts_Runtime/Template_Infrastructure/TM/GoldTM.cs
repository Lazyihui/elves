using System;
using UnityEngine;

[CreateAssetMenu (fileName ="TM_Gold" , menuName = "Template/Gold")]
public class GoldTM : ScriptableObject { 


    public int typeID;
    public  int id;

    public Vector2 pos;

    public Sprite sprite;

    [Header("是否是胜利条件")]
    public bool isWin;
    public bool ishp;

}