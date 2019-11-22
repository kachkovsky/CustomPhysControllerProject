using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class ExtVector {
    private static readonly Vector3 ZERO_VECTOR = new Vector3();
    public static Vector2 ToV2(this Vector3 v) {
        return new Vector2(v.x, v.y);
    }
    public static Vector3 Zero() {
        return ZERO_VECTOR;
    }

    public static Vector3 WithZ(this Vector2 v, float z) {
        return new Vector3(
            v.x,
            v.y,
            z
        );
    }

    public static Vector3 Change(this Vector3 src, float? x = null, float? y = null, float? z = null) {
        return new Vector3(
            x == null ? src.x : x.Value,
            y == null ? src.y : y.Value,
            z == null ? src.z : z.Value);
    }

    public static Vector2 ChangeX(this Vector2 aVec, float aXValue) {
        aVec.x = aXValue;
        return aVec;
    }
    public static Vector2 ChangeY(this Vector2 aVec, float aYValue) {
        aVec.y = aYValue;
        return aVec;
    }

    public static Vector3 ChangeX(this Vector3 aVec, float aXValue) {
        aVec.x = aXValue;
        return aVec;
    }
    public static Vector3 ChangeY(this Vector3 aVec, float aYValue) {
        aVec.y = aYValue;
        return aVec;
    }
    public static Vector3 ChangeZ(this Vector3 aVec, float aZValue) {
        aVec.z = aZValue;
        return aVec;
    }

    public static Vector4 ChangeX(this Vector4 aVec, float aXValue) {
        aVec.x = aXValue;
        return aVec;
    }
    public static Vector4 ChangeY(this Vector4 aVec, float aYValue) {
        aVec.y = aYValue;
        return aVec;
    }
    public static Vector4 ChangeZ(this Vector4 aVec, float aZValue) {
        aVec.z = aZValue;
        return aVec;
    }
    public static Vector4 ChangeW(this Vector4 aVec, float aWValue) {
        aVec.w = aWValue;
        return aVec;
    }

    public static float RetrieveAdditionByIndexLimited(this Vector3 v, Vector3 add, int index, float minLimitVal, float maxLimitVal) {
        float result = v[index] + add[index];
        //nothing to add
        if ((v[index] <= minLimitVal && add[index] < 0f)
            || (v[index] >= maxLimitVal && add[index] > 0f)) {
            return 0f;
        } else if (result < minLimitVal) {
            return minLimitVal - v[index];
        } else if (result > maxLimitVal) {
            return maxLimitVal - v[index];
        } else {
            return add[index];
        }
    }
}