using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab6.AdapterPatern
{
    class BinaryAdapter : BinaryFileManager, ITextFileManager
    {
        public BinaryAdapter(DataGridView dataGridView) : base(dataGridView) { }
        
        public void Load(string fileName)
        {
            base.LoadBinary(fileName);
        }

        public void Save(string fileName)
        {
            base.SaveBinary(fileName);
        }
    }
}
