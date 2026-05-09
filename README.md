# SkylinesTimer
Generates recurring events in the game [Cities Skylines](https://www.paradoxplaza.com/cities-skylines/). The interval of a `SkylinesTimer` is relevant to game speed. In anouther word, it take the user's game speed (like 1x > / 2x >> / 3x >>>) into account. 
## Using SkylinesTimer
Initializes the singleton of `SkylinesTimeSource` in your `LoadingExtensionBase`:
```C#
public override void OnLevelLoaded(LoadMode mode) {
    // ...
    SkylinesTimeSource.Instance = new SkylinesTimeSource(Singleton<SimulationManager>.instance);
    // ...
}
```
Update `SkylinesTimeSource` in every frame:
```C#
public override void OnBeforeSimulationFrame() {
    base.OnBeforeSimulationFrame();
    if (MyMod.Enabled && Loader.IsInGame) {
        SkylinesTimeSource.Instance.OnFrameUpdate();
    }
}
```
Initializes a new instance of `SkylinesTimer`:
```C#
ISkylinesTimer timer = new SkylinesTimer(SkylinesTimeSource.Instance, 60);
timer.Elapsed += () => { /*...*/ };
timer.Start();
```
## Static Model
![Static Model](https://github.com/bac0id/SkylinesTimer/blob/master/static-model.png)
