using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Microsoft.ML.OnnxRuntimeGenAI;
using UnityEngine.UI;
using System.Threading;
using System.Linq.Expressions;



public class Test : MonoBehaviour
{
    public Text __promt;
    public Button _button;
    public Text output;
    // Start is called before the first frame update
    [SerializeField]
    static string _modelpath = Path.Combine(Application.streamingAssetsPath, "cpu");

    static string android_dir = "jar:file://" + "!/assets" + "/StreamingAsset/cpu";



    static Model __model = new Model(_modelpath);
    static Tokenizer __tokenizer = new Tokenizer(__model);

    void Start()
    {
        Console.WriteLine("Hello, World!");
        Debug.Log(_modelpath);
        if (File.Exists(_modelpath))
        { Debug.Log("Model founded"); }
        else
        {
            Debug.Log("Model has not been found");
        }
        Console.WriteLine("Intializing model.");
        Debug.Log("loading the model");

        Debug.Log("Model loaded successfully.");
        Debug.Log("Enter your question(type 'exit' to quit");
        Console.WriteLine("Enter your question (type 'exit' to quit):");
        Button btn = _button.GetComponent<Button>();
        btn.onClick.AddListener(inference);
    }
    private void inference()
    {


        // Debug.Log("method is called");
        if (!IsInvoking())
        {
            Debug.Log("Thinking...");
            string question = __promt.text.ToString();
            if (question.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("exit");
            }
            try
            {
                string prompt = $"if the question is: {question}, the full answer will be:";
                var sequences = __tokenizer.Encode(prompt);
                using var generatorParams = new GeneratorParams(__model);
                generatorParams.SetSearchOption("max_length", 200);
                generatorParams.SetInputSequences(sequences);
                var outputSequences = __model.Generate(generatorParams);
                string outputString = __tokenizer.Decode(outputSequences[0]);
                int index = outputString.IndexOf("the full answer will be:", StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    outputString = outputString.Substring(index + 24).Trim(); // Trim to remove any leading whitespace
                }
                output.text = outputString;
                Debug.Log("promt generated");

                // Console.WriteLine(outputString);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }

        }
    }
}
