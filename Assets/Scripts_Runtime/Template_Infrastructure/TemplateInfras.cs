using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateInfras {

    //    foreach (var so in list) {
    //                     var tm = so.tm;
    //     ctx.Role_Add(tm);
    //                 }
    public static void Load(TemplateContext ctx) {
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Book";
            var ptr = Addressables.LoadAssetsAsync<BookTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.books.Add(go.id, go);
            }
            ctx.bookPtr = ptr;
        }

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Stab";
            var ptr = Addressables.LoadAssetsAsync<StabTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.stabs.Add(go.id, go);
            }
            ctx.stabPtr = ptr;
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Ruler";
            var ptr = Addressables.LoadAssetsAsync<RulerTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.rulers.Add(go.id, go);
            }
            ctx.rulerPtr = ptr;
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Land";
            var ptr = Addressables.LoadAssetsAsync<LandTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.lands.Add(go.id, go);
            }
            ctx.landPtr = ptr;

        }

    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.bookPtr.IsValid()) {
            Addressables.Release(ctx.bookPtr);
        }
        if (ctx.stabPtr.IsValid()) {
            Addressables.Release(ctx.stabPtr);
        }
        if (ctx.rulerPtr.IsValid()) {
            Addressables.Release(ctx.rulerPtr);
        }
        if (ctx.landPtr.IsValid()) {
            Addressables.Release(ctx.landPtr);
        }

    }

}
