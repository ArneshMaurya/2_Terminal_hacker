    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class Hacker1 : MonoBehaviour
    {   
        // Start is called before the first frame update

        string[] esyAr = {"united","similar","liquid","cheques","adequate"};
        string[] midAr = {"incomparable","banquet","swaraj","encourage","extension"};
        string[] hardAr = {"harmonious","conventional","antithetic","acquisitivenesses","quantifications"};
        
        int ran_num = 3;
        
        string pass="";

        void Start()
        {
            print("Hello Hero");
            Terminal.WriteLine("Cool now i am there");
            ShowMenu();
               
        }

      string ReverseString(string s)
        {   Terminal.ClearScreen();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    
        void OnUserInput(string inp){
            
            if(inp=="menu")
            {   
                ShowMenu();
            }
            else if(inp=="007"){
                Terminal.WriteLine("Mr Bond select the correct the level !!");
                ShowMenu();
            }else if(inp == "1"){
                StartLevel(1);
            }else if(inp == "2"){
                StartLevel(2);
            }else{

                if(inp==esyAr[ran_num] || inp == midAr[ran_num]){
                    Terminal.WriteLine("You hacked the system !!");

                }else{
                    Terminal.WriteLine("Wronng passWord try again !! ");
                    //ShowMenu();
                
                }
                
            }
        }

    string HintGen(string password){
        
        int i=0,len=password.Length;
                var temp='a';
                var pass="";
                
                for(i=0;i<len-1;){
                    pass=pass+password[i+1];
                    pass=pass+password[i];
                    int v = i + 2;
                    i = v;
                }
                if(len%2!=0)
                pass=pass+password[len-1];
                pass=ReverseString(pass);
                return pass;
    }

    void StartLevel(int lvl){
            
            
            //Random rand = new Random();
            //int ran_num = rand.Next(5); 

        if(lvl==1)
            {
                Terminal.ClearScreen();
                //call
                string pass=HintGen(esyAr[ran_num]);
                Terminal.ClearScreen();
                Terminal.WriteLine("You are at the "+lvl+" level [local Library]");
                Terminal.WriteLine("Enter the password : \t\t Hint:"+pass+" "+ran_num);
            }
            if(lvl==2)
            {
                Terminal.ClearScreen();
                int i=0,len=midAr[ran_num].Length;
                var temp='a';
                var pass="";
                
                for(i=0;i<len-1;){
                    pass=pass+midAr[ran_num][i+1];
                    pass=pass+midAr[ran_num][i];
                    int v = i + 2;
                    i = v;
                }
                if(len%2!=0)
                pass=pass+midAr[ran_num][len-1];
                pass=ReverseString(pass);
                Terminal.ClearScreen();
                Terminal.WriteLine("You are at the "+lvl+" level [Police Station]");
                Terminal.WriteLine("Enter the password : \t\t Hint:"+pass+" "+ran_num);
            }
        }
        
        void winGame(){
            
        }

        void ShowMenu(){
            var rangeCalc = new System.Random();
            ran_num=rangeCalc.Next(5);
            Terminal.WriteLine("What would you like to hack into?");
            Terminal.WriteLine("Press 1 for the local Library");
            Terminal.WriteLine("Press 2 for the Police Station");
            Terminal.WriteLine("Enter your option : ");
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
