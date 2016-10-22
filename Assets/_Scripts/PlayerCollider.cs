using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    //Public Instance Variables
    public int HP = 5;
    private GameController controller; //Instantiate the game contoller

    // Use this for initialization
    void Start () {
        // To call GameController Methods
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

    //When the player hits an enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HP--;
            controller.DecreaseHP(1);
            if (HP <= 0)
            {
                controller._endGame(); // This method ends the game
            }
        }
    }
}
