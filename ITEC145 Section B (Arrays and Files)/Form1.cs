namespace ITEC145_Section_B__Arrays_and_Files_
{
    public partial class Form1 : Form
    {
        List<string> names = new List<string>();
        List<double> temperatures = new List<double>();
        

        public Form1()
        {
            InitializeComponent();
            LoadFile(names);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string nameInput = txtAdd.Text;                                     //Assigns text box to nameInput variable
                SaveFile(nameInput);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);                                        //In case all else fails with my program
            }

            
        }
        private void LoadFile(List<string> data)
        {
            try
            {
                StreamReader inputFile = new StreamReader("NamesLog.txt");          //Creates a streamreader to read the outputfile

                while (inputFile.EndOfStream != true)                               //runs loop until the reader hits the end of stream
                {
                    data.Add(inputFile.ReadLine());                                 //Adds the stream reader lines to the names list
                }
                inputFile.Close();                                                  //Closes the streamreader process

                foreach (string name in data)                                       //Checks all the strings in names list
                {
                    lstOutput.Items.Add(name);                                      //Adds names list strings to the listbox
                }
            }
            catch
            {
                MessageBox.Show("No Names Log detected, please add names to create a log file");
            }
        }

        private void LoadFile(List<double> data)
        {
            try
            {
                double avgTemp = 0;                                                 //Variable for holding average temp
                int count = 0;                                                      //Variable for holding a count

                StreamReader inputFile = new StreamReader("mh_temp2021.txt");          //Creates a streamreader to read the outputfile

                while (inputFile.EndOfStream != true)                               //runs loop until the reader hits the end of stream
                {
                    data.Add(double.Parse(inputFile.ReadLine()));                   //Adds the stream reader lines to the names list
                }
                inputFile.Close();                                                  //Closes the streamreader process

                foreach (double temp in data)                                       //Checks all the strings in names list
                {
                    avgTemp += temp;                                                //Adds every temp in list temperatures to avgTemp variable
                    count++;                                                        //Iterates for each line of data
                }
                avgTemp /= count;


                txtAverageTemp.Text = $"{count} data samples read. Average = {avgTemp.ToString("N4")}";     //Output and formatting

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveFile(string nameInput)
        {
            lstOutput.Items.Clear();                                                //Clears list
            StreamWriter outputFile = new StreamWriter("NamesLog.txt", true);       //StreamWriter for saving files
            outputFile.WriteLine(nameInput);                                        //Write a line to output file NamesLog.txt
            outputFile.Close();                                                     //Closes the outputFile
            names.Clear();                                                          //Clears the names list
            LoadFile(names);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            temperatures.Clear();
            LoadFile(temperatures);
        }
    }
}