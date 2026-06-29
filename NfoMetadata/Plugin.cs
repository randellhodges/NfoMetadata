using System;
using MediaBrowser.Common.Plugins;
using System.IO;
using MediaBrowser.Model.Drawing;
using MediaBrowser.Model.Plugins;
using System.Collections.Generic;
using System.Linq;

namespace NfoMetadata
{
    public class Plugin : BasePlugin, IHasThumbImage, IHasWebPages, IHasTranslations
    {
        public const string SaverName = "Nfo Ex";
        private readonly Guid _id = new Guid("29ab0c5d-1fed-454c-b817-7b1ad5c90391");

        public override Guid Id
        {
            get { return _id; }
        }

        public override string Name
        {
            get { return StaticName; }
        }

        public static string StaticName
        {
            get { return $"Nfo Metadata Ex"; }
        }

        public override string Description
        {
            get
            {
                return $"Nfo metadata support";
            }
        }

        public Stream GetThumbImage()
        {
            var type = GetType();
            return type.Assembly.GetManifestResourceStream(type.Namespace + ".thumb.png");
        }

        public ImageFormat ThumbImageFormat
        {
            get
            {
                return ImageFormat.Png;
            }
        }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = "nfoex",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.nfo.html",
                    MenuSection = "server",
                    MenuIcon = "notes"
                },
                new PluginPageInfo
                {
                    Name = "nfoexjs",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.nfo.js"
                }
            };
        }

        public TranslationInfo[] GetTranslations()
        {
            var basePath = GetType().Namespace + ".strings.";

            return GetType()
                .Assembly
                .GetManifestResourceNames()
                .Where(i => i.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
                .Select(i => new TranslationInfo
                {
                    Locale = Path.GetFileNameWithoutExtension(i.Substring(basePath.Length)),
                    EmbeddedResourcePath = i

                }).ToArray();
        }
    }
}