using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	//public float speed;
	public Boundary boundary;
	public Camera camera;

    // PRIVATE INSTANCE VARIABLES
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
    private GameController controller;
	
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

	// Update is called once per frame
	void Update () {
		this._CheckInput ();
	}

	private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; // current position

		/* movement by keyboard
		if (Input.GetAxis ("Horizontal") > 0) {
			this._newPosition.x += this.speed; // add move value to current position
		}
	
		
		if (Input.GetAxis ("Horizontal") < 0) {
			this._newPosition.x -= this.speed; // subtract move value to current position
		}
		*/

		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this._BoundaryCheck ();

        this._newPosition.y = this.camera.ScreenToWorldPoint(mousePosition).y;

        this._BoundaryCheck();

        gameObject.GetComponent<Transform>().position = this._newPosition;
	}

	private void _BoundaryCheck() {
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}

        if (this._newPosition.y < this.boundary.yMin)
        {
            this._newPosition.y = this.boundary.yMin;
        }

        if (this._newPosition.y > this.boundary.yMax)
        {
            this._newPosition.y = this.boundary.yMax;
        }
    }

    //When the player hits an enemy
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            controller.DecreaseHP(1);
        }
    }
}
