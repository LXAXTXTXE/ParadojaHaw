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
	private float gravedad = 10.0f;
	private Vector3 moveVector;
	private int carril = 0;
	public float distancia = 0;
	private float donde;
	private float newposition = 0.0f;
	public AudioClip sonidoMoneda = null;




	// Use this for initialization
	void Start () {
		
		carril = 0;
		controller = GetComponent<CharacterController> ();   // componente del personaje
	}
	
	// Update is called once per frame
	void Update () {
		
		Vertical -= gravedad * Time.deltaTime;
		distancia = transform.position.z;
		donde = GameObject.FindGameObjectWithTag ("Respawn").transform.position.z;

		if (transform.position.y > 5) {
			gravedad = 15;
		} else {
			gravedad = 10;
		}

		if (transform.position.y < 2.6) {
			Velocidad = VelocidadP;
		} else {
			Velocidad = VelocidadA;
		}

		if ((Input.GetKeyDown (KeyCode.UpArrow)) & (transform.position.y < 2.6)) { // codigo para el salto
			Vertical = 6.0f;
			gravedad += 2;
		}

		
	
		/// Y
		moveVector.y = Vertical; 

		/// Z
		moveVector.z = Velocidad; // moviemiento constante en el eje z para que simpre vaya hacia el frente
		controller.Move (moveVector * Time.deltaTime);


		/// x


		/*if ((Input.GetKeyDown (KeyCode.LeftArrow)) && (carril >-1))   // movimiento entre 3 carriles 
			{ if(newposition > -2.0f)
			moveVector.x = -4;
			carril -=1;
			}
		if ((Input.GetKeyDown (KeyCode.RightArrow)) && (carril >1))   // movimiento entre 3 carriles 
		{ if(newposition > -2.0f)
			moveVector.x = 3;
			carril +=1;
		}

		if (newposition <= -2){
			moveVector.x = 0;}

		if (newposition >= 2){
			moveVector.x = 0;}*/
		


		if( Input.GetKeyDown(KeyCode.LeftArrow))   // movimiento entre 3 carriles 
		{if (carril > -1)
			carril --;
		}
		if( Input.GetKeyDown(KeyCode.RightArrow))
		{if (carril < 1)
			carril ++;
		}


		Vector3 newposition = transform.position;  // posicionar el objeto segun el valor que tenga la variable "carril"
		newposition.x = Mathf.Lerp(newposition.x, 2 * carril, Time.deltaTime * 5);
		transform.position = newposition;


			
		/// aumento progresivo de la velocidad cada 100 metros
		while (donde < distancia) {
			donde += 200;
		}

		if (donde <= 200)
			VelocidadP = 10;
		if ((donde > 200) & (donde <=400))
			VelocidadP = 11;
		if ((donde > 400) & (donde <=600))
			VelocidadP = 12;
		if ((donde > 600) & (donde <=800))
			VelocidadP = 13;
		if ((donde > 800) & (donde <=1000))
			VelocidadP = 14;
		if ((donde > 1000) & (donde <=1200))
			VelocidadP = 15;
		if ((donde > 1200) & (donde <=1400))
			VelocidadP = 16;
		if ((donde > 1400) & (donde <=1600))
			VelocidadP = 17;
		if ((donde > 1600) & (donde <=1800))
			VelocidadP = 18;
		if ((donde > 1800) & (donde <=2000))
			VelocidadP = 19;

			
		Debug.Log (Velocidad);
		Debug.Log (donde);




	}
	void OnTriggerEnter (Collider obj){
		if (obj.gameObject.tag == "coin"){
			obj.gameObject.SetActive (false);
			AudioSource.PlayClipAtPoint (sonidoMoneda, transform.position);
		}
}
}

///



