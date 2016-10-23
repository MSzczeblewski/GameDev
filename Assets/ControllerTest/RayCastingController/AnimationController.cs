using UnityEngine;
using System.Collections;

public class AnimationController : RaycastController {

	public Transform groundCheck;
	public LayerMask whatIsGround;

	[HideInInspector]
	public bool lookingRight = true;
	public GameObject Boost;

	private Animator cloudanim;
	public GameObject Cloud;

	private Animator anim;
	private bool isGrounded = false;
	public BoxCollider2D collider;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		//cloudanim = GetComponent<Animator>();
		collider = GetComponent<BoxCollider2D> ();

		Cloud = GameObject.Find("Cloud");
		//cloudanim = GameObject.Find("Cloud(Clone)").GetComponent<Animator>();
	}


	void OnCollisionEnter2D(Collision2D collision2D) {

		if (collision2D.relativeVelocity.magnitude > 20){
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		}
	}



	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Jump") && (isGrounded ))
		{
			if (!isGrounded)
			{
				Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;	
			}
		}


		if (Input.GetButtonDown("Vertical") && !isGrounded)
		{
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;

		}

	}


	void FixedUpdate()
	{
		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (hor));

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}



	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

}
