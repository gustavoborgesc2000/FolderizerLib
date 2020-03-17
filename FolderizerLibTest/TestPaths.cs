using System;
using System.IO;

namespace FolderizerLibTest.Configuration
{
    /// <summary>
    /// This struct provides valid and invalid directory paths for the execution of unit tests.
    /// </summary>
    public readonly struct TestPaths
    {

        /*  WARNING! 
         *  Before executing any test, make sure to define below the proper location of the test directory.
         *  Make sure that there's no existent directory that is of your use in the path defined in root path,
         *  because it will be used to manipulate folders and execute delete / creation operations.
         *  
         *  Currently, the folder {FolderizerLibTest} will be created under {ProgramFiles} directory.
         *  
         *  Feel free to change the whole root directory path or choose a more proper location by setting other
         *  Environment.SpecialFolder enum value.
         */
        private static string _initialPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        private static string _rootPath = Path.Combine(_initialPath, "FolderizerLibTest"); // FolderizerLibTest will be created in MyMusic.

        /* There's no need to modify the following paths */
        private static string _validBasePath   = Path.Combine(_rootPath, "Folderizer [Valid Base Path]");
        private static string _validOutputPath = Path.Combine(_rootPath, "Folderizer [Valid Output Path]");
        private static string _inexistentDirectoryPath = Path.Combine(_rootPath, "InvalidBasePath - This will never exist");
        /// <summary>
        /// <para>Provides the path of an existent directory, which is defined in this property's respective field.</para>
        /// <para>Before returning the value,
        /// this property's getter creates the directory pointed in it's respective private field, 
        /// if it doesn't exist yet.</para>
        /// </summary>
        public static string ValidBasePath
        {
            get
            {
                Directory.CreateDirectory(_validBasePath);
                return _validBasePath;
            }
        }

        /// <summary>
        /// <para>Provides the path of an existent directory, which is defined in this property's respective field.</para>
        /// <para>Before returning the value,
        /// this property's getter creates the directory pointed in it's respective private field, 
        /// if it doesn't exist yet.</para>
        /// </summary>
        public static string ValidOutputPath
        {
            get
            {
                Directory.CreateDirectory(_validOutputPath);
                return _validOutputPath;
            }
        }

        /// <summary>
        /// <para>Provides the path of an inexistent directory.</para>
        /// </summary>
        public static string NotCreatedDirectory
        {
            get
            {
                if (Directory.Exists(_inexistentDirectoryPath))
                {
                    Directory.Delete(_inexistentDirectoryPath);
                }
                return _inexistentDirectoryPath;
            }
        }
            


    }
}