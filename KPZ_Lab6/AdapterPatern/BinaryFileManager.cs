using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab6.AdapterPatern
{
    class BinaryFileManager
    {
        private DataGridView dataGridView;

        public BinaryFileManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void SaveBinary(string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                // записуємо кількість рядків та стовпців
                writer.Write(dataGridView.RowCount-1);
                writer.Write(dataGridView.ColumnCount);

                // записуємо дані
                for (int i = 0; i < dataGridView.RowCount-1; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        if(dataGridView[j,i].Value == null)
                        {
                            writer.Write(String.Empty);
                        }
                        else
                        {
                            writer.Write(dataGridView[j, i].Value?.ToString());
                        }
                        
                    }
                }
            }
        }

        public void LoadBinary(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                // читаємо кількість рядків та стовпців
                int rowCount = reader.ReadInt32();
                int columnCount = reader.ReadInt32();

                // створюємо таблицю
                dataGridView.ColumnCount = columnCount;

                dataGridView.RowCount = rowCount;   

       

                // читаємо дані
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        dataGridView[j, i].Value = reader.ReadString();
                    }
                }
            }
        }
    }
}
