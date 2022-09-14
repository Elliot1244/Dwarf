using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionPNJDesert : MonoBehaviour
{
    [SerializeField] Canvas _canva;
    [SerializeField] TextMeshProUGUI _dialText;
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.GetComponent<FirstDesertLadyScript>() != null)
        {
            _canva.gameObject.SetActive(true);
           _dialText.text = "Ah, tu es réveillé ! Tu as eu de la veine d'être arrivé indemne...Ton coéquipier n'a pas eu cette chance. Il est entrain de se faire soigner à côté.";
            StartCoroutine(DisableDialogText());
        }

        if (hit.gameObject.GetComponent<AcolyteScript>() != null)
        {
            Debug.Log("Test");
        }
    }

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        yield break;
    }
}
