using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {
	public float speed = 1f;
	private float travelAllowance = 0f;

	private Queue<GameObject> guides = new Queue<GameObject>();
	private GameObject currentGuide;

	// Use this for initialization
	void Start () {
		guides = GetFormationGuides();
		if (guides.Count > 0) {
			currentGuide = guides.Dequeue();
		}
	}
	
	// Update is called once per frame
	void Update () {
		travelAllowance = speed * Time.deltaTime;
		SelectMovement ();
	}

	void SelectMovement(){
		if (currentGuide != null) {
			MoveInFormation();
		}else{
			MoveAutonomously();
		}
	}

	void MoveInFormation(){
		Vector2 currentPosition = this.transform.position;
		Vector2 targetPosition = currentGuide.transform.position;

		Vector3 travelDirection = targetPosition - currentPosition;
		travelDirection.Normalize();

		float distanceToTarget = Vector2.Distance(currentPosition, targetPosition);
		if(distanceToTarget > travelAllowance){
			TranslateCloser(travelDirection);
		}else{
			TranslateToGuide(travelDirection, distanceToTarget);
			AssessNextGuide();
			SelectMovement();
		}
	}

	void TranslateCloser(Vector3 travelDirection){
		this.transform.Translate(travelDirection * travelAllowance);
		travelAllowance = 0f;
	}

	void TranslateToGuide(Vector3 travelDirection, float distanceToTarget){
		this.transform.Translate(travelDirection * distanceToTarget);
		travelAllowance -= distanceToTarget;
	}

	void AssessNextGuide(){
		if (guides.Count > 0) {
			currentGuide = guides.Dequeue();
		} else {
			currentGuide = null;
		}
	}

	void MoveAutonomously(){
		this.transform.Translate(Vector3.left * travelAllowance);
	}

	bool IsFollowingFormation(){
		return (currentGuide != null);
	}

//	void OnTriggerEnter2D(Collider2D other){
//		
//	}

	private Queue<GameObject> GetFormationGuides(){
		List<GameObject> guides = new List<GameObject>();
		foreach(Transform sibling in this.transform.parent){
			if(sibling.GetComponent<FormationGuide>() != null){
				guides.Add(sibling.gameObject);
			}
		}
		if (guides.Count < 0){
			guides.Sort((IComparer<GameObject>)new Sort());
		}
		Queue<GameObject> orderedGuides = new Queue<GameObject> (guides);
		return orderedGuides;
	}

	private class Sort : IComparer<GameObject>{
		int IComparer<GameObject>.Compare(GameObject a, GameObject b){
			int orderA = a.GetComponent<FormationGuide> ().order;
			int orderB = b.GetComponent<FormationGuide> ().order;
			return orderA.CompareTo (orderB);
		}
	}
}
