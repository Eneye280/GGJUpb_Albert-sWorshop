using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    [SerializeField] internal Vector2 direction;
    [SerializeField] internal Vector3 movement;
    [SerializeField] internal Animator animatorPlayer;

    [Range(0,100)]
    [SerializeField] internal float speed;
    [Range(0, 100*3)]
    [SerializeField] internal float rotatte;

    public CharacterController controller;
    public float newSpeed = 6.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private GameObject objectRepaired;
    [SerializeField]
    private GameObject objectOutRepaired;
    [SerializeField]
    private GameObject objectOnTheCounter;
    [SerializeField]
    private bool inGrabPoint;
    [SerializeField]
    private bool inWorkZone;
    [SerializeField]
    private Transform objectGripped;
    [SerializeField]
    private Transform workZonePosition;

    //Test
    public bool testBoolGrab = false;
    public bool testBoolRelease = false;

    internal InputPlayer controls;
    private void OnDisable() => controls.Disable();
    private void OnEnable() => controls.Enable();

    private void Awake()
    {
        controls = new InputPlayer();

        animatorPlayer = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        objectGripped = transform.GetChild(0);
    }

    private void Update()
    {
        //CallMovementPlayer();
        Movement();

        //Test
        Grab();
        Release();
    }

    public void CallMovementPlayer()
    {
        float h = direction.x;
        float v = direction.y;

        h *= Time.deltaTime;
        v *= Time.deltaTime;

        transform.Translate(0, 0, h);
        transform.Rotate(new Vector3(0, v, 0));
        //movement = new Vector3();
        //movement.Set(h, 0, v);

        //transform.Translate(movement * speed * Time.deltaTime);
        //transform.Rotate(h,0,v);

        //if (animatorPlayer == null)
        //    return;

        animatorPlayer.SetFloat("vertical", direction.y);
        animatorPlayer.SetFloat("horizontal", direction.x);
    }

    public void Movement()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotatte;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(new Vector3(0, rotation, 0));

        //animatorPlayer.SetFloat("vertical", translation);
        //animatorPlayer.SetFloat("horizontal", translation);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "GrabPoint")
        {
            print("InGrabPoint");
            inGrabPoint = true;

            if(other.transform.GetChild(0) != null)
            {
                objectOnTheCounter = other.transform.GetChild(0).gameObject;
            }
            
        }

        if (other.tag == "WorkZone")
        {
            print("InWorkZone");
            inWorkZone = true;

            controls.Player.Add.performed += ctx => testBoolRelease = true;

            if (other.transform.GetChild(0) != null)
            {
                workZonePosition = other.transform.GetChild(0).gameObject.transform;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GrabPoint")
        {
            print("OutGrabPoint");
            inGrabPoint = false;

            if(objectOnTheCounter != null)
            {
                objectOnTheCounter = null;
            }
        }
    }

    public void Grab()
    {
        if (testBoolGrab)
        {
            if (inGrabPoint)
            {
                if (objectOnTheCounter != null)
                {
                    objectOutRepaired = objectOnTheCounter;
                    objectOutRepaired.transform.parent = objectGripped;
                    objectOutRepaired.transform.localPosition = new Vector3(0, 0, 0);
                    testBoolGrab = false;
                }
            }
        }
    }

    public void Release()
    {
        if (testBoolRelease)
        {
            if (inWorkZone)
            {
                if (objectOutRepaired != null)
                {
                    objectOutRepaired.transform.parent = workZonePosition;
                    objectOutRepaired.transform.localPosition = new Vector3(0, 0, 0);
                    testBoolRelease = false;
                }
            }
        }
    }
}
