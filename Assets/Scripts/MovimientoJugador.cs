using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour 
{
	private CharacterController controller;
	private float Velocidad = 0;
	private float VelocidadP = 10.0f;
	private float VelocidadA = 5.0f;
	private float Vertical = 0.0f;
	private float gravedad = 13.0f;
	private Vector3 moveVector;
	private int carril = 0;
	public float distancia = 0;
	private float donde;
	private float newposition = 0.0f;




	// Use this for initialization
	void Start () {
		carril = 0;

		controller = GetComponent<CharacterController> ();   // componente del personaje
	}
	
	// Update is called once per frame
	void Update () {

		newposition = transform.position.x;
		distancia = transform.position.z;
		donde = GameObject.FindGameObjectWithTag ("Respawn").transform.position.z;

		if (controller.isGrounded)  // si esta tocando el suelo su velocidad en y debe ser 0, sino debe actuar la gravedad
		{ 
			Vertical = 0.0f;
			Velocidad = VelocidadP;

		}
		else 
		{
			Vertical -= gravedad * Time.deltaTime;
			Velocidad = VelocidadA;

		}
		 
		if((Input.GetKeyDown(KeyCode.UpArrow)) & (controller.isGrounded)) // codigo para el salto
		{
			Vertical = 8.0f;
		}
			
	
		/// Y
		moveVector.y = Vertical; 

		/// Z
		moveVector.z = Velocidad; // moviemiento constante en el eje z para que simpre vaya hacia el frente
		controller.Move (moveVector * Time.deltaTime);

		/// x

		/*
		if (Input.GetKeyDown (KeyCode.LeftArrow))   // movimiento entre 3 carriles 
			{ while(newposition > -2.0f)
			moveVector.x = -7;
			}*/
		if (Input.GetKeyDown (KeyCode.LeftArrow) & (carril >-1)) 
		{ 
			moveVector.x = -7;
			StartCoroutine (parar ());
			carril -= 1;

		}
				



		if (Input.GetKeyDown (KeyCode.RightArrow) & (carril <1)) 
		{ 
			moveVector.x = 7;
			StartCoroutine (parar ());
			carril += 1;

		}
			

			
		/// aumento progresivo de la velocidad cada 100 metros
		while (donde < distancia) {
			donde += 100;
		}

		if (donde <= 100)
			VelocidadP = 10;
		if ((donde > 100) & (donde <=200))
			VelocidadP = 11;
		if ((donde > 200) & (donde <=300))
			VelocidadP = 12;
		if ((donde > 300) & (donde <=400))
			VelocidadP = 13;
		if ((donde > 400) & (donde <=500))
			VelocidadP = 14;
		if ((donde > 500) & (donde <=600))
			VelocidadP = 15;
		if ((donde > 600) & (donde <=700))
			VelocidadP = 16;
		if ((donde > 700) & (donde <=800))
			VelocidadP = 17;
		if ((donde > 800) & (donde <=900))
			VelocidadP = 18;
		if ((donde > 900) & (donde <=1000))
			VelocidadP = 19;

			
		Debug.Log (Velocidad);
		Debug.Log (donde);

		}
			
	IEnumerator parar() {
		yield return new WaitForSeconds(0.2f);
		moveVector.x = 0;
	}




	}



