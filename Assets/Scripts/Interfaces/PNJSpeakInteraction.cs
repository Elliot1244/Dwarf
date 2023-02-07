using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PNJSpeakInteraction : MonoBehaviour
{
    public static PNJSpeakInteraction Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _dialText;
    [SerializeField] Image _dialContainer;
    [SerializeField] Image _interractImage;
    [SerializeField] Canvas _canva;
    [SerializeField] Animator _animator;
    [SerializeField] int _animation;


    public bool _canSpeak;

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
                _interractImage.gameObject.SetActive(true);
                /*_dialContainer.gameObject.SetActive(false);
                _dialText.gameObject.SetActive(false);*/
                _canSpeak = true;
                if (PlayerMouvement.Instance._isSpeaking == true)
                {
                    Debug.Log("On peut parler");
                    _dialContainer.gameObject.SetActive(true);
                    _dialText.gameObject.SetActive(true);
                    speakablePNJ.GetName();
                    _dialText.text = speakablePNJ.Speak();
                    PlayerMouvement.Instance._isSpeaking = false;
                    //StartCoroutine(DisableDialogText());
                }
            }
            else
            {
                _canva.gameObject.SetActive(false);
                PlayerMouvement.Instance._isSpeaking = false;
            }
        }
        else
        {
            _canva.gameObject.SetActive(false);
            PlayerMouvement.Instance._isSpeaking = false;
        }
    }

   /* IEnumerator DisableDialogText()
    {
        yield return new WaitForSeconds(3);
        _canva.gameObject.SetActive(false);
        yield break;
    }*/
}
