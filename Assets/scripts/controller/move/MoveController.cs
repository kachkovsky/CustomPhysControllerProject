using UnityEngine;

[System.Serializable]
[AddComponentMenu("MoveController/MoveController")]
public class MoveController : MonoBehaviour {
    public virtual Vector3 CalcMovement() {
        return Vector3.zero;
    }
}
