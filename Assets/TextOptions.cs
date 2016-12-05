using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextOptions : MonoBehaviour {

	public static TextOptions instance;

    public Text textUI;
    private int textIndex = 0;

	public struct FoodRequirement {

		public int numFiber;
		public int numVitaminA;
		public int numCalcium;

		public FoodRequirement(int fiber, int vitA, int calcium) {

			numFiber = fiber;
			numVitaminA = vitA;
			numCalcium = calcium;

		}

		public override string ToString ()
		{
			return string.Format ("Fiber: {0} \n Vitamin A: {1} \n Calcium: {2}", numFiber, numVitaminA, numCalcium);
		}
	}

	public static KeyValuePair<string, FoodRequirement>[] questions = new KeyValuePair<string, FoodRequirement>[]
    {
		new KeyValuePair<string, FoodRequirement> ("Pick 3 items that are a good source of Vitamin A.", new FoodRequirement(0, 3, 0)),
		new KeyValuePair<string, FoodRequirement> ("Pick 2 items that are a high source of fiber.", new FoodRequirement(2,0,0)),
		new KeyValuePair<string, FoodRequirement> ("Pick 3 items that are high source of calcium.", new FoodRequirement(0,0,3))
    };

	public void Awake() {

		if (instance == null) {
			instance = this;
		}


	}

    public void Start()
    {

		UpdateRequirement ();

    }

    public void CycleOptions()
    {

        textIndex++;

        if (textIndex >= questions.Length)
        {

            textIndex = 0;

        }

		UpdateRequirement ();



    }

    public void UpdateRequirement()
    {

		Cart.currentRequirement = questions [textIndex].Value;

		Debug.Log ("Current requirement: " + Cart.currentRequirement.ToString ());

        textUI.text = questions[textIndex].Key;

    }
}
