using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChiefVillageScript : MonoBehaviour, ISpeakable
{

    public static ChiefVillageScript Instance { get; private set; }


    /*[SerializeField] Canvas _canva;
    [SerializeField] TextMeshProUGUI _dialText;*/
    

    bool _spoken = false;
    public bool _getWeapon = false;


    private void Awake()
    {
        //Vérifie qu'il n'y ait qu'une instance sinon destruction
        if (Instance != null)
        {
            Debug.LogError("More than one instance" + transform + " - " + Instance);
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }


    public string GetName()
    {
        return "Chef du village";
    }

    public string Speak()
    {
        if (_spoken == false)
        {
            StartCoroutine(DisableDialogText());
            return "Vous voilà !Encore merci à toi et ton équipe, Gromnir !Sans ce ravitaillement, nous ne survivions pas longtemps dans le désert...Pas depuis la grande tempête.";
        }
        else
        {
            return "Si tu souhaites repartir, récupère d'abord ton arme, je veux que tu puisses te défendre si tu croises à nouveau des bandits !";
        }
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null && _spoken == false)
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Vous voilà ! Encore merci à toi et ton équipe, Gromnir ! Sans ce ravitaillement, nous ne survivions pas longtemps dans le désert...Du moins pas depuis la grande tempête. ";
            StartCoroutine(DisableDialogText());
            _spoken = true;
        }
        else
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Si tu souhaites repartir, je vais te donner une arme, je veux que tu puisses te défendre si tu croises à nouveau des bandits !";
            StartCoroutine(DisableDialogText());
        }
    }*/

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        //_canva.gameObject.SetActive(false);
        _spoken = true;
        _getWeapon = true;
        yield break;
    }
}
