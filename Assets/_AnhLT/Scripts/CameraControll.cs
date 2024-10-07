using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
  public Camera cam;
    public Vector3 offset;
    public Quaternion rotate;
    public GameObject target;
    private void Update()
    {
        cam.transform.position = target.transform.position+offset;
        cam.transform.rotation= rotate;
    }
}
