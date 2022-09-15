using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcolyteScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null)
        {
            Debug.Log("Test");
        }
    }
}
