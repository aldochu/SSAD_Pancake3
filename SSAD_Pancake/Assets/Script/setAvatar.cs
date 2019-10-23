﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAvatar : MonoBehaviour
{
	public GameObject headgear, head, body;
	public Sprite[] headgearSprite, headSprite, bodySprite;

	private string headgearValue, headValue, bodyValue;
	public bool isCurrentUser;
	// Start is called before the first frame update
	void Start()
	{
		if (StaticVariable.UserProfile.avatar.head != null && isCurrentUser)
		{
			headgearValue = StaticVariable.UserProfile.avatar.headgear;
			headValue = StaticVariable.UserProfile.avatar.head;
			bodyValue = StaticVariable.UserProfile.avatar.body;
		}
		else if (StaticVariable.UserProfile.avatar.head != null)
		{
			headgearValue = StaticVariable.UserProfile.avatar.headgear;
			headValue = StaticVariable.UserProfile.avatar.head;
			bodyValue = StaticVariable.UserProfile.avatar.body;
		}

        Debug.Log("current static value: " + StaticVariable.UserProfile.avatar.headgear + StaticVariable.UserProfile.avatar.head + StaticVariable.UserProfile.avatar.body);


		updateSprite(headgearValue, headValue, bodyValue);
	}


	public void updateSprite(string headgearValue, string headValue, string bodyValue)
	{
		headgear.GetComponent<SpriteRenderer>().sprite = headgearSprite[System.Convert.ToInt32(headgearValue)];
		head.GetComponent<SpriteRenderer>().sprite = headSprite[System.Convert.ToInt32(headValue)];
		body.GetComponent<SpriteRenderer>().sprite = bodySprite[System.Convert.ToInt32(bodyValue)];
		Debug.Log("current value: " + headgearValue + headValue + bodyValue);
	}
}
