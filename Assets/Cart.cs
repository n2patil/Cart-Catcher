using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cart : MonoBehaviour {

	public static TextOptions.FoodRequirement currentRequirement;

	public TextOptions.FoodRequirement currentFood;

	public List<Food> activeFood;

	public Text foodText;


	// Use this for initialization
	void Start () {
		currentFood = new TextOptions.FoodRequirement ();
		activeFood = new List<Food> ();

		foodText.text = currentFood.ToString ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
	{

		Food fallenFood = other.GetComponent<Food> ();

		if (fallenFood != null) {

			Destroy (fallenFood.GetComponent<Rigidbody2D> ());
			Destroy (fallenFood.GetComponent<Collider2D> ());

			activeFood.Add (fallenFood);

			fallenFood.transform.localScale *= 0.5f;

			if (fallenFood.hasCalcium) {

				currentFood.numCalcium++;

			}

			if (fallenFood.hasFiber) {

				currentFood.numFiber++;

			}

			if (fallenFood.hasVitaminA) {

				currentFood.numVitaminA++;
				Debug.LogFormat ("Num of vitA is {0}, need {1}", currentFood.numVitaminA, currentRequirement.numVitaminA);

			}



			CheckRequirement ();

			foodText.text = currentFood.ToString ();

		}


		//Destroy(other.gameObject);


    }

	public void CheckRequirement() {

		if (currentFood.numCalcium < currentRequirement.numCalcium) {
			Debug.Log("Not enough calcium");
			return;
		}

		if (currentFood.numFiber < currentRequirement.numFiber){
			Debug.Log("Not enough fiber");

			return;
		}

		if (currentFood.numVitaminA < currentRequirement.numVitaminA){
			Debug.Log("Not enough vitamin A");

			return;
		}

		TextOptions.instance.CycleOptions ();

		ClearCart ();


	}

	public void ClearCart() {

		foreach (Food food in activeFood) {

			GameObject.Destroy (food.gameObject);

		}

		activeFood.Clear ();

		currentFood = new TextOptions.FoodRequirement ();
		foodText.text = currentFood.ToString ();

	}
}
