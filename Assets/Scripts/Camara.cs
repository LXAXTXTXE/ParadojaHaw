using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	private Transform MirarA;
	private Vector3 IniciarEn;
	private Vector3 movimiento;

	// Use this for initialization
	void Start () {
		MirarA = GameObject.FindGameObjectWithTag ("Player").transform; // que siga al jugador
		IniciarEn = transform.position - MirarA.position; // que comience un poco antes para lograr la vista en tercera persona
	}
	
	// Update is called once per frame
	void Update () {
		movimiento= MirarA.position + IniciarEn;

		///x
		movimiento.x= 0;  // para que la camara no se mueva lateralmente

		transform.position = movimiento;
	}
}
