using System;
using System.Collections.Generic;



public class GoldRepository {

    Dictionary<int, GoldEntity> all;

    GoldEntity[] temArray;

    public GoldRepository() {
        all = new Dictionary<int, GoldEntity>();
        temArray = new GoldEntity[1000];
    }

    public void Add(GoldEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(GoldEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out GoldEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new GoldEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<GoldEntity> Action<>
    public GoldEntity Find(Predicate<GoldEntity> predicate) {
        foreach (GoldEntity gold in all.Values) {
            bool isMatch = predicate(gold);

            if (isMatch) {
                return gold;
            }
        }
        return null;
    }

}
