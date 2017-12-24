using System;
using System.Collections.Generic;
using System.IO;

namespace ToolBox.Files
{
    public static class FileSystem
    {
        public static IFileSystem Default
        {
            get
            {
                return new DefaultFileSystem();
            }
        }
    }

    public sealed class DefaultFileSystem : IFileSystem
    {
        public string GetPathRoot(string path)
        {
            return Path.GetPathRoot(path);
        }

        public string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }

        public string PathCombine(params string[] paths)
        {
            return Path.Combine(paths);
        }



        public string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
        
        public void CopyFile(string filePath, string newFilePath, bool overwrite = false)
        {
            File.Copy(filePath, newFilePath, overwrite);
        }

        public void MoveFile(string filePath, string newFilePath)
        {
            File.Move(filePath, newFilePath);
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public IEnumerable<string> GetFiles(string path, string filter)
        {
            return Directory.EnumerateFiles(path, (filter ?? "*"));
        }

        public IEnumerable<string> GetFiles(string path, string filter, SearchOption searchOption)
        {
            return Directory.EnumerateFiles(path, (filter ?? "*.*"), searchOption);
        }



        public string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void DeleteDirectory(string path, bool recursive = true){
            try
            {
                Directory.Delete(path, recursive);
            }
            catch (DirectoryNotFoundException) 
            {
                //Avoid Exception when try delete files inside deleted folder.
                return;
            }
            catch (Exception){
                throw;
            }
        }

        public void CreateDirectory(string path){            
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (DirectoryNotFoundException) 
            {
                //Avoid Exception when try delete files inside deleted folder.
                return;
            }
            catch (Exception){
                throw;
            }
        }

        public IEnumerable<string> GetDirectories(string path, string filter)
        {
            return Directory.EnumerateDirectories(path, (filter ?? "*"));
        }

        public IEnumerable<string> GetDirectories(string path, string filter, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, (filter ?? "*.*"), searchOption);
        }
    }
}