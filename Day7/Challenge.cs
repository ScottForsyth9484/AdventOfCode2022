using BaseSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySeven
{
    //1151922 - too low
    //1154757 - too low
    public class Challenge : IChallenge3
    {
        readonly List<DirectoryRecord> _directories = new List<DirectoryRecord>();
            string _currentDir = "";
        string _currentPath = "";
        public long PartOne(string data)
        {
            string[] inputs = data.Split(Environment.NewLine);
            

            foreach (var input in inputs)
            {
                switch (input.Substring(0,3))
                {
                    case "$ c": ChangeDirectory(input); break;
                    case "$ l": break;
                    default: AddRecord(input); break;
                }
            }

            foreach(var dir in _directories.Where(m=>m.RecordType == RecordType.Directory).OrderByDescending(m=>m.Path.Length).ToList())
            {
                dir.Size = _directories.Where(m => m.Path.StartsWith(dir.Path) && m.RecordType == RecordType.File).Sum(m => m.Size);
            }

            _directories.ForEach(m => Console.WriteLine(m.ToString()));
            //return _directories.Where(m => m.RecordType == RecordType.File).Sum(m => m.Size);

            return _directories.Where(m=>m.RecordType == RecordType.Directory && m.Size <= 100000).Sum(m => m.Size);


        }

        public long PartTwo(string data)
        {
            if (!_directories.Any())
            {
                string[] inputs = data.Split(Environment.NewLine);


                foreach (var input in inputs)
                {
                    switch (input.Substring(0, 3))
                    {
                        case "$ c": ChangeDirectory(input); break;
                        case "$ l": break;
                        default: AddRecord(input); break;
                    }
                }

                foreach (var dir in _directories.Where(m => m.RecordType == RecordType.Directory).OrderByDescending(m => m.Path.Length).ToList())
                {
                    dir.Size = _directories.Where(m => m.Path.StartsWith(dir.Path) && m.RecordType == RecordType.File).Sum(m => m.Size);
                }
            }

            long maxSpace = 70000000;
            long minSpace = 30000000;
            long curSpace = _directories.First(m => m.RecordType == RecordType.Directory && m.Name == "//").Size;
            long availSpace = maxSpace - curSpace;
            long spaceRequired = minSpace - availSpace;


            return _directories.Where(m=>m.RecordType == RecordType.Directory && m.Size >= spaceRequired).Min(m=>m.Size);
        }

        void AddRecord(string input)
        {
            DirectoryRecord record;
           // string currentPath = _directories.FirstOrDefault(m => m.Name == _currentDir)?.Path;
            string[] inputParts = input.Split(" ");
            string path = string.Join('/', _currentDir, inputParts[1]);
            if (input.StartsWith("dir"))
            {
                record = new DirectoryRecord(RecordType.Directory,0,path,path);
            }
            else {
                record = new DirectoryRecord(RecordType.File, long.Parse(inputParts[0]), inputParts[1], path);
            }

            _directories.Add(record);
           
        }

        void ChangeDirectory(string input)
        {
            string[] data = input.Split(" ");
            if (data[2] == "..")
            {
                //var currentPath = _directories.First(m => m.Name == _currentDir).Path;
                var newPath = TraverseUpPath(_currentDir);
                if (newPath == "/")
                {
                    newPath = "//";
                }
                _currentDir = _directories.First(m => m.Path == newPath).Path;
            }
            else
            {
                var path = string.Join('/', _currentDir, data[2]);
                DirectoryRecord dir = _directories.FirstOrDefault(m => m.Name == path);
                if (dir == null)
                {
                    dir = new DirectoryRecord(RecordType.Directory, 0, string.Join('/', _currentDir, data[2]), string.Join('/', _currentDir, data[2]));
                    _directories.Add(dir);
                }
                _currentDir = dir.Path;// data[2];
            }
        }
         
        string TraverseUpPath(string path)
        {
            string[] parts = path.Split("/");
            return string.Join('/', parts.Take(parts.Length - 1));
        }
        
    }

    public enum RecordType
    {
        Directory,
        File
    }

    public class DirectoryRecord
    {
        public DirectoryRecord(RecordType recordType, long size, string name, string path)
        {
            Size = size;
            Name = name;
            RecordType = recordType;
            Path = path;
        }
        public RecordType RecordType { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return $"{RecordType},{Name},{Path},{Size}";
        }
    }
}
