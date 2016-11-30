using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyScrollView : EditorWindow
{

    Vector2 scrollPos;
    string t = "This is a string inside a Scroll view!";

    [MenuItem("Examples/Modify internal Quaternion cs")]
    static void Init()
    {
        MyScrollView window = (MyScrollView)EditorWindow.GetWindow(typeof(MyScrollView), true, "My Empty Window");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        scrollPos =
        EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(100), GUILayout.Height(100));
        GUILayout.Label(t);
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("Add More Text", GUILayout.Width(100), GUILayout.Height(100)))
            t += " \nAnd this is more text!";
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Clear"))
            t = "";
    }
}