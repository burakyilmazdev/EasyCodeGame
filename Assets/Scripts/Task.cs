using System;
using System.Collections;
using TMPro;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public string ID;
    public float amount { get; set; } = 1;
    public Rigidbody body;

    public Task(string ID)
    {
        this.ID = ID;
    }

    public abstract void Func(GameObject mainTarget);
}
public class Jump : Task
{
    public Jump(string ID, int amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    override public void Func(GameObject mainTarget)
    {
        mainTarget.GetComponent<Rigidbody>().AddForce(0, 300*amount, 0);
    }
}

public class MoveUp : Task
{
    public MoveUp(string ID, int amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }
    override public void Func(GameObject mainTarget)
    {
        Vector3 target = mainTarget.transform.position;
        target.z = target.z + amount;

        LeanTween.moveZ(mainTarget, target.z, 1);
        
       
    }

}

public class MoveDown : Task
{
    public MoveDown(string ID, int amount) : base(ID)
    {
 
        this.ID = ID;
        this.amount = amount;

    }

    override public void Func(GameObject mainTarget)
    {
        Vector3 target = mainTarget.transform.position;
        target.z = target.z - amount;

        LeanTween.moveZ(mainTarget, target.z, 1);
    }
}

public class MoveRight : Task
{
    public MoveRight(string ID, int amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    override public void Func(GameObject mainTarget)
    {
        Vector3 target = mainTarget.transform.position;
        target.x = target.x + amount;

        LeanTween.moveX(mainTarget, target.x, 1);
        
    }
}
public class MoveLeft : Task
{
    public MoveLeft(string ID, int amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    override public void Func(GameObject mainTarget)
    {
        Vector3 target = mainTarget.transform.position;
        target.x = target.x - amount;

        LeanTween.moveX(mainTarget, target.x, 1);
    }
}

public class ChangeColor : Task
{
    public Color color;
    public ChangeColor(string ID, Color color) : base(ID)
    {
        this.color = color;
    }

    override public void Func(GameObject mainTarget)
    {
        mainTarget.GetComponent<Renderer>().material.color = color;
    }
}

public class RotateLeft : Task
{

    public RotateLeft(string ID, int amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    override public void Func(GameObject mainTarget)
    {
        Vector3 target = mainTarget.transform.rotation.eulerAngles;
        target.y = target.y - amount;
        LeanTween.rotateY(mainTarget, target.y, 1);

    }

}

public class RotateRight : Task
{

    public RotateRight(string ID,int amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    override public void Func(GameObject mainTarget)
    {
        Vector3 target = mainTarget.transform.rotation.eulerAngles;
        target.y = target.y + amount;
        LeanTween.rotateY(mainTarget, target.y, 1);

        

    }

}

public class MakeBigger : Task
{
    Vector3 temp;
    public MakeBigger(string ID,float amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    public override void Func(GameObject mainTarget)
    {
        temp = mainTarget.GetComponent<Rigidbody>().transform.localScale;
        body = mainTarget.GetComponent<Rigidbody>();

        
        temp.x = temp.x * amount;
        temp.y = temp.y * amount;
        temp.z = temp.z * amount;
        LeanTween.scale(mainTarget, temp, 1);
        body.isKinematic = false;
        
    }



}

public class MakeSmaller : Task
{
    Vector3 temp;
    public MakeSmaller(string ID,float amount) : base(ID)
    {
        this.ID = ID;
        this.amount = amount;
    }

    public override void Func(GameObject mainTarget)
    {
        temp = mainTarget.GetComponent<Rigidbody>().transform.localScale;
        temp.x = temp.x / amount;
        temp.y = temp.y / amount;
        temp.z = temp.z / amount;
        LeanTween.scale(mainTarget, temp, 1);
    }



}


