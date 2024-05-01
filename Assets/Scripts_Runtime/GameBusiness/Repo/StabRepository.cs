using System;
using System.Collections.Generic;



public class StabRepository {

    Dictionary<int, StabEntity> all;

    StabEntity[] temArray;

    public StabRepository() {
        all = new Dictionary<int, StabEntity>();
        temArray = new StabEntity[1000];
    }

    public void Add(StabEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(StabEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out StabEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new StabEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<StabEntity> Action<>
    public StabEntity Find(Predicate<StabEntity> predicate) {
        foreach (StabEntity stab in all.Values) {
            bool isMatch = predicate(stab);

            if (isMatch) {
                return stab;
            }
        }
        return null;
    }

}
