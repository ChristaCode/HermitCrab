using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance;
    public float MaxSpeed = 10f;
    float MoveHorizontal;
    float MoveVertical;
    bool facingRight;
    Vector3 targetPos;
    SpriteRenderer crabSprite;
    Animator crabAnimations;
    float idleTimer;


    public float PlayerSize = 1f;
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public float CurrentSpeed;

    Rigidbody _rb;

    SpriteRenderer _mySprite;

    void Start ()
    {
        Instance = this;
        crabSprite = GetComponent<SpriteRenderer>();
        crabAnimations = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        //_mySprite = GetComponent<SpriteRenderer>();

        

    }
    
    void Update()
    {
        //if (SceneMgr.Instance.GameOver)
          //  return;

        //_mySprite.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1; //this means the dog will be drawn in fron of or behind items if it is higher/lower than them

        /*if (Input.GetButtonDown("Bark"))
        {
            if (bark.isPlaying)
                return;

            int b = Random.Range(0, 3);
            bark.clip = Barks[b];
            _woofAnim.SetTrigger("isBarking");

            bark.Play();
            StartCoroutine("ScareSheep");
        }*/

        if (crabSprite != null) {
            if (facingRight)
            {
                if (!crabSprite.flipX)            
                    crabSprite.flipX = true; 

            }
            else
            {
                if (crabSprite.flipX)            
                    crabSprite.flipX = false;              
                
            }
        }

        if (MoveHorizontal > 0 && !facingRight)
            facingRight = true;
        else if (MoveHorizontal < 0 && facingRight)
            facingRight = false;
        
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

        if (crabAnimations != null) {
            float animationSpeed = Vector2.ClampMagnitude(new Vector2(MoveHorizontal, MoveVertical).normalized, 1f).magnitude;
            crabAnimations.SetFloat("Speed", animationSpeed);
        }
        if (MoveVertical == 0 && MoveHorizontal == 0)
        {
            idleTimer += Time.deltaTime;
        }
        else {
            idleTimer = 0f;    
        }

        if (idleTimer >= 5f)
            crabAnimations.SetTrigger("Sit");

    }    
}
