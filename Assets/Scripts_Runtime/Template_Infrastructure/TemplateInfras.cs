using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateInfras {

    public static void Load(TemplateContext ctx) {
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Book";
            var ptr = Addressables.LoadAssetsAsync<BookTM>(labelReference, null);

            IList<BookTM> list = ptr.WaitForCompletion();
            for(int i = 0; i < list.Count; i++) {
                BookTM book = list[i];
                ctx.books.Add(book.id, book);
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
