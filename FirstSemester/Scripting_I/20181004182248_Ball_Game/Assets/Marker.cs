using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

 

    void OnTriggerEnter(Collider other ) {

        Ball b = other.GetComponent("Ball") as Ball;
        print("strength = " + b.strength);


        b.healthPoint -= 1;

        print(b.healthPoint);

    }
}
