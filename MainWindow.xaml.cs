using System;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Подписываем события на каждый переключатель
            toggle1.StateChanged += (sender, args) => UpdateLabelState(toggle1, label1);
            toggle2.StateChanged += (sender, args) => UpdateLabelState(toggle2, label2);
        }

        // Обновляем текст в Label в зависимости от состояния переключателя
        private void UpdateLabelState(CustomToggle toggle, Label label)
        {
            if (toggle.IsOn)
            {
                label.Content = "Включен";
            }
            else
            {
                label.Content = "Выключен";
            }
        }
    }
}
