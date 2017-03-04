using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public float scrollZone = 30;
	public float scrollSpeed = 2;

	public float xMax = 8;
	public float xMin = 0;
	public float yMax = 10;
	public float yMin = 3;
	public float zMax = 8;
	public float zMin = 0;

	private Vector3 desiredPosition;

	private void Start()
	{
		desiredPosition = transform.position;
	}

	private void Update()
	{
		float x = 0, y = 0, z = 0;
		float speed = scrollSpeed * Time.deltaTime;

		if (Input.mousePosition.x < scrollZone)
			x -= speed;
		else if (Input.mousePosition.x > Screen.width - scrollZone)
			x += speed;

		if (Input.mousePosition.y < scrollZone)
			y -= speed;
		else if (Input.mousePosition.y > Screen.height - scrollZone)
			y += speed;

		//y += Input.GetAxis ("Mouse ScrollWheel");

		Vector3 move = new Vector3 (x, y, z) + desiredPosition;
		//move.x = Mathf.Clamp (move.x, xMin, xMax);
		move.y = Mathf.Clamp (move.y, yMin, yMax);
		//move.z = Mathf.Clamp (move.z, zMin, zMax);
		desiredPosition = move;
		transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.2f);

	}


}

