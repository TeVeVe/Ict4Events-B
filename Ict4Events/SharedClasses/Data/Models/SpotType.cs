using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public enum SpotType
    {
        [EnumDisplayName("Geen eigenschappen")]
        None,

        [EnumDisplayName("Luidruchtig")]
        Loud,

        [EnumDisplayName("Dicht bij de wc")]
        CloseToToilet,

        [EnumDisplayName("Dicht bij het zwembad")]
        CloseToPool
    }
}