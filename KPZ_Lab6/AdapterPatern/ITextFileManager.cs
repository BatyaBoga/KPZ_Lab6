
namespace KPZ_Lab6.AdapterPatern
{
    internal interface ITextFileManager
    {
        void Save(string fileName);
        void Load(string fileName);
    }
}
