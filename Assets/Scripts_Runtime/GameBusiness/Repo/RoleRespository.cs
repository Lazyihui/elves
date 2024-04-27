using System;
using System.Collections.Generic;


public class RoleRespository {

    Dictionary<int, RoleEntity> all;

    public RoleRespository() {
        all = new Dictionary<int, RoleEntity>();
    }

    public void Add(RoleEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(RoleEntity entity) {
        all.Remove(entity.id);
    }

    public bool TryGet(int id, out RoleEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<RoleEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }

}