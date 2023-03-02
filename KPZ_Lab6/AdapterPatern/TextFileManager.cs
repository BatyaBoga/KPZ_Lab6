using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab6.AdapterPatern
{
    class TextFileManager : ITextFileManager
    {
        private DataGridView dataGridView;

        public TextFileManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // записуємо заголовки стовпців
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    writer.Write(dataGridView.Columns[i].HeaderText);

                    if (i < dataGridView.ColumnCount - 1)
                    {
                        writer.Write("\t");
                    }
                }

                writer.WriteLine();

                // записуємо дані
                for (int i = 0; i < dataGridView.RowCount-1; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        writer.Write(dataGridView[j, i].Value?.ToString());

                        if (j < dataGridView.ColumnCount - 1)
                        {
                            writer.Write("\t");
                        }
                    }

                    writer.WriteLine();
                }
            }
        }

        public void Load(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // читаємо заголовки стовпців
                string[] headers = reader.ReadLine().Split('\t');
                dataGridView.ColumnCount = headers.Length;

                for (int i = 0; i < headers.Length; i++)
                {
                    dataGridView.Columns[i].HeaderText = headers[i];
                }

                dataGridView.Rows.Clear();

                // читаємо дані
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split('\t');
                    dataGridView.Rows.Add(fields);
                }
            }
        }

    }
}
