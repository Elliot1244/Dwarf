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
        //V�rifie qu'il n'y ait qu'une instance sinon destruction
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
            return "Vous voil� !Encore merci � toi et ton �quipe, Gromnir !Sans ce ravitaillement, nous ne survivions pas longtemps dans le d�sert...Pas depuis la grande temp�te.";
        }
        else
        {
            return "Si tu souhaites repartir, r�cup�re d'abord ton arme, je veux que tu puisses te d�fendre si tu croises � nouveau des bandits !";
        }
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null && _spoken == false)
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Vous voil� ! Encore merci � toi et ton �quipe, Gromnir ! Sans ce ravitaillement, nous ne survivions pas longtemps dans le d�sert...Du moins pas depuis la grande temp�te. ";
            StartCoroutine(DisableDialogText());
            _spoken = true;
        }
        else
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Si tu souhaites repartir, je vais te donner une arme, je veux que tu puisses te d�fendre si tu croises � nouveau des bandits !";
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
