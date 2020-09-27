# CS-FrameTimer
 Generates recurring events in Cities Skylines.
## Using FrameTimer
Initializes the singleton of `FrameSource` in your `LoadingExtensionBase`:
```C#
public override void OnLevelLoaded(LoadMode mode) {
    // ...
    FrameSource.Instance = new FrameSource(Singleton<SimulationManager>.instance);
    // ...
}
```
Initializes a new instance of `FrameTimer`:
```C#
IFrameTimer frameTimer = new FrameTimer(FrameSource.Instance, 255);
frameTimer.Elapsed += () => { /*...*/ };
frameTimer.Start();
```
## Static Model
![Static Model](https://github.com/bac0id/CS-FrameTimer/blob/master/static-model.png)
