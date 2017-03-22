using UnityEngine;
using System.Collections;

public class NewCamera : MonoBehaviour 
{
	[SerializeField]
	private float cameraSpeed = 0;

	private void Update()
	{
		GetInput ();
	}

	private void GetInput()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate (Vector3.up * cameraSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate (Vector3.left * cameraSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate (Vector3.down * cameraSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * cameraSpeed * Time.deltaTime);
		}
	}
}