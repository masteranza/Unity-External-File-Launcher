using UnityEngine;
using System.Collections;

public class ExampleGUI : MonoBehaviour {

    void OnGUI()
    {
        if (GUILayout.Button("Open Option 1"))
        {
            Launcher.RunApp("option1");
        }

        if (GUILayout.Button("Open Option 2"))
        {
            Launcher.RunApp("option2");
        }
    }
}
