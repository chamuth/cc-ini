using System;
using System.Collections.Generic;
using System.IO;

namespace Ninponix
{

    public class INI
    {
        private string _filename = "";
        private Dictionary<string, string> _configurations = new Dictionary<string, string>();

        /// <summary>
        /// Contains all of the Configurations as KeyValuePairs
        /// </summary>
        public Dictionary<string, string> Configurations
        {
            get
            {
                return _configurations;
            }

            set
            {
                _configurations = value;
            }
        }

        public bool Add(string _key, string _value)
        {
            try
            {
                Configurations.Add(_key, _value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Creates a new INI instance from an existing file or creates a new file.
        /// </summary>
        /// <param name="filename">Path to the Ini File</param>
        public INI(string filename)
        {
            _filename = filename;

            if (File.Exists(_filename))
            {
                using (var sr = new StreamReader(_filename))
                {
                    var content = sr.ReadToEnd().Replace("\r", "\n");
                    var lines = content.Split('\n');

                    foreach (var line in lines)
                    {
                        if (!line.TrimStart().StartsWith(";") && line.Trim().Contains("="))
                        {
                            var key = line.Split('=')[0];
                            var value = line.Split('=')[1];

                            Configurations.Add(key, value);
                        }
                    }
                }
            }
            else
            {
                File.Create(_filename).Close();
            }
        }

        /// <summary>
        /// Saves changes to the INI File.
        /// </summary>
        /// <returns>Returns true on success</returns>
        public bool Save()
        {
            try
            {
                using (var sw = new StreamWriter(_filename))
                {
                    foreach (var keyvalPair in Configurations)
                    {
                        sw.WriteLine(keyvalPair.Key + "=" + keyvalPair.Value);
                    }

                    return true;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }


    }
}
