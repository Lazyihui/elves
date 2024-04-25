using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : MonoBehaviour {

    [SerializeField] Button btn_Start;

    [SerializeField] Button btn_Exit;

    [SerializeField] Button btn_Setting;

    public Action OnStartClickHandle;

    public Action OnExitClickHandle;

    public Action OnSettingClickHandle;

    public void Ctor() {
        btn_Start.onClick.AddListener(() => {
            OnStartClickHandle.Invoke();
        });

        btn_Exit.onClick.AddListener(() => {
            OnExitClickHandle.Invoke();
        });

        btn_Setting.onClick.AddListener(() => {
            OnSettingClickHandle.Invoke();
        });

    }
    public void Show() {
        gameObject.SetActive(true);
    }
    public void Close() {
        gameObject.SetActive(false);
    }

}