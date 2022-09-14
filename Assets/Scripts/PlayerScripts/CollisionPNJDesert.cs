using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPNJDesert : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.GetComponent<AcolyteScript>() != null)
        {
            Debug.Log("Test");
        }
    }
}
