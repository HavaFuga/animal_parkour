using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public float amplitude = 0.25f;
    public float frequency = 0.5f;
    public Vector3 posOrigin = new Vector3();
    public Vector3 tempPos = new Vector3();
    
    // Start is called before the first frame update
    void Start()
    {
        // posOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // tempPos = posOrigin;
        // tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        // transform.position = tempPos;
    }
}
