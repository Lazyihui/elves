using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class AssetsContext {

    public Dictionary<string, GameObject> panels;

    public Dictionary<string, GameObject> entities;

    public AsyncOperationHandle panelsPtr;

    public AsyncOperationHandle entityPtr;

    public AssetsContext() {
        panels = new Dictionary<string, GameObject>();
        entities = new Dictionary<string, GameObject>();
    }
    public bool TryGetPanel(string name, out GameObject panel) {
        return panels.TryGetValue(name, out panel);
    }
    public bool TryGetEntity(string name, out GameObject entity) {
        return entities.TryGetValue(name, out entity);
    }

}