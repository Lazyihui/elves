using System;
using System.Collections.Generic;



public class MstRepository {

    Dictionary<int, MstEntity> all;

    MstEntity[] temArray;

    public MstRepository() {
        all = new Dictionary<int, MstEntity>();
        temArray = new MstEntity[1000];
    }

    public void Add(MstEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(MstEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out MstEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new MstEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<MstEntity> Action<>
    public MstEntity Find(Predicate<MstEntity> predicate) {
        foreach (MstEntity mst in all.Values) {
            bool isMatch = predicate(mst);

            if (isMatch) {
                return mst;
            }
        }
        return null;
    }

}
