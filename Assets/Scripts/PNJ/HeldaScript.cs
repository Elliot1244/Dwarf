using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldaScript : MonoBehaviour, ISpeakable
{

    public static HeldaScript Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _dialText;
    [SerializeField] Image _dialContainer;

    public bool _spoken = false;
    public bool _spokedTwice = false;


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
        return "Helda";
    }

    public string Speak()
    {
        if (_spoken == false)
        {
            _spoken = true;
            return "Ah, tu es réveillé Gromnir ! Malheureusement l'état de Dulmyr ne s'améliore pas... Il est entrain de se faire soigner à côté.";
        }
        else if(_spoken == true && _spokedTwice == false)
        {
            _spokedTwice = true;
            return "Gromnir est avec le guérisseur du village dans la tente médicale à côté.";
        }
        else
        {
            _dialContainer.gameObject.SetActive(false);
            _dialText.gameObject.SetActive(false);
            StartCoroutine(ResetDialog());
            return "";
        }
    }

    IEnumerator ResetDialog()
    {
        yield return new WaitForEndOfFrame();
        _spokedTwice = false;
        _spoken = false;
        yield break;
    }
}
