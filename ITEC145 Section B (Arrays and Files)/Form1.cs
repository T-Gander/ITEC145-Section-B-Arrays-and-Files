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

        private void LoadFile(List<double> data)                                    //Method to load a txt file to a list
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

        private void SaveFile(string nameInput)                                     //Method to save a string to a txt file
        {
            lstOutput.Items.Clear();                                                //Clears list
            StreamWriter outputFile = new StreamWriter("NamesLog.txt", true);       //StreamWriter for saving files
            outputFile.WriteLine(nameInput);                                        //Write a line to output file NamesLog.txt
            outputFile.Close();                                                     //Closes the outputFile
            names.Clear();                                                          //Clears the names list
            LoadFile(names);
        }

        private void AvgTemp(ref double avgTemp, int index1, int index2, List<double> temperatures)            //Method to calculate the average temp based off of two index's added
        {
            count = 0;                                                              //Resets count.
            for (int i = index1; i < index2; i++)                                   //Loop to start at index1 and end at index2
            {
                avgTemp += temperatures[i];                                         //Adds temperatures index's to the avgTemp variable
                count++;
            }
            avgTemp /= count;                                                       //Divides all of the temps by the count value to get the average
        }

        private void AvgTemp(List<double> avgTempList,ref double avgTemp)           //Overloaded method to average a whole list
        {
            count = 0;                                                              //Resets count
            foreach (double temp in avgTempList)                                    //Checks all the strings in names list
            {
                avgTemp += temp;                                                    //Adds every temp in list temperatures to avgTemp variable
                count++;                                                            //Iterates for each line of data
            }
            avgTemp /= count;                                                       //Divides all of the temps by the count value to get the average
        }
        


        private void btnLoad_Click(object sender, EventArgs e)
        {
            double avgWeatherData = 0;                                              //Initialises avgWeatherData variable
            temperatures.Clear();                                                   //Clears temperatures list before repopulating so that double loads aren't possible
            LoadFile(temperatures);                                                 //Loads file
            AvgTemp(temperatures,ref avgWeatherData);                               //Calculates average temp on a whole list.
            txtAverageTemp.Text = $"{count} data samples read. Average = {avgWeatherData.ToString("N4")}";     //Output and formatting
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            double avgJan = 0;                                                                  //Initialises avgJan and avgAug variables
            double avgAug = 0;

            temperatures.Clear();                                                               //Clears temperature list so that double loads don't occur
            LoadFile(temperatures);                                                             //Loads mh2021_temps file to temperatures list
            AvgTemp(ref avgJan, 0, 744, temperatures);                                          //Uses indexes to find the average in the entered list
            txtJanuary.Text = $"Average Temperature in January = {avgJan.ToString("N4")}";      //Output and formatting

            temperatures.Clear();                                                               //Clears temperature list so that double loads don't occur
            LoadFile(temperatures);                                                             //Loads mh2021_temps file to temperatures list
            AvgTemp(ref avgAug, 5087, 5831, temperatures);                                      //Uses indexes to find the average in the entered list
            txtAugust.Text = $"Average Temperature in August = {avgAug.ToString("N4")}";        //Output and formatting
        }
    }
}