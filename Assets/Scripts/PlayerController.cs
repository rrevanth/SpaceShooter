using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	void FixedUpdate() {
		float horizantal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (horizantal, 0.0f, vertical);
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
