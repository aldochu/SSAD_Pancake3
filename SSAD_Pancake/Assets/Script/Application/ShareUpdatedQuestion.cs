using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareUpdatedQuestion : MonoBehaviour
{
    public GameObject contentText;

    // Start is called before the first frame update
    void Start()
    {
        contentText = GameObject.Find("AssignmentContent");
        contentText.GetComponent<Text>().text = ModifyChapter.sharingQforProf;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
