using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeAvatar : MonoBehaviour
{
    public SpriteRenderer part;

    public Sprite[] options;

    public int index;

    public string partIndex;

    void Start()
    {
        
    }


    void Update()
    {
        part.sprite = options[index];
    }

    public void Swap()
    {
        index = (index + 1) % options.Length;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(string index)
    {
        if(partIndex.Equals("HeadGear"))
        {
            this.index = System.Convert.ToInt32(StaticVariable.UserProfile.avatar.headgear);

            Debug.Log("HeadGearIndex: " + index);
        }
        else if (partIndex.Equals("Head"))
        {
            this.index = System.Convert.ToInt32(StaticVariable.UserProfile.avatar.head);
            Debug.Log("HeadIndex: " + index);
        }
        else
        {
            this.index = System.Convert.ToInt32(StaticVariable.UserProfile.avatar.body);
            Debug.Log("BodyIndex: " + index);
        }
    }

}
