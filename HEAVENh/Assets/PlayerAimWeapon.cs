using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour{

    private Transform aimTransform;

    private void Awake() {
        aimTransform = transform.Find("aim");
    }

    private void Update()  {
        


    }

}
