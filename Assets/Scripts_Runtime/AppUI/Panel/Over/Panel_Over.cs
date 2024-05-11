using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Over : MonoBehaviour {
    [SerializeField] Button ReStart_Btn;

    [SerializeField] Button over_Btn;

    public Action OnStartClickHandle;

    public Action OnOverClickHandle;


    public Panel_Over() { }

    public void Ctor() {
        ReStart_Btn.onClick.AddListener(() => {
            OnStartClickHandle.Invoke();
        });

        over_Btn.onClick.AddListener(() => {
            OnOverClickHandle.Invoke();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void close() {
        gameObject.SetActive(false);
    }

}