using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TemplateContext {
    public Dictionary<int, BookTM> books;

    public AsyncOperationHandle bookPtr;

    public TemplateContext() {
        books = new Dictionary<int, BookTM>();
    }


}
