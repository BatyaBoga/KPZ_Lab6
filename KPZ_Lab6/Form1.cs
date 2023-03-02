using KPZ_Lab6.AdapterPatern;

namespace KPZ_Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Binary files(*.bin)|*.bin";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|Binary files(*.bin)|*.bin";
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GetManager()?.Load(openFileDialog1.FileName);
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK){

                GetManager()?.Save(saveFileDialog1.FileName);
            }
        }

        private ITextFileManager GetManager()
        {
            ITextFileManager manager = null;

            var filename = saveFileDialog1.FileName == "" ? openFileDialog1.FileName : saveFileDialog1.FileName;

            var extension = Path.GetExtension(filename);

            switch (extension.ToLower())
            {
                case ".txt": manager = new TextFileManager(dataGridView1); break;
                case ".bin": manager = new BinaryAdapter(dataGridView1); break;
            }

            return manager;
        }

    }

  
}