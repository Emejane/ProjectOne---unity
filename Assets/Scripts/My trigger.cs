using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mytrigger : MonoBehaviour
{
   
   private void OntriggerEnter(Collider other){
    Debug.Log("Hit");           
   }
    private void OntriggerExit(Collider other){
        
    }
}
