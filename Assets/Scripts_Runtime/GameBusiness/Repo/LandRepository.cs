using System;
using System.Collections.Generic;



public class LandRepository {

    Dictionary<int, LandEntity> all;

    LandEntity[] temArray;

    public LandRepository() {
        all = new Dictionary<int, LandEntity>();
        temArray = new LandEntity[1000];
    }

    public void Add(LandEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(LandEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out LandEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new LandEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<LandEntity> Action<>
    public LandEntity Find(Predicate<LandEntity> predicate) {
        foreach (LandEntity land in all.Values) {
            bool isMatch = predicate(land);

            if (isMatch) {
                return land;
            }
        }
        return null;
    }

}
