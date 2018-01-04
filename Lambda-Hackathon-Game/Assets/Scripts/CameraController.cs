using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private float currentX = 0.0f;
	private float currentY = 0.0f;
	public float sensitivityX = 2.5f;
	public float sensitivityY = 1.0f;
	
	public Transform camTransform;

	private Camera cam;

	void Start () 
	{
		camTransform = transform;
		cam = Camera.main;
	}
	

	void Update () 
	{
		currentX += Input.GetAxis("Mouse X") * sensitivityX;
		currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
		
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		camTransform.rotation = rotation;
	}
}
