using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int enemyCount;
	public GameObject enemy;
    public Text Health;

    // Private Instance Variables
    private int hp = 5;

    // Use this for initialization
    void Start () {
		this._GenerateEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate enemies
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}

    public void DecreaseHP(int Decrease)
    {
        hp -= Decrease;
        Health.text = "HP: " + hp + "/5";
        if (hp <= 0)
        {
        }
    }
}
