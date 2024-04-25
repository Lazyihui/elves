using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class ModuleAssets {

    public static void Load(AssetsContext ctx) {

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "Panel";
            var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.panels.Add(go.name, go);
            }
            ctx.panelsPtr = ptr;
        }

    }

    public static void Unload(AssetsContext ctx) {
        if (ctx.panelsPtr.IsValid()) {
            Addressables.Release(ctx.panelsPtr);
        }
    }

  


}