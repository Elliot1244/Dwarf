using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarchantScript : MonoBehaviour, ISpeakable
{
    
    /*    [SerializeField] Canvas _canva;
        [SerializeField] TextMeshProUGUI _dialText;*/

    bool _spoken;

    public string GetName()
    {
        return "Marchande";
    }

    public string Speak()
    {
        
        if (!_spoken)
        {
            
            _spoken = true;
            return "Test marchande";

        }
        else
        {
            return "Test marchande 2";
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
    }

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        yield break;
    }*/
}
