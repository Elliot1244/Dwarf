using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcolyteScript : MonoBehaviour
{
    [SerializeField] GameObject _player;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMouvement>() != null)
        {
            Debug.Log("Test ok");
        }
    }
}
