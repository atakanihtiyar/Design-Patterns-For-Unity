# Singleton

### Create handling
#### 1. If there are no objects<br>
We check this in two different ways. Because if the instance existed before and was destroyed, we can't check with equal operator. We should use equals method.
```c#
if (instance == null || instance.Equals(null))
{
  // assign to instance
}
```

#### 2. If there is an object<br>
```c#
instance = FindObjectOfType<T>();
```

#### 3. If there is more than one object<br>
```c#
if (FindObjectsOfType<T>().Length > 1)
  // Throw exception
```
```c#
if (instance != this as T)
{
  // Destroy this
}
```

#### Extra
If object created manually in scene, awake function handle with multi object. If instance is called init function handle it. <br>
if you want your derived class to be created when the program start, whether there is an object on the scene or not, you can do as follows:
```c#
[RuntimeInitializeOnLoadMethod]
private static void InitOnLoad()
{
  
  Init();
}
```

### Destroy handling
this bool is true only when application quit or if there are multiple objects
```c#
private bool destroyPermission = false;
```
If the destroy command is given, we can't prevent the destroying process. But we can create new instance.
```c#
private void OnDestroy()
{
  if (!destroyPermission)
  {
    instance = null;
    Init();
  }
}
```

Also, both awake and init have DontDestroyOnLoad function. Thus, the object will not be destroyed in the transitions between the scenes.
