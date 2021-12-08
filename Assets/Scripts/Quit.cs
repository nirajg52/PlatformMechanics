using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Thank you for Playing");
        
        EditorApplication.ExitPlaymode();
    }
    
       

    
}
