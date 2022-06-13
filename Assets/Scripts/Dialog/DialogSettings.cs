using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialog", menuName = "New Dialog / Dialog", order = 1)]
public class DialogSettings : ScriptableObject
{
    [Header("Settings Dialog")]
    public GameObject actor;

    [Header("Dialog")]
    public Sprite speakerSprite;
    public string sentence;

    [NonReorderable]
    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string english;
    public string portuguese;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings ds = (DialogSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        GUILayout.Space(20);
        if(GUILayout.Button("Create Dialog"))
        {
            if(ds.sentence != null)
            {
                ds.dialogues.Add(s);
            }
        }
    }
}

#endif