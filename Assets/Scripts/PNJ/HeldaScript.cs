using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldaScript : MonoBehaviour, ISpeakable
{

    public static HeldaScript Instance { get; private set; }
    /*[SerializeField] Canvas _canva;
    [SerializeField] TextMeshProUGUI _dialText;*/

   public bool _spoken = false;


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
        return "Helda";
    }

    public string Speak()
    {
        if (_spoken == false)
        {
            StartCoroutine(DisableDialogText());
            return "Ah, tu es r�veill� Gromnir ! Malheureusement l'�tat de Dulmyr ne s'am�liore pas... Il est entrain de se faire soigner � c�t�.";
        }
        else
        {
            return "Gromnir est avec le gu�risseur du village dans la tente m�dicale � c�t�.";
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null && _spoken == false)
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Ah, tu es r�veill� Gromnir ! Malheureusement l'�tat de Dulmyr ne s'am�liore pas... Il est entrain de se faire soigner � c�t�.";
            StartCoroutine(DisableDialogText());
            _spoken = true;
        }
        else
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Gromnir est avec le gu�risseur du village dans la tente m�dicale � c�t�.";
            StartCoroutine(DisableDialogText());
        }
    }*/

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _spoken = true;
        //_canva.gameObject.SetActive(false);
        yield break;
    }
}
