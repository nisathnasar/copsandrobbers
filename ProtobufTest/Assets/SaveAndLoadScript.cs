using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;

public class SaveAndLoadScript : MonoBehaviour
{
    public Persons MyGroup;
    public string File1Path;


    private void Start()
    {
        if (!ProtoBuf.Meta.RuntimeTypeModel.Default.IsDefined(typeof(Vector3)))
        {
            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(Vector3), false).Add("x", "y", "z");
        }


    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 100), "Load File 1")) 
        {
            if (string.IsNullOrEmpty(File1Path))
            {
                Debug.LogError("Path is empty.");
                return;
            }

            if (!File.Exists(File1Path))
            {
                Debug.LogError("file does not exist");
                return;
            }

            MyGroup = Serializer.Deserialize<Persons>(new FileStream(File1Path, FileMode.Open, FileAccess.Read));
        }

        if(GUI.Button(new Rect(10, 120, 200, 100), "Save File 1"))
        {
            if (string.IsNullOrEmpty(File1Path))
            {
                Debug.LogError("path is empty");
                return;
            }

            if (MyGroup == null)
            {
                Debug.LogError("Value is null");
                return;
            }

            using (FileStream Stream = new FileStream(File1Path, FileMode.Create, FileAccess.Write))
            {
                Serializer.Serialize<Persons>(Stream, MyGroup);

                Stream.Flush();
            }

        }
        
    }
}
