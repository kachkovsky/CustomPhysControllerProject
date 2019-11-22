using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[AddComponentMenu("MoveController/InputMoveController")]
class InputMoveController : MoveController {

    public override Vector3 CalcMovement() {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            x += -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            x += 1f;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            y += 1f;
        }
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical").LowerBorder(0) * 10;
        return new Vector3(x, y, 0);
    }
}
