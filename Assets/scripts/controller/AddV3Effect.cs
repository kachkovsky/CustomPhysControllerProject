using UnityEngine;

[System.Serializable]
public class AddV3Effect {

    public virtual Vector3 AddEffect(Vector3 effect, float deltaTime) {
        return effect;
    }
}