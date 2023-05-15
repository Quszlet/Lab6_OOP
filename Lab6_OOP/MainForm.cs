using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lab6_OOP
{
    public partial class MainForm : Form
    {

        public Dictionary<AbsctructTrainStation, bool[]> trainStationsDictionary { get; set; }
        public MainForm()
        {
            InitializeComponent();
            trainStationsDictionary = new Dictionary<AbsctructTrainStation, bool[]>();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Добавление");
            comboBox1.Items.Add("Редактирование");
            comboBox1.SelectedIndex = 0;
            checkBox3.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
            checkBox8.Enabled = false;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button1.Text = "Добавить";
                textBox1.Text = "";
                textBox1.Enabled = true;
                comboBox2.Enabled = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox3.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
                checkBox8.Enabled = false;
                comboBox2.SelectedItem = null;
            }
            else
            {
                button1.Text = "Отредактировать";
                textBox1.Enabled = false;
                comboBox2.Enabled = true;
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbsctructTrainStation trainStation = new TrainStation();
            trainStation.NameStation = textBox1.Text;
            if (comboBox1.SelectedIndex == 0)
            {
                StringBuilder eventLog = new StringBuilder("");

                richTextBox1.AppendText(trainStation.NameStation + ": ");

                if (checkBox1.Checked)
                {
                    trainStation = new CargoTrainStationDecorator(trainStation);
                }

                if (checkBox2.Checked)
                {
                    trainStation = new PassengerTrainStationDecorator(trainStation);
                }

                PassengerTrainStationDecorator? passengerTrainStationDecorator = trainStation as PassengerTrainStationDecorator;

                if (passengerTrainStationDecorator != null)
                {
                    if (checkBox3.Checked)
                    {
                        eventLog.Append(passengerTrainStationDecorator.CheckDocuments() + ", ");
                    }

                    if (checkBox6.Checked)
                    {
                        eventLog.Append(passengerTrainStationDecorator.CheckTickets() + ", ");
                    }
                }


                CargoTrainStationDecorator? cargoTrainStationDecorator = trainStation as CargoTrainStationDecorator;

                if (cargoTrainStationDecorator != null)
                {
                    if (checkBox8.Checked)
                    {
                        eventLog.Append(cargoTrainStationDecorator.UnloadCargo() + ", ");
                    }

                    if (checkBox7.Checked)
                    {
                        eventLog.Append(cargoTrainStationDecorator.LoadCargo() + ", ");
                    }
                }

                if (checkBox4.Checked)
                {
                    eventLog.Append(trainStation.ArriveTrain() + ", ");
                }

                if (checkBox5.Checked)
                {
                    eventLog.Append(trainStation.DepartTrain() + ", ");
                }

                string resultEventLog = eventLog[0].ToString().ToUpper() + eventLog.ToString(1, eventLog.Length - 3);
                richTextBox1.SelectionColor = Color.Green;
                richTextBox1.AppendText(resultEventLog + "\n");

                bool[] checkBoxValues = new bool[groupBox2.Controls.OfType<CheckBox>().Count()];
                int index = 0;
                
                foreach (CheckBox checkBox in groupBox2.Controls.OfType<CheckBox>().Reverse()) 
                {
                    checkBoxValues[index++] = checkBox.Checked;
                }
                trainStationsDictionary.Add(trainStation, checkBoxValues);
                comboBox2.Items.Add(trainStation.NameStation);
            } 
            else
            {
                foreach (var elem in trainStationsDictionary)
                {
                    if (comboBox2.SelectedItem.ToString() == elem.Key.NameStation)
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.AppendText($"События станции {elem.Key.NameStation} изменены: ");
                        textBox1.Text = elem.Key.NameStation;
                        trainStation = elem.Key;
                        StringBuilder eventLog = new StringBuilder("");


                        if (checkBox2.Checked && trainStation is not PassengerTrainStationDecorator)
                        {
                            trainStation = new PassengerTrainStationDecorator(trainStation);
                        }

                        PassengerTrainStationDecorator? passengerTrainStationDecorator = trainStation as PassengerTrainStationDecorator;

                        if (passengerTrainStationDecorator != null)
                        {
                            if (checkBox3.Checked)
                            {
                                eventLog.Append(passengerTrainStationDecorator.CheckDocuments() + ", ");
                            }

                            if (checkBox6.Checked)
                            {
                                eventLog.Append(passengerTrainStationDecorator.CheckTickets() + ", ");
                            }
                        }

                        if (checkBox1.Checked && trainStation is not CargoTrainStationDecorator)
                        {
                            trainStation = new CargoTrainStationDecorator(trainStation);
                        }

                        CargoTrainStationDecorator? cargoTrainStationDecorator = trainStation as CargoTrainStationDecorator;

                        if (cargoTrainStationDecorator != null)
                        {
                            if (checkBox8.Checked)
                            {
                                eventLog.Append(cargoTrainStationDecorator.UnloadCargo() + ", ");
                            }

                            if (checkBox7.Checked)
                            {
                                eventLog.Append(cargoTrainStationDecorator.LoadCargo() + ", ");
                            }
                        }

                        if (checkBox4.Checked)
                        {
                            eventLog.Append(trainStation.ArriveTrain() + ", ");
                        }

                        if (checkBox5.Checked)
                        {
                            eventLog.Append(trainStation.DepartTrain() + ", ");
                        }

                        string resultEventLog = eventLog[0].ToString().ToUpper() + eventLog.ToString(1, eventLog.Length - 3);
                        richTextBox1.SelectionColor = Color.Blue;
                        richTextBox1.AppendText(resultEventLog + "\n");
                        bool[] checkBoxValues = new bool[groupBox2.Controls.OfType<CheckBox>().Count()];
                        int index = 0;
                        foreach (CheckBox checkBox in groupBox2.Controls.OfType<CheckBox>().Reverse())
                        {
                            checkBoxValues[index++] = checkBox.Checked;
                        }
                        trainStationsDictionary[elem.Key] = checkBoxValues;
                        comboBox2.SelectedIndex = 0;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox7.Enabled = true;
                checkBox8.Enabled = true;
            }
            else
            {
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox7.Enabled = false;
                checkBox8.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedItem != null)
            {
                foreach (var elem in trainStationsDictionary)
                {
                    if (comboBox2.SelectedItem.ToString() == elem.Key.NameStation)
                    {
                        int index = 0;
                        foreach (CheckBox checkBox in groupBox2.Controls.OfType<CheckBox>().Reverse())
                        {
                            checkBox.Checked = elem.Value[index++];
                            if (checkBox.Checked)
                            {
                                checkBox.Enabled = false;
                            }
                            else
                            {
                                checkBox.Enabled = true;
                            }
                        }
                    }
                }

                if (checkBox2.Checked && checkBox3.Checked == false)
                {
                    checkBox3.Enabled = true;
                }
                else if (checkBox2.Checked && checkBox6.Checked == false)
                {
                    checkBox6.Enabled = true;
                }
                else if (checkBox2.Checked == false)
                {
                    checkBox3.Checked = false;
                    checkBox6.Checked = false;
                    checkBox3.Enabled = false;
                    checkBox6.Enabled = false;
                }

                if (checkBox1.Checked && checkBox7.Checked == false)
                {
                    checkBox7.Enabled = true;
                }
                else if (checkBox1.Checked && checkBox8.Checked == false)
                {
                    checkBox8.Enabled = true;
                }
                else if (checkBox1.Checked == false)
                {
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    checkBox7.Enabled = false;
                    checkBox8.Enabled = false;
                }
            }
                
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Enabled = true;
                checkBox6.Enabled = true;
            }
            else
            {
                checkBox3.Checked = false;
                checkBox6.Checked = false;
                checkBox3.Enabled = false;
                checkBox6.Enabled = false;
            }
        }
    }
}