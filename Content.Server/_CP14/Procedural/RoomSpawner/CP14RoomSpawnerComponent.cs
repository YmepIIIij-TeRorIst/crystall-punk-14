using Content.Shared.Random;
using Robust.Shared.Prototypes;

namespace Content.Server._CP14.Procedural.RoomSpawner;

/// <summary>
/// allows you to spawn one of the rooms during initialization
/// </summary>
[RegisterComponent, Access(typeof(CP14RoomSpawnerSystem))]
public sealed partial class CP14RoomSpawnerComponent : Component
{
    [DataField(required: true)]
    public ProtoId<WeightedRandomPrototype> RoomsRandom = new();

    [DataField]
    public bool Rotation = true;

    [DataField]
    public bool ClearExisting = true;

    [DataField]
    public List<string> IgnoreTiles = new()
    {
        "CP14FloorAtlasMask",
        "CP14FloorAtlasMask2",
    };
}
