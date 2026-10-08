using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;
using CrazyUniverse__ROBOT_PLANET_.Core.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrazyUniverse__ROBOT_PLANET_.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Robot> Robots { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Robots = new ObservableCollection<Robot>();
            DataContext = this;
        }

        private void AddRobot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Enter robot name.");
                    return;
                }

                ComboBoxItem selectedItem = (ComboBoxItem)TypeComboBox.SelectedItem;

                string type = selectedItem.Content?.ToString() ?? "";

                if (type == "CleanerBot")
                {
                    Robots.Add(new CleanerBot(name));
                }
                else if (type == "ExplorerBot")
                {
                    Robots.Add(new ExplorerBot(name));
                }
                else
                {
                    Robots.Add(new RepairBot(name));
                }

                LogListBox.Items.Add($"{name} was added.");

                NameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveRobot_Click(object sender, RoutedEventArgs e)
        {
            Robot? selectedRobot =
                RobotListBox.SelectedItem as Robot;

            if (selectedRobot != null)
            {
                LogListBox.Items.Add($"{selectedRobot.Name} was removed.");

                Robots.Remove(selectedRobot);
            }
        }

        private void Work_Click(object sender, RoutedEventArgs e)
        {
            Robot? selectedRobot = RobotListBox.SelectedItem as Robot;

            if (selectedRobot != null)
            {
                LogListBox.Items.Add(selectedRobot.Work());
            }
        }

        private void CrazyAction_Click(object sender, RoutedEventArgs e)
        {
            Robot? selectedRobot = RobotListBox.SelectedItem as Robot;

            if (selectedRobot != null)
            {
                LogListBox.Items.Add(selectedRobot.CrazyAction());
            }
        }

        private void Charge_Click(object sender, RoutedEventArgs e)
        {
            Robot? selectedRobot = RobotListBox.SelectedItem as Robot;

            if (selectedRobot is IChargeable chargeable)
            {
                string message = chargeable.Charge();

                LogListBox.Items.Add(message);
            }
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            Robot? selectedRobot = RobotListBox.SelectedItem as Robot;

            if (selectedRobot is IScan scanner)
            {
                LogListBox.Items.Add(scanner.Scan());
            }
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            Robot? selectedRobot = RobotListBox.SelectedItem as Robot;

            if (selectedRobot is IRepair repairable)
            {
                LogListBox.Items.Add(repairable.Repair());
            }
        }
    }
}