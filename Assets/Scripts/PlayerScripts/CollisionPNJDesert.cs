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
           _dialText.text = "Ah, tu es r�veill� ! Tu as eu de la veine d'�tre arriv� indemne...Ton co�quipier n'a pas eu cette chance. Il est entrain de se faire soigner � c�t�.";
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
