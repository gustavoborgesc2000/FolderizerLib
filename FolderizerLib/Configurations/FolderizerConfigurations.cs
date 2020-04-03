using System;
using System.IO;

namespace FolderizerLib.Configuration
{
    public class FolderizerConfigurations
    {
        public static readonly int SearchDepthLimit = 5;
        private string _outputPath;
        private string _basePath;
        private uint _maxSearchDepth;

        // Properties
        public string BasePath
        {
            get => _basePath;
            set => _basePath = Directory.Exists(value) ? value : throw new DirectoryNotFoundException("The provided base path leads to an inexistent directory.");
        }
        public string OutputPath
        {
            get => _outputPath is null ? BasePath : _outputPath;
            set => _outputPath = value;
        }
        public OperationMethod OperationMethod { get; set; } = OperationMethod.CopyFiles;

        public uint MaxSearchDepth { 
            get => _maxSearchDepth; 
            set
            {
                if (value > SearchDepthLimit) 
                    throw new SearchDepthExceedsAcceptableLimitException($"The search depth exceeds the acceptable threshold of {SearchDepthLimit} subdirectories.");
                _maxSearchDepth = value;
            } 
        }


    }
}