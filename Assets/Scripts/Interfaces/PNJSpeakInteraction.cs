using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PNJSpeakInteraction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _dialText;
    [SerializeField] Canvas _canva;
    [SerializeField] Animator _animator;
    [SerializeField] int _animation;


    private void Reset()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _animation = Animator.StringToHash("isNear");

    }

    private void Update()
    {

        Debug.DrawRay(transform.position, transform.forward * 2, Color.yellow);
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 2f))
        {
            if (hit.collider.TryGetComponent<ISpeakable>(out ISpeakable speakablePNJ))
            {
                bool _isWalking = _animator.GetBool(_animation);
                _animator.SetBool(_animation, true);
                _canva.gameObject.SetActive(true);
                speakablePNJ.GetName();
                _dialText.text = speakablePNJ.Speak();
                StartCoroutine(DisableDialogText());
            }
            else
            {
                //_canva.gameObject.SetActive(false);
                _animator.SetBool(_animation, false);
            }
        }
        else
        {
            //_canva.gameObject.SetActive(false);
            _animator.SetBool(_animation, false);
        }
    }

    IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        yield break;
    }
}
