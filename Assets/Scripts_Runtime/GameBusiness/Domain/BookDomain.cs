using System;
using UnityEngine;
public static class BookDomain {

    public static BookEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

        bool has = ctx.assetsContext.TryGetEntity("Entity_Book", out GameObject prefab);
        if (!has) {
            Debug.LogError("Entity_Book ==null");
            return null;
        }

        BookEntity book = GameObject.Instantiate(prefab).GetComponent<BookEntity>();
        book.Ctor();
        book.id = ctx.bookID++;
        book.typeID = typeID;
        book.transform.position = pos;
        ctx.bookRepository.Add(book);
        return book;
    }
}