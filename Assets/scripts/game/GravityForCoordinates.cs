using UnityEngine;
using System.Collections;

public class GravityForCoordinates : AddV3Effect {

    private float groundLevel = -1f;
    public override Vector3 AddEffect(Vector3 effect, float deltaTime) {
   
        return effect;
    }
}
