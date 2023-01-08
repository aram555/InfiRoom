using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [Header("Camera Options")]
    public Transform Player;
    public Vector3 Offset;
    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if(Input.touchCount > 0) {
            Touch rotate = Input.GetTouch(0);
            if(rotate.phase == TouchPhase.Moved) {
                transform.Rotate(0, rotate.deltaPosition.x, 0);
            }
        }
    }
    void LateUpdate()
    {
        transform.position = Player.position;
    }
}
