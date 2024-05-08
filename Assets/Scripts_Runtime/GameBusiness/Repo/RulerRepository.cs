using System;
using System.Collections.Generic;



public class RulerRepository {

    Dictionary<int, RulerEntity> all;

    RulerEntity[] temArray;

    public RulerRepository() {
        all = new Dictionary<int, RulerEntity>();
        temArray = new RulerEntity[1000];
    }

    public void Add(RulerEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(RulerEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out RulerEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new RulerEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    public bool TryGet(int entityID, out RulerEntity entity) {
        return all.TryGetValue(entityID, out entity);
    }

    //委托 Predicate<RulerEntity> Action<>
    public RulerEntity Find(Predicate<RulerEntity> predicate) {
        foreach (RulerEntity ruler in all.Values) {
            bool isMatch = predicate(ruler);

            if (isMatch) {
                return ruler;
            }
        }
        return null;
    }

}
