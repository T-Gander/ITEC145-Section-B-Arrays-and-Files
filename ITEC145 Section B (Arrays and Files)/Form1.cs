namespace ITEC145_Section_B__Arrays_and_Files_
{
    public partial class Form1 : Form
    {
        List<string> names = new List<string>();
        List<double> temperatures = new List<double>();
        int count = 0;

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
            data.Clear();
            try
            {
                StreamReader inputFile = new StreamReader("mh_temp2021.txt");       //Creates a streamreader to read the outputfile

                while (inputFile.EndOfStream != true)                               //runs loop until the reader hits the end of stream
                {
                    data.Add(double.Parse(inputFile.ReadLine()));                   //Adds the stream reader lines to the names list
                }
                inputFile.Close();                                                  //Closes the streamreader process

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
            txtAverageTemp.Clear();                                             //To stop concatenation
            double avgWeatherData = 0;
            count = 0;

            temperatures.Clear();
            LoadFile(temperatures);

            foreach (double temp in temperatures)                                       //Checks all the strings in names list
            {
                avgWeatherData += temp;                                                //Adds every temp in list temperatures to avgTemp variable
                count++;                                                        //Iterates for each line of data
            }
            avgWeatherData /= count;
            txtAverageTemp.Text = $"{count} data samples read. Average = {avgWeatherData.ToString("N4")}";     //Output and formatting
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            double avgJan = 0;
            double avgAug = 0;

            LoadFile(temperatures);
            count = 0;

            for (int i = 0; i < 743; i++)
            {
                temperatures[i] += avgJan;
                count++;
            }

            avgJan /= count;
            txtJanuary.Text = $"Average Temperature in January = {avgJan.ToString("N4")}";

            LoadFile(temperatures);
            count = 0;

            for (int i = 5087; i < 5830; i++)
            {
                temperatures[i] += avgAug;
                count++;
            }

            avgAug /= count;
            txtAugust.Text = $"Average Temperature in August = {avgAug.ToString("N4")}";
        }
    }
}