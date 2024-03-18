using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class PlayerAim : MonoBehaviour{

    private Transform aimTransform;

    private void Awake() {
        aimTransform = transform.Find("aim");
    }

    private void Update()  {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(angle, 0, 0);
        Debug.Log(angle);
    }

}
