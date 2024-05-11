using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_HeartInfo : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Transform HeartGroup;

    List<Image> elements;

    public void Ctor() {

        elements = new List<Image>();
    }

    public void Init(int hp) {
        int lastHp = elements.Count;
        int diff = hp - lastHp;

        if (diff < 0) {
            // 倒序遍历
            for (int i = -diff; i >= 0; i--) {
                if (elements.Count == 0) {
                    break;
                }
                Image ele = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                GameObject.Destroy(ele.gameObject);
            }

        } else if (diff > 0) {
            for (int i = 0; i < diff; i++) {
                Image ele = GameObject.Instantiate(elePrefab, HeartGroup);
                elements.Add(ele);
            }
        } else {
            // do nothing 
        }
    }
    public void Show() {
        gameObject.SetActive(true);
    }
    public void Close() {
        gameObject.SetActive(false);
    }

}

