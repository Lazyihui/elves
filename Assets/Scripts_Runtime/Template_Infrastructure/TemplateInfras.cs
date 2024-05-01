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

    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.bookPtr.IsValid()) {
            Addressables.Release(ctx.bookPtr);
        }
    }

}
