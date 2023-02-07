using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _entranceVillageCollider;
    [SerializeField] Canvas _canva;

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

    public void StartChiefQuest()
    {
        Debug.Log("Quête du chef acceptée");
        _canva.gameObject.SetActive(false);
    }

    public void DenieChiefQuest()
    {
        Debug.Log("Quête du chef refusée");
        _canva.gameObject.SetActive(false);
    }

    public void PostPoneChiefQuest()
    {
        Debug.Log("Une autre fois peut être...");
        _canva.gameObject.SetActive(false);
    }
}
