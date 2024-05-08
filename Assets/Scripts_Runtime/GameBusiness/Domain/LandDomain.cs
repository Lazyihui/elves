using System;
using UnityEngine;

// public static class BookDomain {

//     public static BookEntity Spawn(GameContext ctx, int typeID,int id) {

//         bool has = ctx.templateContext.books.TryGetValue(id, out BookTM tm);

//         if (!has) {
//             Debug.LogError("没找到typeID对应的模板" + id);
//         }
//         ctx.assetsContext.TryGetEntity("Entity_Book", out GameObject prefab);
//         BookEntity book = GameObject.Instantiate(prefab).GetComponent<BookEntity>();

//         book.Ctor();
//         book.id = ctx.bookID++;
//         book.typeID = tm.typeID;
//         book.transform.position = tm.pos;
//         ctx.bookRepository.Add(book);
//         return book;
//     }
// }

public static class LandDomain{

    public static LandEntity Spawn(GameContext ctx, int typeID , int id){

        bool has = ctx.templateContext.lands.TryGetValue(id, out LandTM tm);
        if(!has){
            Debug.LogError("没找到typeID对应的模板" + id);
        }
        ctx.assetsContext.TryGetEntity("Entity_Land", out GameObject prefab);
        LandEntity land = GameObject.Instantiate(prefab).GetComponent<LandEntity>();
        land.Ctor();
        land.id = ctx.landID++;
        land.typeID = tm.typeID;
        land.transform.position = tm.pos;
        ctx.landRepository.Add(land);
        return land;
    }
}