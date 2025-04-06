
namespace NfoMetadata.Configuration
{
    public class XbmcMetadataOptions
    {
        public const string ConfigurationKey = "XbmcMetadataEx";

        public string UserIdForUserData { get; set; }

        public string ReleaseDateFormat { get; set; } = "yyyy-MM-dd";

        public bool SaveImagePathsInNfoFiles { get; set; }

        public bool PreferMovieNfo { get; set; }

        public bool DisableSeasonNfo { get; set; }

        public bool DisableEpisodeNfo { get; set; }
    }
}
