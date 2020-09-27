# CS-FrameTimer
 Generates recurring events in [Cities Skylines](https://www.paradoxplaza.com/cities-skylines/).
## Using FrameTimer
Initializes the singleton of `FrameSource` in your `LoadingExtensionBase`:
```C#
public override void OnLevelLoaded(LoadMode mode) {
    // ...
    FrameSource.Instance = new FrameSource(Singleton<SimulationManager>.instance);
    // ...
}
```
Update `FrameSource` in every frame:
```C#
public override void OnBeforeSimulationFrame() {
    base.OnBeforeSimulationFrame();
    if (MyMod.Enabled && Loader.IsInGame) {
        FrameSource.Instance.Notify();
    }
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
