using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBars : MonoBehaviour
{
    
    [SerializeField] private GameObject H7;
    [SerializeField] private GameObject H6;
    [SerializeField] private GameObject H5;
    [SerializeField] private GameObject H4;
    [SerializeField] private GameObject H3;
    [SerializeField] private GameObject H2;
    [SerializeField] private GameObject H1;
    
    [SerializeField] private GameObject M7;
    [SerializeField] private GameObject M6;
    [SerializeField] private GameObject M5;
    [SerializeField] private GameObject M4;
    [SerializeField] private GameObject M3;
    [SerializeField] private GameObject M2;
    [SerializeField] private GameObject M1;

    [SerializeField] private GameObject Sign1;
    [SerializeField] private GameObject Sign2;
    [SerializeField] private GameObject Sign3;
    [SerializeField] private GameObject Sign4;
    [SerializeField] private GameObject Sign5;
    [SerializeField] private GameObject UISword;
    [SerializeField] private GameObject UIWand;
    [SerializeField] private CharMovement CharMovement;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      print(CharMovement.life+ "life");
         switch (CharMovement.life)
         {
         case 7:
            H1.SetActive(false);
            H2.SetActive(false);
            H3.SetActive(false);
            H4.SetActive(false);
            H5.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(true);
print(CharMovement.life+ "case");
            break;
         case 6:
            H1.SetActive(false);
            H2.SetActive(false);
            H3.SetActive(false);
            H4.SetActive(false);
            H5.SetActive(false);
            H7.SetActive(false);
            H6.SetActive(true);
            print(CharMovement.life+ "case");
            break;
         case 5:
            H1.SetActive(false);
            H2.SetActive(false);
            H3.SetActive(false);
            H4.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(false);
            H5.SetActive(true);
            print(CharMovement.life+ "case");
            break;
         case 4:
            H1.SetActive(false);
            H2.SetActive(false);
            H3.SetActive(false);
            H5.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(false);
            H4.SetActive(true);
            print(CharMovement.life+ "case");
            break;
         case 3:
            H1.SetActive(false);
            H2.SetActive(false);
            H5.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(false);
            H4.SetActive(false);
            H3.SetActive(true);
            print(CharMovement.life+ "case");
            break;
         case 2:
            H1.SetActive(false);
            H3.SetActive(false);
            H4.SetActive(false);
            H5.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(false);
            H2.SetActive(true);
            print(CharMovement.life+ "case");
            break;
         case 1:
            
            H2.SetActive(false);
            H3.SetActive(false);
            H4.SetActive(false);
            H5.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(false);
            H1.SetActive(true);
            print(CharMovement.life+ "case");
            //reproducir animacion
            break;
         case 0:
            
            H2.SetActive(false);
            H3.SetActive(false);
            H4.SetActive(false);
            H5.SetActive(false);
            H6.SetActive(false);
            H7.SetActive(false);
            H1.SetActive(false);
            print(CharMovement.life+ "case");
            break;
         default:
            break;
        }

        switch (CharMovement.magic)
         {
         case 7:
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            M5.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(true);

            break;
         case 6:
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            M5.SetActive(false);
            M7.SetActive(false);
            M6.SetActive(true);
            break;
         case 5:
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(false);
            M5.SetActive(true);
            break;
         case 4:
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M5.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(false);
            M4.SetActive(true);
            break;
         case 3:
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M5.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(false);
            M4.SetActive(false);
            M3.SetActive(true);
            break;
         case 2:
            M1.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            M5.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(false);
            M2.SetActive(true);
            break;
         case 1:
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            M5.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(false);
            M1.SetActive(true);
            //reproducir animacion
            break;
         case 0:
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            M5.SetActive(false);
            M6.SetActive(false);
            M7.SetActive(false);
            M1.SetActive(false);
            break;
         default:
            break;
        }
    }
}
