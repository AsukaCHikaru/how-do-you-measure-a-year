using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateHourItemPosition : MonoBehaviour
{
    //void OnDrawGizmosSelected(){
  void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(5.7735026919f, 11, 0));
        Gizmos.DrawLine(transform.position, new Vector3(-5.7735026919f, 11, 0));
        Gizmos.DrawLine(transform.position, new Vector3(5.7735026919f, -9, 0));
        Gizmos.DrawLine(transform.position, new Vector3(-5.7735026919f, -9, 0));
    }
}
