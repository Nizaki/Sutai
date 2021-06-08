using UnityEngine;

public static class Ext
{
    public static Transform RemoveAllChild(this Transform transform)
    {
        foreach (Transform child in transform) Object.Destroy(child.gameObject);
        return transform;
    }
}