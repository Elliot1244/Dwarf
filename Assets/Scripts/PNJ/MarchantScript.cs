using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarchantScript : MonoBehaviour, ISpeakable
{
    
    /*    [SerializeField] Canvas _canva;
        [SerializeField] TextMeshProUGUI _dialText;*/

    public string GetName()
    {
        return "Marchande";
    }

    public string Speak()
    {
        if(HeldaScript.Instance._spoken == true )
        {
            Debug.Log("Tu lui as parlé");
        }
        else
        {
            Debug.Log("Va lui parler");
        }
        return "Désolé voyageur, les affaires sont aux plus mal et je n'ai rien à te vendre";
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
