using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Ruler", menuName = "Template/ruler")]


public class RulerTM : ScriptableObject {

    public int typeID;

    public int id;

    public float maintainterTimer;

    public float maintain;


    public Vector2 pos;


}