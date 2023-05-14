using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDo
{
    public List<Task> toDoList;
    //private PlayerDetector playerDetector;
    // Tasks are created when the game starts
    public ToDo() {
        toDoList = new List<Task>();
        toDoList.Add(new Task("Pick food", GameObject.Find("Food"), GameObject.Find("Freezer")));
        toDoList.Add(new Task("Clean", GameObject.Find("Cleaning"), GameObject.Find("Toilet")));
        toDoList.Add(new Task("Turn Stove On", GameObject.Find("Matches"), GameObject.Find("Stove"))); 
    }

    public void startTaskByProp(GameObject element) {
        foreach (Task task in toDoList) {
            if (task.prop == element) {
                task.startTask();
            }
        }
    }

    public void finishTaskByProp(GameObject element) {
        foreach (Task task in toDoList) {
            if (task.prop == element) {
                task.finishTask();
            }
        }
    }    
    public Task findTaskByProp(GameObject element) {
        Task foundTask = null;
        foreach(Task task in toDoList) {
            if(task.prop == element) {
                foundTask = task;
            }
        }
        return foundTask;        
    }

    public Task findTaskByAppliance(GameObject element) {
        Task foundTask = null;
        foreach(Task task in toDoList) {
            if(task.target == element) {
                foundTask = task;
            }
        }
        return foundTask;        
    }
/*     public void verifyTask(GameObject prop, GameObject appliance) {
        if (findTaskByProp(prop) == findTaskByAppliance(appliance)) {
            Debug.Log("Task completed!");
            //playerDetector.destroyObject(prop);
            PlayerDetector playerDetector = prop.GetComponent<PlayerDetector>();
            playerDetector.detachedFromPlayer();
            playerDetector.destroyObject();
            verifyToDoListComplete();
        } else {
            Debug.Log("Task failed");
        }
    } */

    public bool verifyTask(GameObject prop, GameObject appliance) {
        bool isTaskCompleted = false;
        if (findTaskByProp(prop) == findTaskByAppliance(appliance)) {
            Debug.Log("Task completed!");
            isTaskCompleted = true;
            findTaskByProp(prop).finishTask();
        } else {
            Debug.Log("Task failed");
            isTaskCompleted = false;
        }
        return isTaskCompleted;
    }    

    public bool verifyToDoListComplete() {
        bool isWorkFinished = true;
        foreach(Task task in toDoList) {
            if (task.done == false) {
                isWorkFinished = false;
            }
        }
        return isWorkFinished;
    }

}
