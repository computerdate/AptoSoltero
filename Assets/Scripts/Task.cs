using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name;
    public GameObject prop;
    public GameObject target;
    public bool started;
    public bool done;

    public Task(string name, GameObject prop, GameObject target) {
        this.name = name;
        this.prop = prop;
        this.target = target;
    }

    public void startTask() {
        this.started = true;
    }

    public void finishTask() {
        this.done = true;
    }
}
