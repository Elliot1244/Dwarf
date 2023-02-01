using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _entranceVillageCollider;

    // Start is called before the first frame update
    void Start()
    {
        _entranceVillageCollider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(ChiefVillageScript.Instance._getWeapon == true)
        {
            _entranceVillageCollider.SetActive(false);
        }
    }
}
