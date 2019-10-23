using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System;

public class Statistic2 : MonoBehaviour
{
    public CRUDScores dbClass;
    public Text easyPRchap1;
    public Text easyPRchap2;
    public Text easyPRchap3;
    public Text easyPRchap4;
    public Text midPRchap1;
    public Text midPRchap2;
    public Text midPRchap3;
    public Text midPRchap4;
    public Text hardPRchap1;
    public Text hardPRchap2;
    public Text hardPRchap3;
    public Text hardPRchap4;
    public Text easyTAchap1;
    public Text easyTAchap2;
    public Text easyTAchap3;
    public Text easyTAchap4;
    public Text midTAchap1;
    public Text midTAchap2;
    public Text midTAchap3;
    public Text midTAchap4;
    public Text hardTAchap1;
    public Text hardTAchap2;
    public Text hardTAchap3;
    public Text hardTAchap4;

    public Text easyAvchap1;
    public Text easyAvchap2;
    public Text easyAvchap3;
    public Text easyAvchap4;
    public Text midAvchap1;
    public Text midAvchap2;
    public Text midAvchap3;
    public Text midAvchap4;
    public Text hardAvchap1;
    public Text hardAvchap2;
    public Text hardAvchap3;
    public Text hardAvchap4;

    public void DropdownValueChanged(Dropdown Dropdown) {
        Debug.Log(Dropdown.options[Dropdown.value].text);
        string world = "";
        switch(Dropdown.options[Dropdown.value].text){
            case "World 1": world =  "world1"; break;
            case "World 2": world =  "world2"; break;
            case "World 3": world =  "world3"; break;
            case "World 4": world =  "world4"; break;  
        }
        dbClass.getStatistic2(world);
    }

    void Awake() {
        dbClass.getStatistic2("world1");
    }

    void Update(){
        int tmpPR;
        dbClass.highestScoreDict.TryGetValue("chap1easy",out tmpPR);
        easyPRchap1.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap2easy",out tmpPR);
        easyPRchap2.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap3easy",out tmpPR);
        easyPRchap3.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap4easy",out tmpPR);
        easyPRchap4.text = tmpPR.ToString(); 
        dbClass.highestScoreDict.TryGetValue("chap1mid",out tmpPR);
        midPRchap1.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap2mid",out tmpPR);
        midPRchap2.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap3mid",out tmpPR);
        midPRchap3.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap4mid",out tmpPR);
        midPRchap4.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap1hard",out tmpPR);
        hardPRchap1.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap2hard",out tmpPR);
        hardPRchap2.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap3hard",out tmpPR);
        hardPRchap3.text = tmpPR.ToString();
        dbClass.highestScoreDict.TryGetValue("chap4hard",out tmpPR);
        hardPRchap4.text = tmpPR.ToString();  

        int tmpTA;
        dbClass.lowestScoreDict.TryGetValue("chap1easy",out tmpTA);
        easyTAchap1.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap2easy",out tmpTA);
        easyTAchap2.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap3easy",out tmpTA);
        easyTAchap3.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap4easy",out tmpTA);
        easyTAchap4.text = tmpTA.ToString(); 
        dbClass.lowestScoreDict.TryGetValue("chap1mid",out tmpTA);
        midTAchap1.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap2mid",out tmpTA);
        midTAchap2.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap3mid",out tmpTA);
        midTAchap3.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap4mid",out tmpTA);
        midTAchap4.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap1hard",out tmpTA);
        hardTAchap1.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap2hard",out tmpTA);
        hardTAchap2.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap3hard",out tmpTA);
        hardTAchap3.text = tmpTA.ToString();
        dbClass.lowestScoreDict.TryGetValue("chap4hard",out tmpTA);
        hardTAchap4.text = tmpTA.ToString();                        
        
        double tmpAV;
        dbClass.averageScoreDict.TryGetValue("chap1easy",out tmpAV);
        easyAvchap1.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap2easy",out tmpAV);
        easyAvchap2.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap3easy",out tmpAV);
        easyAvchap3.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap4easy",out tmpAV);
        easyAvchap4.text = Math.Round(tmpAV,2).ToString(); 
        dbClass.averageScoreDict.TryGetValue("chap1mid",out tmpAV);
        midAvchap1.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap2mid",out tmpAV);
        midAvchap2.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap3mid",out tmpAV);
        midAvchap3.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap4mid",out tmpAV);
        midAvchap4.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap1hard",out tmpAV);
        hardAvchap1.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap2hard",out tmpAV);
        hardAvchap2.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap3hard",out tmpAV);
        hardAvchap3.text = Math.Round(tmpAV,2).ToString();
        dbClass.averageScoreDict.TryGetValue("chap4hard",out tmpAV);
        hardAvchap4.text = Math.Round(tmpAV,2).ToString();                        
        
    }
        
    public void BackToLastPage()
    {
        Application.LoadLevel("Statistics");
        
    }
    
}
