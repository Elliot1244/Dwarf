using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoctorScript : MonoBehaviour, ISpeakable
{
    /*    [SerializeField] Canvas _canva;
       [SerializeField] TextMeshProUGUI _dialText;*/

    bool _spoken = false;

    public string GetName()
    {
        return "Doctor";
    }

    public string Speak()
    {
        if (_spoken == false)
        {
            StartCoroutine(DisableDialogText());
            return "Bonjour ! Votre ami est dans un sale état, désolé mais j'ai besoin d'espace pour bien le soigner. J'ai entendu dire que le chef vous demande.";
        }
        else
        {
            return "S'il vous plait, laissez moi m'occuper des blessures de votre compagnon.";
        }
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null && _spoken == false)
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Bonjour ! Votre ami est dans un sale état, désolé mais j'ai besoin d'espace pour bien le soigner. J'ai entendu dire que le chef vous demande.";
            StartCoroutine(DisableDialogText());
            _spoken = true;
        }
        else
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "S'il vous plait, laissez moi m'occuper des blessures de votre compagnon.";
            StartCoroutine(DisableDialogText());
        }
    }*/

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        //_canva.gameObject.SetActive(false);
        _spoken = true;
        yield break;
    }
}
