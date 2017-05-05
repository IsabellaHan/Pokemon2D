using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour {
	public float roamSpeed; // speed of the ai
	public Transform[] patrolWayPoints; // array of transform points in ai's roaming route

	protected UnityEngine.AI.NavMeshAgent agent; // ai's nav mesh
	protected int wayPointIndex; // counter for the way point arrays
	private static bool alreadyCaught = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();


	}
	
	// Update is called once per frame
	void Update () {
		

	}

	protected void OnCollisionEnter (Collision withBall)
	{
		if (withBall.gameObject.GetComponent<Ball> () != null) { // if this gameobject collides with a thing with Ball script...
			Die ();

		}
	
	}

	protected void Patrol()
	{
		agent.speed = roamSpeed;

		agent.destination = patrolWayPoints [wayPointIndex].position;

		if (Vector3.Distance(transform.position, patrolWayPoints[wayPointIndex].position) < 1f) // if the position of the pokemon is the same as the way points position do a thing....
			wayPointIndex ++; // go to next way point
		if (wayPointIndex > patrolWayPoints.Length - 1) // if at the last way point...
			wayPointIndex = 0; // go to the first way point

	}

	protected virtual void Die()
	{
		Destroy (this.gameObject);
		if (alreadyCaught == false) {
			alreadyCaught = true;
		} else {
			return;
		}
	}
}

