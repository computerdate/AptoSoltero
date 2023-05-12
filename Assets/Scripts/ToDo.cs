using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDo
{
    public List<Task> toDoList;
    // Tasks are created when the game starts
    public ToDo() {
        toDoList = new List<Task>();
        toDoList.Add(new Task("Pick food", GameObject.Find("Food"), GameObject.Find("Freezer")));
        toDoList.Add(new Task("Clean", GameObject.Find("Cleaning"), GameObject.Find("Toilet")));
        toDoList.Add(new Task("Turn Stove On", GameObject.Find("Matches"), GameObject.Find("Stove"))); 
    }

}
