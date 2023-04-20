using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateHourItemPosition : MonoBehaviour
{
    //void OnDrawGizmosSelected(){
  void OnDrawGizmos() {
        Vector3 pos = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(-100, -100+pos.y, 0), new Vector3(100, 100+pos.y, 0));
        Gizmos.DrawLine(new Vector3(100, -100+pos.y, 0), new Vector3(-100, 100+pos.y, 0));

        

        Gizmos.DrawLine(pos, new Vector3(pos.x + Mathf.Tan(15 * (Mathf.PI / 180)) * 100, 100, 0));
        Gizmos.DrawLine(pos, new Vector3(pos.x + Mathf.Tan(15 * (Mathf.PI / 180)) * -100, 100, 0));
        Gizmos.DrawLine(pos, new Vector3(pos.x + Mathf.Tan(15 * (Mathf.PI / 180)) * -100, -100, 0));
        Gizmos.DrawLine(pos, new Vector3(pos.x + Mathf.Tan(15 * (Mathf.PI / 180)) * 100, -100, 0));

        Gizmos.DrawLine(pos, new Vector3(100, pos.y + Mathf.Tan(15 * (Mathf.PI / 180)) * 100, 0));
        Gizmos.DrawLine(pos, new Vector3(100, pos.y + Mathf.Tan(15 * (Mathf.PI / 180)) * -100, 0));
        Gizmos.DrawLine(pos, new Vector3(-100, pos.y + Mathf.Tan(15 * (Mathf.PI / 180)) * 100, 0));
        Gizmos.DrawLine(pos, new Vector3(-100, pos.y + Mathf.Tan(15 * (Mathf.PI / 180)) * -100, 0));
    }
}
