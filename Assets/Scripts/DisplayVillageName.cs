using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayVillageName : MonoBehaviour
{
    [SerializeField] Canvas _canva;
    [SerializeField] TextMeshProUGUI _dialText;
    [SerializeField] GameObject _trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMouvement>() != null)
        {
            _canva.gameObject.SetActive(true);
            _dialText.text = "Village d'Ushar";
            StartCoroutine(DisableDialogText());
            
        }
    }

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        Destroy(_trigger);
        yield break;
    }
}

