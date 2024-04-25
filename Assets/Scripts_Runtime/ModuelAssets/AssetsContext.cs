using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class AssetsContext {

    public Dictionary<string, GameObject> panels;

    public AsyncOperationHandle panelsPtr;

    public AssetsContext() {
        panels = new Dictionary<string, GameObject>();
    }
    public bool TryGetPanel( string name, out GameObject panel) {
        return panels.TryGetValue(name, out panel);
    }
}