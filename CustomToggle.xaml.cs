using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace YourNamespace
{
    public partial class CustomToggle : UserControl
    {
        // Флаг состояния переключателя
        public bool IsOn { get; private set; }

        // Событие изменения состояния
        public event EventHandler StateChanged;

        public CustomToggle()
        {
            InitializeComponent();
            IsOn = false; // Изначально выключен
        }

        // Обработчик нажатия ЛКМ
        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Переключаем состояние
            IsOn = !IsOn;

            // Отложим обновление UI на следующий кадр
            Dispatcher.BeginInvoke((Action)(() =>
            {
                AnimateToggle();

                // Генерируем событие изменения состояния
                StateChanged?.Invoke(this, EventArgs.Empty);
            }));
        }

        // Анимация изменения состояния переключателя
        private void AnimateToggle()
        {
            try
            {
                // Позиция индикатора на основе состояния
                double targetPosition = IsOn ? 60 : 0;
                var targetColor = IsOn ? Colors.Green : Colors.Gray;

                // Анимация перемещения индикатора
                DoubleAnimation indicatorAnimation = new DoubleAnimation
                {
                    To = targetPosition,
                    Duration = TimeSpan.FromMilliseconds(200),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };

                // Применяем анимацию для перемещения индикатора
                ToggleIndicator.BeginAnimation(Canvas.LeftProperty, indicatorAnimation);

                // Создаем новый SolidColorBrush для фона
                SolidColorBrush backgroundBrush = new SolidColorBrush(targetColor);
                ToggleBackground.Fill = backgroundBrush; // Обновляем цвет фона
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
