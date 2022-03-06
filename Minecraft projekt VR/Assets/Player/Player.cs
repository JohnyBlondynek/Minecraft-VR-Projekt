using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
	public int punkty;
	public CharacterController characterControler;
	public float predkoscPoruszania = 9.0f;
	public float wysokoscSkoku = 7.0f;
	public float aktualnaWysokoscSkoku = 0f;
	public float predkoscBiegania = 7.0f;
	public float czuloscMyszki = 3.0f;
	public float myszGoraDol = 0.0f;
	public float zakresMyszyGoraDol = 90.0f;
	public Camera kamera;
	void Start()
	{
		characterControler = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;

	}
	void Update()
	{
				klawiatura();
				myszka();

	}
	private void klawiatura()
	{
		float rochPrzodTyl = Input.GetAxis("Vertical") * predkoscPoruszania;
		float rochLewoPrawo = Input.GetAxis("Horizontal") * predkoscPoruszania;
		if (characterControler.isGrounded && Input.GetButton("Jump"))
		{
			aktualnaWysokoscSkoku = wysokoscSkoku;
		}
		else if (!characterControler.isGrounded)
		{
			aktualnaWysokoscSkoku += Physics.gravity.y * Time.deltaTime;
		}
		if (Input.GetKeyDown("left shift"))
		{
			predkoscPoruszania += predkoscBiegania;
		}
		else if (Input.GetKeyUp("left shift"))
		{
			predkoscPoruszania -= predkoscBiegania;
		}
		Vector3 ruch = new Vector3(rochLewoPrawo, aktualnaWysokoscSkoku, rochPrzodTyl);
		ruch = transform.rotation * ruch;
		characterControler.Move(ruch * Time.deltaTime);
	}

	private void myszka()
	{
			float myszLewoPrawo = Input.GetAxis("Mouse X") * czuloscMyszki;
			transform.Rotate(0, myszLewoPrawo, 0);
			myszGoraDol -= Input.GetAxis("Mouse Y") * czuloscMyszki;
			myszGoraDol = Mathf.Clamp(myszGoraDol, -zakresMyszyGoraDol, zakresMyszyGoraDol);
			kamera.transform.localRotation = Quaternion.Euler(myszGoraDol, 0, 0);
	}
}
