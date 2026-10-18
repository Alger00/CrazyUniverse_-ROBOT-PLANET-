using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;
using CrazyUniverse__ROBOT_PLANET_.Core.Models;
using CrazyUniverse__ROBOT_PLANET_.Core.Repositories;
using CrazyUniverse__ROBOT_PLANET_.WpfApp.Commands;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace CrazyUniverse__ROBOT_PLANET_.WpfApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly Repository<Robot> robotRepository;
        public ObservableCollection<string> LogMessages { get; } = new();
        public ObservableCollection<Robot> Robots { get; } = new();
        public RelayCommand AddRobotCommand { get; }
        public RelayCommand RemoveRobotCommand { get; }
        public RelayCommand CrazyActionCommand { get; }
        public RelayCommand WorkCommand { get; }
        public RelayCommand ChargeCommand { get; }
        public RelayCommand ScanCommand { get; }
        public RelayCommand RepairCommand { get; }
        private string searchText = "";

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilteredRobots)));
            }
        }
        public IEnumerable<Robot> FilteredRobots => Robots.Where(r => r.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        public IEnumerable<Robot> RobotsByName => Robots.OrderBy(r => r.Name);
        public IEnumerable<string> RobotSummary => Robots.GroupBy(r => r.RobotType).Select(g => $"{g.Key}: {g.Count()}");
        public ObservableCollection<string> RobotTypes { get; } = new()
        {
            "CleanerBot",
            "ExplorerBot",
            "RepairBot",
            "GuardBot",
            "SoldierBot",
            "GeneralBot",
            "TankBot"
        };
        private string robotName = "";
        public string RobotName
        {
            get => robotName;
            set
            {
                robotName = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RobotName)));
            }
        }
        private string selectedRobotType = "CleanerBot";
        public string SelectedRobotType
        {
            get => selectedRobotType;
            set
            {
                selectedRobotType = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedRobotType)));
            }
        }
        private Robot? selectedRobot;
        public Robot? SelectedRobot
        {
            get => selectedRobot;
            set
            {
                selectedRobot = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedRobot)));

                RemoveRobotCommand.RaiseCanExecuteChanged();
                CrazyActionCommand.RaiseCanExecuteChanged();
                WorkCommand.RaiseCanExecuteChanged();
                ChargeCommand.RaiseCanExecuteChanged();
                ScanCommand.RaiseCanExecuteChanged();
                RepairCommand.RaiseCanExecuteChanged();
            }
        }
        public MainViewModel()
        {
            robotRepository = new Repository<Robot>();

            AddRobotCommand = new RelayCommand(AddRobot);
            RemoveRobotCommand = new RelayCommand(RemoveRobot, () => SelectedRobot != null);
            CrazyActionCommand = new RelayCommand(DoCrazyAction, () => SelectedRobot != null);
            WorkCommand = new RelayCommand(DoWork, () => SelectedRobot != null);
            ChargeCommand = new RelayCommand(DoCharge, () => SelectedRobot != null);
            ScanCommand = new RelayCommand(DoScan, () => SelectedRobot is ExplorerBot);
            RepairCommand = new RelayCommand(DoRepair, () => SelectedRobot is IRepair);

            robotRepository.CharacterAdded += Repository_CharacterAdded;
            robotRepository.CharacterRemoved += Repository_CharacterRemoved;
            robotRepository.CrazyActionPerformed += Repository_CrazyActionPerformed;
        }
        private void Repository_CharacterAdded(object? sender, RepositoryEventArgs e)
        {
            foreach (string message in e.Messages)
            {
                LogMessages.Add(message);
            }
        }

        private void Repository_CharacterRemoved(object? sender, RepositoryEventArgs e)
        {
            foreach (string message in e.Messages)
            {
                LogMessages.Add(message);
            }
        }

        private void Repository_CrazyActionPerformed(object? sender, RepositoryEventArgs e)
        {
            foreach (string message in e.Messages)
            {
                LogMessages.Add(message);
            }
        }
        private void AddRobot()
        {
            if (string.IsNullOrWhiteSpace(RobotName))
            {
                return;
            }

            Robot robot;

            switch (SelectedRobotType)
            {
                case "ExplorerBot":
                    robot = new ExplorerBot(RobotName);
                    break;

                case "RepairBot":
                    robot = new RepairBot(RobotName);
                    break;

                case "GuardBot":
                    robot = new GuardBot(RobotName);
                    break;

                case "SoldierBot":
                    robot = new SoldierBot(RobotName);
                    break;

                case "GeneralBot":
                    robot = new GeneralBot(RobotName);
                    break;

                case "TankBot":
                    robot = new TankBot(RobotName);
                    break;

                default:
                    robot = new CleanerBot(RobotName);
                    break;
            }

            robotRepository.Add(robot);

            Robots.Add(robot);

            RobotName = "";

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilteredRobots)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RobotsByName)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RobotSummary)));
        }
        private void RemoveRobot()
        {
            if (SelectedRobot == null)
            {
                return;
            }
            Robot robotToRemove = SelectedRobot;

            robotRepository.Remove(robotToRemove);

            Robots.Remove(robotToRemove);

            LogMessages.Add($"{robotToRemove.Name} was removed.");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilteredRobots)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RobotsByName)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RobotSummary)));
        }
        private void DoCrazyAction()
        {
            if (SelectedRobot == null)
            {
                return;
            }

            string result = SelectedRobot.CrazyAction();

            LogMessages.Add(result);

            if (!result.Contains("too tired"))
            {
                robotRepository.NotifyCrazyAction(SelectedRobot);
            }
        }
        private void DoWork()
        {
            if (SelectedRobot == null)
            {
                return;
            }

            LogMessages.Add(SelectedRobot.Work());
        }
        private void DoCharge()
        {
            if (SelectedRobot is IChargeable chargeable)
            {
                LogMessages.Add(chargeable.Charge());
            }
        }
        private void DoScan()
        {
            if (SelectedRobot is IScan scanner)
            {
                LogMessages.Add(scanner.Scan());
            }
        }
        private void DoRepair()
        {
            if (SelectedRobot is IRepair repairable)
            {
                LogMessages.Add(repairable.Repair());
            }
        }
    }
}