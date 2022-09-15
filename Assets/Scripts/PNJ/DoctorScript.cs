using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoctorScript : MonoBehaviour
{
    [SerializeField] Canvas _canva;
    [SerializeField] TextMeshProUGUI _dialText;

    bool _spoken;

    private void Awake()
    {
        _spoken = false;
    }
    private void OnTriggerEnter(Collider other)
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
    }

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        yield break;
    }
}
