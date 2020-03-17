using FolderizerLib.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolderizerLib.AudioFolderizer
{
    /// <summary>
    /// Provides an interface for <i>folderizer classes</i> that handle audio files.
    /// </summary>
    public interface IAudioFolderizer : IFolderizer
    {
        void SetOrganizationSequence(params AudioTags[] tags);
    }
}
