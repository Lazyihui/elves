using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TemplateContext {
    public Dictionary<int, BookTM> books;

    public Dictionary<int, StabTM> stabs;

    public Dictionary<int, RulerTM> rulers;

    public Dictionary<int, LandTM> lands;

    public Dictionary<int, MstTM> msts;

    public AsyncOperationHandle bookPtr;

    public AsyncOperationHandle stabPtr;

    public AsyncOperationHandle rulerPtr;
    public AsyncOperationHandle landPtr;
    public AsyncOperationHandle mstPtr;



    public TemplateContext() {
        books = new Dictionary<int, BookTM>();
        stabs = new Dictionary<int, StabTM>();
        rulers = new Dictionary<int, RulerTM>();
        lands = new Dictionary<int, LandTM>();
        msts = new Dictionary<int, MstTM>();
    }


}
