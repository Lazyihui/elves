using System;
using UnityEngine;
public static class BookDomain {

    public static BookEntity Spawn(GameContext ctx, int typeID,int id) {

        bool has = ctx.templateContext.books.TryGetValue(id, out BookTM tm);

        if (!has) {
            Debug.LogError("没找到typeID对应的模板" + id);
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