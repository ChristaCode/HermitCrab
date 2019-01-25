using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance;
    public float MaxSpeed = 10f;
    [SerializeField] float ScareDuration = 1f;
    float MoveHorizontal;
    float MoveVertical;
    bool facingRight;
    Vector3 targetPos;
    SpriteRenderer doggoSprite;
    Animator doggoAnimations;
    AudioSource bark;
    float idleTimer;
    [SerializeField] AudioClip[] Barks;
    [SerializeField] GameObject _woofLines;
    Animator _woofAnim;
    SpriteRenderer _woofSprite;

    public float CurrentSpeed;

    Rigidbody _rb;

    SpriteRenderer _mySprite;

    void Start ()
    {
        Instance = this;
        doggoSprite = GetComponent<SpriteRenderer>();
        doggoAnimations = GetComponent<Animator>();
        bark = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        //_mySprite = GetComponent<SpriteRenderer>();

        _woofAnim = _woofLines.GetComponent<Animator>();
        _woofSprite = _woofLines.GetComponent<SpriteRenderer>();

    }
    
    void Update()
    {
        //if (SceneMgr.Instance.GameOver)
          //  return;

        //_mySprite.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1; //this means the dog will be drawn in fron of or behind items if it is higher/lower than them

        if (Input.GetButtonDown("Bark"))
        {
            if (bark.isPlaying)
                return;

            int b = Random.Range(0, 3);
            bark.clip = Barks[b];
            _woofAnim.SetTrigger("isBarking");

            bark.Play();
            StartCoroutine("ScareSheep");
        }

        if (facingRight)
        {
            if (!doggoSprite.flipX)
            {
                doggoSprite.flipX = true;
                _woofSprite.flipX = true;

                _woofLines.transform.localPosition = new Vector2(4.41f, -0.28f);
            }
        }
        else
        {
            if (doggoSprite.flipX)
            {
                doggoSprite.flipX = false;
                _woofSprite.flipX = false;

                _woofLines.transform.localPosition = new Vector2(-4.41f, -0.28f);
            }
        }

        if (MoveHorizontal > 0 && !facingRight)
            facingRight = true;
        else if (MoveHorizontal < 0 && facingRight)
            facingRight = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
                //Vector3 tarDirection = transform.position - touchPosition;
                //print(tarDirection);
                //_rb.velocity = new Vector2(tarDirection.x * MaxSpeed, tarDirection.y * MaxSpeed);

                MoveHorizontal = 1;
                MoveVertical = 1;

            }
        }
    }

    void FixedUpdate()
    {

        //if (SceneMgr.Instance.GameOver || SceneMgr.Instance.DisableMovement)
        //{
        //    GetComponent<Rigidbody2D>().Sleep();
        //    MoveHorizontal = 0f;
        //    MoveVertical = 0f;
        //    return;
        //}

        //for Keyboard Input/////////////////////////////////////////////////////////////////////////////////////////////
        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");

        _rb.velocity = new Vector3(MoveHorizontal * MaxSpeed, _rb.velocity.y, MoveVertical * MaxSpeed);
        CurrentSpeed = MoveVertical * MaxSpeed;

        if (MoveHorizontal < -0.1 || MoveHorizontal > 0.1)
            doggoAnimations.SetFloat("Speed", 1);
        
        if (MoveVertical < -0.1 || MoveVertical > 0.1)
            doggoAnimations.SetFloat("Speed", 1);

        if (MoveVertical == 0 && MoveHorizontal == 0)
        {
            doggoAnimations.SetFloat("Speed", 0);
            idleTimer += Time.deltaTime;
        }
        else
            if (idleTimer > 0)
            idleTimer = 0f;

        if (idleTimer >= 5)
            doggoAnimations.SetTrigger("Sit");

    }    
}
