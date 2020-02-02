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

    private void Awake()
    {
        animatorPlayer = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //CallMovementPlayer();
        Movement();
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
}
