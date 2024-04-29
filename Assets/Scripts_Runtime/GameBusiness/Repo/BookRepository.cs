using System;
using System.Collections.Generic;



public class BookRepository {

    Dictionary<int, BookEntity> all;

    BookEntity[] temArray;

    public BookRepository() {
        all = new Dictionary<int, BookEntity>();
        temArray = new BookEntity[1000];
    }

    public void Add(BookEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(BookEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out BookEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new BookEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<BookEntity> Action<>
    public BookEntity Find(Predicate<BookEntity> predicate) {
        foreach (BookEntity book in all.Values) {
            bool isMatch = predicate(book);

            if (isMatch) {
                return book;
            }
        }
        return null;
    }

}
