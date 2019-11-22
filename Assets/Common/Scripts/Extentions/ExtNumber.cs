using UnityEngine;

public static class ExtNumber {

    public static float LowerBorder(this float value, float border) {
        return value = (value < border) ? border : value;
    }
    public static int modulo(this int x, int y) {
        return (x % y + y) % y;
    }

}