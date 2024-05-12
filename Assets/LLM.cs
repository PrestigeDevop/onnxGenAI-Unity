
using UnityEngine;
using Microsoft.SemanticKernel;
using UnityEngine.UI;
using unity.SemanticKernel.Connectors.OnnxRuntimeGenAI;
using Microsoft.SemanticKernel.ChatCompletion;
using System;
using System.Reflection;
using log4net;
using UnityEngine.Windows;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO;
using Microsoft.Extensions.DependencyInjection;





public class LLM : MonoBehaviour
{
    //[SerializeField]
    //Text _prompt;
    [SerializeField]
    Button Send;
    //string resources = Application.streamingAssetsPath;
    ////static string modelPath = Path.Combine(Directory.GetCurrentDirectory(), "phi-2");
    //static string modelPath = "E:onnxGen//Phi-3-mini-4k-instruct-onnx//cpu_and_mobile//cpu//phi3-mini-4k-instruct-cpu-int4-rtn-block-32.onnx";
    //static Model model = new Model(modelPath);
    //Tokenizer tokenizer = new Tokenizer(model);
    //GeneratorParams generatorParams = new GeneratorParams(model);
     
    // Start is called before the first frame update
    //Kernel _kernel = Kernel.CreateBuilder().Build();
    public string respond = "";
     static string modelfolder = Path.Combine(Application.streamingAssetsPath, "cpu");

    private void Awake()
    {
        //scafold 


        Assembly assembly;
        // Assembly.Load(typeof(OnnxRuntimeGenAIChatCompletionService).Assembly);
        //assembly = Assembly.Load("unity.SemanticKernel.Connectors.OnnxRuntimeGenAI.dll");
        if (System.IO.File.Exists("Assets/SKSDK/unity.SemanticKernel.Connectors.OnnxRuntimeGenAI.dll"))
        {
            Debug.Log("dll is located");}
        else
        {
            Debug.Log("wrong dll path");
        }


        // Debug.Log(assembly.Location);
        // Debug.Log(assembly.GetReferencedAssemblies());
        // Debug.Log(assembly.ImageRuntimeVersion);
        //// AssemblyInfo.TargetFrameworkVersion
        // Debug.Log(assembly.FullName);   
    }
    public async void  chater()
    {

        Kernel kernel = Kernel.CreateBuilder()
            .Services.AddOnnxRuntimeGenAIChatCompletion(modelfolder).AddKernel().Build();
            
        kernel.Services.GetRequiredService<OnnxRuntimeGenAIChatCompletionService>();

        string prompt = @"Write a joke";

        await foreach (string text in kernel.InvokePromptStreamingAsync<string>(prompt,
                           new KernelArguments(new OnnxRuntimeGenAIPromptExecutionSettings() { MaxLength = 2048 })))
        {
            Console.Write(text);
        }

        
        

        //if (kernel != null)
        //{
        //    unity.SemanticKernel.Connectors.chatcompletion.OnnxRuntimeGenAIChatCompletionService _inference ;

        //    _inference = kernel.GetRequiredService<unity.SemanticKernel.Connectors.chatcompletion.OnnxRuntimeGenAIChatCompletionService>();
        //    ChatHistory chat = new("You are an AI assistant that helps people find information.");
        //    string input = @"what day is it today";

        //    if (IsInvoking())
        //    {


        //    }
        //}
    }

    

    void Start()
        {
             chater();
            //var result = this._kernel.Plugins;
            // Debug.Log(result);

            string prompt = @$"Create a list of helpful phrases and 
    words in $ a traveler would find useful.";


            //Debug.Log("Hello world");
            //string prompt = _prompt.text;
            //var sequences = tokenizer.Encode(prompt);
            //generatorParams.SetSearchOption("max_length", 200);
            //generatorParams.SetInputSequences(sequences);
            //// 1
            //var outputSequences = model.Generate(generatorParams);
            //var outputString = tokenizer.Decode(outputSequences[0]);
            //Console.WriteLine("Output:");
            //Console.WriteLine(outputString);
            //using var tokenizerStream = tokenizer.CreateStream();
            //using var generator = new Generator(model, generatorParams);
            //while (!generator.IsDone())
            //{
            //    generator.ComputeLogits();
            //    generator.GenerateNextToken();
            //    Console.Write(tokenizerStream.Decode(generator.GetSequence(0)[^1]));
            //}

            //Button btn = Send.GetComponent<Button>();
            //btn.onClick.AddListener(Chat);
        }


     public  async  void Chat()
        {
            Debug.Log("Pressed");
             

    }
        // Update is called once per frame
        void Update()
        {

        }

 
}


