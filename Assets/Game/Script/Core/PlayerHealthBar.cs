using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public Camera cam;

    private void LateUpdate()
    {
      if(cam!=null)  transform.LookAt(cam.transform);
    }

}
