using System;

namespace Mutagen.Bethesda
{
    public static partial class GameCategoryHelper
    {
        public static GameCategory FromModType<TMod>()
            where TMod : IModGetter
        {
            switch (typeof(TMod).Name)
            {
                case "IOblivionMod":
                case "IOblivionModGetter":
                    return GameCategory.Oblivion;
                case "ISkyrimMod":
                case "ISkyrimModGetter":
                    return GameCategory.Skyrim;
                case "IFallout4Mod":
                case "IFallout4ModGetter":
                    return GameCategory.Fallout4;
                default:
                {
                    throw new ArgumentException($"Unknown game type for: {typeof(TMod).Name}");
                }
            }
        }
    }
}
