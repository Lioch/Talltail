using UnityEngine;
using System.IO;

public class RuntimeText : MonoBehaviour
{
    public static void WriteString(string strNewText)
    {
        string path = Application.persistentDataPath + "/questionnaire_results.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(strNewText);
        writer.Close();
        StreamReader reader = new StreamReader(path);

        //Print the text from the file
        Debug.Log($"Exported the string to {path}");
        Debug.Log(reader.ReadToEnd());
        reader.Close();

    }

    public static void ReadString()
    {
        string path = Application.persistentDataPath + "/questionnaire_results.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}

