using System;
using System.Text;
using System.IO;

namespace TextEditor.BL
{
    public interface IFileManager
    {
        string getContent(string filePath);
        string getContent(string filePath, Encoding encoding);
        void saveContent(string content, string filePath);
        void saveContent(string content, string filePath, Encoding encoding);
        int getSymbolCount(string content);
        bool isExist(string filePath);
    }
    public class FileManager:IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        public bool isExist(string filePath)
        {
            return File.Exists(filePath);
        }
        public string getContent(string filePath)
        {
            return getContent(filePath, _defaultEncoding);
        }
        public string getContent(string filePath, Encoding encoding)
        {
            return File.ReadAllText(filePath, encoding);
        }
        public void saveContent(string content, string filePath)
        {
            saveContent(content, filePath, _defaultEncoding);
        }
        public void saveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }
        public int getSymbolCount(string content)
        {
            return content.Length;
        }
    }
}
