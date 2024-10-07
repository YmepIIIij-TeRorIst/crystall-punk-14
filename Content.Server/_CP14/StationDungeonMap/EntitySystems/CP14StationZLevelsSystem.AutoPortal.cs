using Content.Server._CP14.StationDungeonMap.Components;
using Content.Server.GameTicking.Events;
using Robust.Shared.Map;

namespace Content.Server._CP14.StationDungeonMap.EntitySystems;

public sealed partial class CP14StationZLevelsSystem
{
    private void AutoPortalInitialize()
    {
        SubscribeLocalEvent<RoundStartingEvent>(OnRoundStart);
        SubscribeLocalEvent<CP14ZLevelAutoPortalComponent, MapInitEvent>(OnPortalMapInit);
    }

    private void OnRoundStart(RoundStartingEvent ev)
    {
        var query = EntityQueryEnumerator<CP14ZLevelAutoPortalComponent>();
        while (query.MoveNext(out var uid, out var portal))
        {
            InitPortal((uid, portal));
        }
    }

    private void OnPortalMapInit(Entity<CP14ZLevelAutoPortalComponent> autoPortal, ref MapInitEvent args)
    {
        InitPortal(autoPortal);
    }

    private void InitPortal(Entity<CP14ZLevelAutoPortalComponent> autoPortal)
    {
        QueueDel(autoPortal);
        //var mapId = Transform(autoPortal).MapUid;
        //if (mapId is null)
        //    return;
//
        //var offsetMap = GetMapOffset(mapId.Value, autoPortal.Comp.ZLevelOffset);
//
        //if (offsetMap is null)
        //    return;
//
        //var currentWorldPos = _transform.GetWorldPosition(autoPortal);
        //var targetMapPos = new MapCoordinates(currentWorldPos, offsetMap.Value);
//
        //var otherSidePortal = Spawn(autoPortal.Comp.OtherSideProto, targetMapPos);
//
        //if (_linkedEntity.TryLink(autoPortal, otherSidePortal, true))
        //    RemComp<CP14ZLevelAutoPortalComponent>(autoPortal);
    }
}
