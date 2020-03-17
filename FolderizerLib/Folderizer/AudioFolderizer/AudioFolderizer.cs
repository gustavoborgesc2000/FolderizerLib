using FolderizerLib.Configuration;
using FolderizerLib.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolderizerLib.AudioFolderizer
{
    public class AudioFolderizer : IAudioFolderizer
    {
        private FolderizerConfigurations Configuration { get; set; }
        private AudioTags[] TagsSequence { get; set; }

        public AudioFolderizer(FolderizerConfigurations configuration)
        {
            Configuration = configuration;
        }

        public void SetOrganizationSequence(params AudioTags[] tags)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void GenerateTreeView()
        {
            throw new NotImplementedException();
        }
    }
}
