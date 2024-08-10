/*
 * All right reserved to Crystallpunk.
 *
 * BUT this file is sublicensed under CLA License for next projects:
 * https://github.com/technologists-team/after-rain
 * https://github.com/EscapeD-14/EscapeD-14
 *
 */

using Content.Shared._CP14.Workbench;

namespace Content.Server._CP14.Workbench;

public sealed partial class CP14WorkbenchSystem
{
    private void OnCraft(Entity<CP14WorkbenchComponent> entity, ref CP14WorkbenchUiCraftMessage args)
    {
        if (!entity.Comp.Recipes.Contains(args.Recipe))
            return;

        if (!_proto.TryIndex(args.Recipe, out var prototype))
            return;

        StartCraft(entity, args.Actor, prototype);
    }

    private void UpdateUIRecipes(Entity<CP14WorkbenchComponent> entity)
    {
        var placedEntities = _lookup.GetEntitiesInRange(Transform(entity).Coordinates, WorkbenchRadius);

        var recipes = new List<CP14WorkbenchUiRecipesEntry>();
        foreach (var recipeId in entity.Comp.Recipes)
        {
            var recipe = _proto.Index(recipeId);
            var entry = new CP14WorkbenchUiRecipesEntry(recipeId, CanCraftRecipe(recipe, placedEntities));

            recipes.Add(entry);
        }

        _userInterface.SetUiState(entity.Owner, CP14WorkbenchUiKey.Key, new CP14WorkbenchUiRecipesState(recipes));
    }
}
