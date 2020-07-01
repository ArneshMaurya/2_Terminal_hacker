using UnityEngine;
using System;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    string[] level1Passwords = { "study", "books", "readers", "document", "bookshelf" };
    string[] level2Passwords = { "headquarters", "sheriff", "detectives", "constable", "custody" };

    string[] level3Passwords = { "spaceflight", "satellites", "Astronautical", " extraterrestrial", "geological" };

    string[] level4Passwords = { "political", "conservative", "campaign", "balot", "opposition" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA System");
        Terminal.WriteLine("Press 5 for the MLA Server ");
        Terminal.WriteLine("Feel free to enter menu comeback here!");
        Terminal.WriteLine("Dont press 4     ");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void doExitGame()
    {
        Application.Quit();
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }

    }

    string HintGen(string password)
    {
        int i = 0, len = password.Length;
        var temp = 'a';
        var pass = "";

        for (i = 0; i < len - 1;)
        {
            pass = pass + password[i + 1];
            pass = pass + password[i];
            int v = i + 2;
            i = v;
        }
        if (len % 2 != 0)
            pass = pass + password[len - 1];
        pass = ReverseString(pass);
        return pass;
    }

    string ReverseString(string s)
    {
        Terminal.ClearScreen();
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        string hint = "";
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            case 5:
                password = level4Passwords[UnityEngine.Random.Range(0, level4Passwords.Length)];
                break;
            case 4:
                DiplayWinReward();
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        //hint=HintGen(password);
        if (level != 4)
        {
            Terminal.WriteLine("Hint of password : " + password.Anagram());
            Terminal.WriteLine("Please enter your password: ");
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DiplayWinReward();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }

    void DiplayWinReward()
    {
        Terminal.ClearScreen();
        ShowlvlReward();
    }

    void ShowlvlReward()
    {
        if (level == 1)
        {

            Terminal.WriteLine("Have library View ...");
            Terminal.WriteLine(@"
                _ _
            .-. | | |
            |H|_|e|N|
            |E|C|.|a|<\
            |R|o| |m| \\
            |O|d|X|e|  \\ 
            | |!| | |   \> 
 ");
            Terminal.WriteLine("Enter menu to go MainMenu");
        }
        if (level == 2)
        {

            Terminal.WriteLine("You got a video-game ...");
            Terminal.WriteLine(@"
             ____
            |,--.|
            ||__||
            |+  o| 
            |,'o | 
            `----'     
 ");
            Terminal.WriteLine("Enter menu to go MainMenu");
        }

        if (level == 3)
        {

            Terminal.WriteLine("You into NASA server  ...");
            Terminal.WriteLine(@"
 _  _   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                       
 ");
            Terminal.WriteLine("Enter menu to go MainMenu");
        }

        if (level == 5)
        {

            Terminal.WriteLine("You got Star War Villen ...");
            Terminal.WriteLine(@"                
          __,.__
         /  ||  \
  ::::::| .-'`-. |::::::
  :::::/.'  ||  `,\:::::
  ::::/ |`--'`--'| \::::
  :::/   \`/++\'/   \:::                     
 ");
            Terminal.WriteLine("Enter menu to go MainMenu");
        }

        if (level == 4)
        {

            Terminal.WriteLine(" I said not to press it LOL  ...");
            Terminal.WriteLine(@"
....................../´¯/) 
....................,/¯../ 
.................../..../ 
............./´¯/'...'/´¯¯`·¸ 
........../'/.../..../......./¨¯\ 
........('(...´...´.... ¯~/'...') 
.........\.................'...../ 
..........''...\.......... _.·´ ");
            Terminal.WriteLine("Enter menu to go MainMenu");
        }

    }
    // Update is called once per frame
    void Update()
    {
        //print(Random.Range(0, level2Passwords.Length));
        //print(Random.Range(0, level1Passwords.Length));

    }
}