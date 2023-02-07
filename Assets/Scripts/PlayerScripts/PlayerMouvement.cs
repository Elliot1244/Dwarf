using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NodeCanvas.DialogueTrees;
using TMPro;
using UnityEngine.UI;
public class PlayerMouvement : MonoBehaviour
{
    public static PlayerMouvement Instance { get; private set; }

    [SerializeField] InputActionReference _movement;
    [SerializeField] InputActionReference _sprint;
    [SerializeField] InputActionReference _draw;
    [SerializeField] InputActionReference _dialogInterraction;
    [SerializeField] Animator _animator;
    [SerializeField] CharacterController _controller;
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _axeWeapon;


    [SerializeField] TextMeshProUGUI _dialText;



    [SerializeField] int _isWalkingAnim;
    [SerializeField] float _speed;
    [SerializeField] float _gravity;

    //[SerializeField] DialogueTreeController dialogue;
    //[SerializeField] Transform _root;
    [SerializeField] Canvas _dialog;
    private float _vSpeed = 0;

    Vector3 _currentMovement;
    bool _movementPressed; 
    bool _isRunning;
    bool _hasDrawWeapon;
    bool _isUsingWeapon;
    public bool _isSpeaking;
    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }
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



        //Mouvement
        _movement.action.performed += StartMovement;
        _movement.action.canceled += StopMovement;

        //Sprint
        _sprint.action.started += SprintStarted;
        _sprint.action.performed += SprintUpdate;
        _sprint.action.canceled += SprintCanceled;

        //Attaque
        _draw.action.performed += DrawStarted;

        //Interraction/Dialogue
        _dialogInterraction.action.performed += DialogStarted;
    }

    private void DialogStarted(InputAction.CallbackContext obj)
    {
        if(PNJSpeakInteraction.Instance._canSpeak == true && _isSpeaking == false)
        {
            Debug.Log("Je peux parler");
            _isSpeaking = true;
            StartCoroutine(NotSpeaking());
        }
        else
        {
            Debug.Log("Il n'y a rien à faire");
            _isSpeaking = false;
        }
    }

    IEnumerator NotSpeaking()
    {
        yield return new WaitForEndOfFrame();
        _isSpeaking = false;
        yield break;
    }

    private void DrawStarted(InputAction.CallbackContext obj)
    {
        if(_hasDrawWeapon == false)
        {
            _animator.SetTrigger("drawWeapon");
            _axeWeapon.SetActive(true);
            Debug.Log("arme sortie !");
            _hasDrawWeapon = true;
            _isUsingWeapon = true;
            StartCoroutine(NoWeapon());
        }
        else
        {
            _animator.SetTrigger("sheathWeapon");
            Debug.Log("arme rangée");
            _hasDrawWeapon = false;
            _isUsingWeapon = false;
            StartCoroutine(NoWeapon());
            //dialogue.StartDialogue();
            //_dialog.gameObject.SetActive(true);
        }
    }

    IEnumerator NoWeapon()
    {
        yield return new WaitForSeconds(1.2f);
        _isUsingWeapon = false;
        yield break;
    }

    private void SprintCanceled(InputAction.CallbackContext obj)
    {
        _isRunning = false;
    }

    private void SprintUpdate(InputAction.CallbackContext obj)
    {
        _isRunning = true;
    }

    private void SprintStarted(InputAction.CallbackContext obj)
    {
        _isRunning = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _axeWeapon.SetActive(false);
        _isWalkingAnim = Animator.StringToHash("isWalking");
        _hasDrawWeapon = false;
        _isUsingWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("DrawWeapon") || _animator.GetCurrentAnimatorStateInfo(0).IsName("SheathWeapon"))
        {
            return;
        }
        else
        {
            Movement();
        }
        _animator.SetBool("isRunning", _isRunning);

        /*if(_isUsingWeapon == true)
        {
            return;
        }
        else
        {
            Movement();
        }*/
        
    }

    public void DestroyWeapon()
    {
        _axeWeapon.SetActive(false);
    }

    private void StartMovement(InputAction.CallbackContext obj)
    {
        _currentMovement = obj.ReadValue<Vector2>();
        _movementPressed = true;
    }

    private void StopMovement(InputAction.CallbackContext obj)
    {
        _currentMovement = Vector2.zero;
        _movementPressed = false;
    }

    void Movement()
    {
        bool _isWalking = _animator.GetBool(_isWalkingAnim);
        if (_movementPressed)
        {
            _animator.SetBool(_isWalkingAnim, true);
        }
        else
        {
            _animator.SetBool(_isWalkingAnim, false);
        }

        // Camera
        var realDirection = new Vector3(_currentMovement.x, 0, _currentMovement.y);
        realDirection = _camera.transform.TransformDirection(realDirection);

        // Rotation
        transform.LookAt(transform.position + realDirection);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);


        // Gravity
        _vSpeed -= _gravity * Time.deltaTime;
        realDirection.y = _vSpeed;

        if (_isRunning)
        {
            _controller.Move(realDirection * _speed * Time.deltaTime * 2);
            _isRunning = true;
        }
        else
        {
            _controller.Move(realDirection * _speed * Time.deltaTime);
            _isRunning = false;
        }
    }
}
