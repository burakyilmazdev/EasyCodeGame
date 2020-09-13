
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//#Visual Block Coding:
// drag and drop from (https://github.com/danielcmcg/Unity-UI-Nested-Drag-and-Drop) functinos to the desired positions
// on the main loop of the object


public class Controller : MonoBehaviour
{
    enum PlayStatus {DEFAULT = 0, NOT_PLAYING, PLAYING}

    //public delegate void FuntionsList(int amount);
    List<Task> tasks;

    public GameObject mainTarget;
    private PlayStatus playStatus; 
    MainLoop mainLoop;
    Vector3 defaultPos;
    Color defColor;


    public void Play()
    {
        tasks.Clear();
        tasks = TranslateCodeFromBlocks(transform.parent, tasks);
        
        mainLoop = new MainLoop(mainTarget, tasks);
        StartCoroutine(mainLoop.Play());

        playStatus = PlayStatus.PLAYING; 
    }

    public void Stop()
    {
        playStatus = PlayStatus.NOT_PLAYING;
        mainTarget.transform.position = defaultPos;
        mainTarget.GetComponent<Renderer>().material.color= defColor;
    }

    void Start()
    {
        playStatus  = PlayStatus.DEFAULT; 
        tasks = new List<Task>();
        defaultPos = mainTarget.transform.position;
        defColor = mainTarget.GetComponent<Renderer>().material.color;
    }
    
    void Update()
    {
        if (playStatus.Equals(PlayStatus.PLAYING)) //play
        {
            //mainLoop.infiniteLoop = transform.GetChild(1).GetComponent<Toggle>().isOn;
            if (mainLoop.infiniteLoop && mainLoop.end)
                StartCoroutine(mainLoop.Play());
        }
        if (playStatus.Equals(PlayStatus.NOT_PLAYING)) //stop
            StopCoroutine(mainLoop.Play());
    }
    
    //recursive parser function
    private List<Task> TranslateCodeFromBlocks(Transform parent, List<Task> tasks)
    {
        TextMeshProUGUI code = GameObject.Find("Canvas/Code/Text").GetComponent<TextMeshProUGUI>();
        foreach (Transform child in parent)
        {
            var taskName = child.name.Split('_');

            var current = child;
            if (current.GetComponent<Text>() != null)

            if (taskName[0].Equals("Function"))
            {
                string function = taskName[1];
                int amount = 1;
                switch (function)
                {
                    case "MakeSmaller":
                            amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                            tasks.Add(new MakeSmaller("MakeSmaller",amount));
                            code.text =
                                "car.Scale.x=car.Scale.x/" + amount + ";\n" +
                                "car.Scale.y=car.Scale.y/" + amount + ";\n" +
                                "car.Scale.z=car.Scale.z/" + amount + ";";
                        break;

                    case "MakeBigger":
                            amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                            tasks.Add(new MakeBigger("MakeBigger",amount));
                            code.text = 
                                "car.Scale.x=car.Scale.x*" + amount + ";\n" +
                                "car.Scale.y=car.Scale.y*" + amount + ";\n" +
                                "car.Scale.z=car.Scale.z*" + amount + ";";
                            break;

                    case "RotateRight":
                            amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                            tasks.Add(new RotateRight("RotateRight", amount));
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.rotation.y = car.rotation.y+1;\n}";
                            break;

                    case "RotateLeft":
                        amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                        tasks.Add(new RotateLeft("RotateLeft", amount));
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.rotation.y = car.rotation.y-1;\n}";
                            break;

                    case "MoveRight":
                        amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                        tasks.Add(new MoveRight("MoveRight", amount));
                            
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.position.x = car.position.x+1;\n}";
                            break;
                    case "MoveLeft":
                            amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                            tasks.Add(new MoveLeft("MoveLeft", amount));
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.position.x = car.position.x-1;\n}";
                            break;
                    case "MoveUp":
                        amount= int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                        tasks.Add(new MoveUp("MoveUp", amount));
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.position.z = car.position.z+1;\n}";
                            break;
                    case "MoveDown":
                        amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                        tasks.Add(new MoveDown("MoveDown",amount));
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.position.z = car.position.z-1;\n}";
                            break;
                    case "Jump":
                        amount = int.TryParse(current.GetChild(0).GetComponent<InputField>().text, out amount) ? amount : 1;
                        tasks.Add(new Jump("Jump", amount));
                            code.text = "for(int i=0;i<" + amount + ";i++)\n" +
                                "{car.position.y = car.position.y+1;\n}";
                            break;
                }
            }
        }
        return tasks;
    }

   
}

public class MainLoop
{
    GameObject mainTarget;
    private List<Task> tasks;
    public bool infiniteLoop;
    public bool end;
    private float waitTime;

    public MainLoop(GameObject target, List<Task> tasks)
    {
        this.end = false;
        this.mainTarget = target;
        this.tasks = tasks;
        this.waitTime = 0.5f; //wait time between functions in tasks (list)
    }
    public IEnumerator Play()
    {
        this.end = false;
        foreach (Task task in tasks)
        {
            task.Func(mainTarget);
            yield return new WaitForSeconds(waitTime);
        }
        this.end = true;
    }
}
