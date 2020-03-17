using System;
using System.IO;

namespace FolderizerLib.Configuration
{
    public class FolderizerConfigurations
    {
        private string _outputPath;
        private string _basePath;
        private uint _maxSearchDepth;
        public static readonly int SearchDepthLimit = 5;

        public string BasePath
        {
            get => _basePath;
            set => _basePath = Directory.Exists(value) ? 
                value : 
                throw new DirectoryNotFoundException("The provided base path leads to an inexistent directory.");
        }
        public string OutputPath
        {
            get => _outputPath is null ? BasePath : _outputPath;
            set => _outputPath = value;
        }
        public OperationMethods OperationMethod { get; set; } = OperationMethods.CopyFiles;

        public uint MaxSearchDepth { 
            get => _maxSearchDepth; 
            set
            {
                if (value > SearchDepthLimit) 
                    throw new SearchDepthExceedsAcceptableLimitException($"The search depth exceeds the acceptable threshold of {SearchDepthLimit} subdirectories.");
                _maxSearchDepth = value;
            } 
        }

        // Methods to be used at once during class instantiation.
        public FolderizerConfigurations SetBasePath(string basePath)
        {
            BasePath = basePath;
            return this;
        }
        public FolderizerConfigurations SetOutputPath(string outputPath)
        {
            OutputPath = outputPath;
            return this;
        }

        public FolderizerConfigurations SetPaths(string basePath, string outputPath)
        {
            BasePath = basePath;
            OutputPath = outputPath;
            return this;
        }

        public FolderizerConfigurations SetOperationMethods(OperationMethods method)
        {
            OperationMethod = method;
            return this;
        }

        public FolderizerConfigurations SetMaxSearchDepth(uint maxDepth)
        {
            MaxSearchDepth = maxDepth;
            return this;
        }

    }
}