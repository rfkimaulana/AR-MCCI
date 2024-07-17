using System.Collections.Generic;
using UnityEngine;

public class smooth_movement : MonoBehaviour

{
    public GameObject ARCam; // Pastikan ini public
    private float x;
    private float y;
    private float z;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = ARCam.transform.position;
        x = x + ((pos.x - x) / 8);
        y = y + ((pos.y - y) / 8);
        z = z + ((pos.z - z) / 8);
        Vector3 cam = transform.position;
        cam.x = x;
        cam.y = y;
        cam.z = z;
        transform.position = cam;
    }
}
