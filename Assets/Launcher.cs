using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System;


public class Launcher : MonoBehaviour
{

    static string CurrentDir()
    {
        return Directory.GetCurrentDirectory();
    }
    // Use this for initialization
    public static void RunApp(string name)
    {
        //Change OSXEditor to WindowsEditor if you're using windows
        Run(name + ((Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) ? ".app" : ".exe"));
    }

    public static void Run(string name)
    {
        if (name.EndsWith("/")) name = name.Substring(0,name.Length-1);

#if UNITY_STANDALONE_OSX || UNITY_EDITOR // Cut "|| UNITY_EDITOR" if you're using windows
        if (name.EndsWith(".app"))
        {
            name = name + "/Contents/MacOS/";
            string[] nn = Directory.GetFiles(name);
            name = nn[0];
        }
        
        ProcessStartInfo startInfo = new ProcessStartInfo( name);
        startInfo.UseShellExecute = false;
        startInfo.WorkingDirectory = CurrentDir();
        Process.Start(startInfo);

#elif UNITY_STANDALONE_WIN // Paste "|| UNITY_EDITOR" if you're using windows                  
                    
        ProcessStartInfo startInfo = new ProcessStartInfo( name);
        startInfo.UseShellExecute = true;
        startInfo.WorkingDirectory = CurrentDir();
        Process.Start(startInfo);
                                
#else
        Debug.LogError("Sorry, I can't open a file on this platform");
#endif
        GUIUtility.ExitGUI();
    }
}
