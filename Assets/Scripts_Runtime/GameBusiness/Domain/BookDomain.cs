using System;
using UnityEngine;
public static class BookDomain {

    public static BookEntity Spawn(GameContext ctx, int typeID) {

        bool has = ctx.templateContext.books.TryGetValue(typeID, out BookTM tm);

        if (!has) {
            Debug.LogError("没找到typeID对应的模板" + typeID);
        }
        ctx.assetsContext.TryGetEntity("Entity_Book", out GameObject prefab);
        BookEntity book = GameObject.Instantiate(prefab).GetComponent<BookEntity>();

        book.Ctor();
        book.id = ctx.bookID++;
        book.typeID = tm.typeID;
        book.transform.position = tm.pos;
        ctx.bookRepository.Add(book);
        return book;
    }
}