using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections.Generic;

[System.Serializable]
public class InspectorListHelperScript<T> {
    public List<InspectorListItem<T>> item = new List<InspectorListItem<T>>();


}

[System.Serializable]
public class InspectorListItem<T> {
    public T item;
}