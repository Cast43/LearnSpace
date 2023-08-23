using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject rotateObject;
    public Vector3 rotateTo;
    public float rotatonSpeed = 1;
    void Start()
    {

    }

    void Update()
    {
        rotateObject.transform.Rotate(rotateTo * rotatonSpeed * Time.deltaTime);
    }
}
