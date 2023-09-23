using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    public float amplitude = 0.25f;
    public float frequency = 0.5f;
    public Vector3 posOrigin = new Vector3();
    public Vector3 tempPos = new Vector3();
    public Vector3 rotation = new Vector3(0, 30f, 0);
    void Start()
    {
        posOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOrigin;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
        transform.Rotate(rotation * Time.deltaTime);
    }
}
