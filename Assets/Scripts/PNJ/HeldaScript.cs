using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldaScript : MonoBehaviour, ISpeakable
{
    /*    [SerializeField] Canvas _canva;
        [SerializeField] TextMeshProUGUI _dialText;*/

    bool _spoken;

    public string GetName()
    {
        return "Helda";
    }

    public string Speak()
    {
        if (!_spoken)
        {
            _spoken = true;
            return "Ah, tu es réveillé Gromnir ! Malheureusement l'état de Dulmyr ne s'améliore pas... Il est entrain de se faire soigner à côté.";
        }
        else
        {
            return "Gromnir est avec le guérisseur du village dans la tente médicale à côté.";
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null && _spoken == false)
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Ah, tu es réveillé Gromnir ! Malheureusement l'état de Dulmyr ne s'améliore pas... Il est entrain de se faire soigner à côté.";
            StartCoroutine(DisableDialogText());
            _spoken = true;
        }
        else
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Gromnir est avec le guérisseur du village dans la tente médicale à côté.";
            StartCoroutine(DisableDialogText());
        }
    }

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        yield break;
    }*/
}
