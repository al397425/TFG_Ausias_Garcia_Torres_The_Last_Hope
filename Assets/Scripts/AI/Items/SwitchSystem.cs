using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSystem : MonoBehaviour
{

    [SerializeField] private GameObject Cube1;
    [SerializeField] private GameObject Cube2;
    [SerializeField] private GameObject Cube3;
    [SerializeField] private GameObject Cube4;
    [SerializeField] private GameObject Cube5;
    int counter = 0;
    string numbertext = "";

    public LeverSystem leverSystem1;
    public LeverSystem leverSystem2;
    public LeverSystem leverSystem3;
    public LeverSystem leverSystem4;
    public LeverSystem leverSystem5;
    public bool resetflag = false;
    private bool flag1 = false; 
    private bool flag2 = false; 
    private bool flag3 = false; 
    private bool flag4 = false; 
    private bool flag5 = false;
    //2 4 5 1 3

    void Start()
    {
        Debug.Log(leverSystem1.boolchecker);
    }


    void Update()
    {
        GetVariables();
        //Debug.Log("counter" + counter);
        if(numbertext != "24513" && counter == 5){
            numbertext = ""; //to clear;
            counter = 0;
            flag1 = false; leverSystem1.boolchecker = false; leverSystem1.flag = false;
            flag2 = false; leverSystem2.boolchecker = false; leverSystem2.flag = false;
            flag3 = false; leverSystem3.boolchecker = false; leverSystem3.flag = false;
            flag4 = false; leverSystem4.boolchecker = false; leverSystem4.flag = false;
            flag5 = false; leverSystem5.boolchecker = false; leverSystem5.flag = false;
        }else if(numbertext == "24513" && counter == 5){

            Debug.Log("Spawn Chest");
            
        }
    }
    /*private void ResetButtonOrder()
    {
        _buttonOrder.Clear();
        _buttonOrder.Push("2");
        _buttonOrder.Push("4");
        _buttonOrder.Push("5");
        _buttonOrder.Push("1");
        _buttonOrder.Push("3");
        resetflag = false;
    }
    public void OnButtonPressed(string token)
    {
        
        if(_buttonOrder.Peek() == token)
        {
            _buttonOrder.Pop();
            if(_buttonOrder.Count == 0)
            {
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            }
        }
        else
        {
            if(this.ResetButtonOrderOnFailure)
            {
                resetflag = true;
                this.ResetButtonOrder();
            }
        }
    }
*/
    void GetVariables(){
        

        if(leverSystem1.boolchecker == true && flag1 == false)
        {

            int number1 = 1;  
            
            numbertext = numbertext+ number1.ToString(); //to add number  
            Debug.Log("blabla: "+numbertext); //to combine
            flag1 = true;
            counter++;  
        }

        if(leverSystem2.boolchecker == true && flag2 == false)
        {
            int number2 = 2;  
            numbertext = numbertext+ number2.ToString(); //to add number  
            Debug.Log("blabla: "+numbertext); //to combine
            flag2 = true;
            counter++;
        }

        if(leverSystem3.boolchecker == true && flag3 == false)
        {
            int number3 = 3;  
            numbertext = numbertext+ number3.ToString(); //to add number  
            Debug.Log("blabla: "+numbertext); //to combine
            flag3 = true;
            counter++;
        } 

        if(leverSystem4.boolchecker == true && flag4 == false)
        {
            int number4 = 4;  
            numbertext = numbertext+ number4.ToString(); //to add number  
            Debug.Log("blabla: "+numbertext); //to combine
            flag4 = true;
            counter++;
        } 

        if(leverSystem5.boolchecker == true && flag5 == false)
        {
            int number5 = 5;  
            numbertext = numbertext+ number5.ToString(); //to add number  
            Debug.Log("blabla: "+numbertext); //to combine
            flag5 = true;
            counter++;
        } 
    }

}

