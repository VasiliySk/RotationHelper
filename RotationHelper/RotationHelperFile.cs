using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RotationHelper.frmMain;

namespace RotationHelper
{
    //Класс, отвечающий за чтение и сохранение файлов
    class RotationHelperFile
    {
        private String filePath;
        //Диалог выбора файла с ротацией
        public void OpenFile(OpenFileDialog openFileDialog1, DataGridView dataGridView, ToolStripMenuItem saveToolStripMenuItem)
        {
            Stream mystr = null;
            openFileDialog1.Filter = "Rotation Helper files (*.rhf)|*.rhf";
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments) + "\\My Rotation\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    filePath = openFileDialog1.FileName;
                    OpenFileRotation(filePath, dataGridView);
                    saveToolStripMenuItem.Enabled = true;
                }
            }
            mystr.Close();
        }

        //Открываем файл с ротацией
        private void OpenFileRotation (String filePath, DataGridView dataGridView)
        {
            StreamReader myread;
            ActionEnum result;
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            //Обработка ошибки, если файл не найден
            try
            {
                myread = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            catch (ArgumentException)
            {
                return;
            }
            string[] str;
            int num = 0;
            int rowNumber = 0;
            string replacement;
            string[] str1 = myread.ReadToEnd().Split('\n');
            num = str1.Length;            
            for (int i = 0; i < num; i++)
            {
                str = str1[i].Split(' ');
                dataGridView.Rows.Add();
                for (int j = 0; j < 2; j++)
                {                                        
                    switch (j)
                    {
                        case 0:
                            if (Enum.TryParse(str[j], out result))
                            {
                                switch (result)
                                {
                                    case ActionEnum.Light_Attack:
                                        dataGridView.Rows[rowNumber].Cells[0].Value = ActionEnum.Light_Attack;
                                        break;
                                    case ActionEnum.Heavy_Attack:
                                        dataGridView.Rows[rowNumber].Cells[0].Value = ActionEnum.Heavy_Attack;
                                        break;
                                    case ActionEnum.Клавиша:
                                        dataGridView.Rows[rowNumber].Cells[0].Value = ActionEnum.Клавиша;
                                        break;
                                    case ActionEnum.Пауза:
                                        dataGridView.Rows[rowNumber].Cells[0].Value = ActionEnum.Пауза;
                                        break;
                                }
                            }                           
                            break;
                        case 1:
                            replacement = Regex.Replace(str[j], @"\t|\n|\r", "");
                            dataGridView.Rows[rowNumber].Cells[1].Value = replacement;                            
                            break;
                    }
                }
                dataGridView.Refresh();
                rowNumber++;
            }
            myread.Close();            
        }

        //Сохраняем файл с ротацией
        public void SaveFile(DataGridView dataGridView)
        {
            StreamWriter myWriter = new StreamWriter(filePath);
            WriteToFileRotation(myWriter, dataGridView);
            myWriter.Close();
        }

        //Сохраняем файл с ротацией как...
        public void SaveFileAs(SaveFileDialog saveFileDialog,DataGridView dataGridView, ToolStripMenuItem saveToolStripMenuItem)
        {
            Stream myStream;
            saveFileDialog.Filter = "Rotation Helper files (*.rhf)|*.rhf";
            saveFileDialog.DefaultExt = "rhf";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    filePath = saveFileDialog.FileName;
                    StreamWriter myWriter = new StreamWriter(myStream);
                    WriteToFileRotation(myWriter, dataGridView);
                    myStream.Close();
                    saveToolStripMenuItem.Enabled = true;
                }
            }
        }

        //Сохраняем файл
        private void WriteToFileRotation(StreamWriter myWriter, DataGridView dataGridView)
        {
            try
            {
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    myWriter.Write(Convert.ToString(dataGridView.Rows[i].Cells[0].Value));
                    myWriter.Write(" ");
                    myWriter.Write(Convert.ToString(dataGridView.Rows[i].Cells[1].Value));
                    if (i< dataGridView.RowCount - 2) myWriter.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myWriter.Close();
            }
        }

        //Создаем файл
        public void CreateFile(DataGridView dataGridView, ToolStripMenuItem saveToolStripMenuItem)
        {
            filePath = "";
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            saveToolStripMenuItem.Enabled = false;
        }
    }
}
