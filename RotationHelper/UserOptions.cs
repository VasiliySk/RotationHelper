using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotationHelper
{
    //Класс, отвечающий за сохранение, загрузку настроек
    class UserOptions
    {
        public enum FunctionKeys
        {
            Нет, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12
        }
        public static int startRotation { get; set; }
        public static int stopRotation { get; set; }
        public static int minimizeWindow { get; set; }

        //Сохраняем настройки
        public static void SaveSettings()
        {
            Properties.Settings.Default.StartRotation = startRotation;
            Properties.Settings.Default.StopRotation = stopRotation;
            Properties.Settings.Default.MinimizeWindow = minimizeWindow;
            Properties.Settings.Default.Save();
        }

        //Загружаем настройки
        public static void LoadSettings()
        {
            startRotation = Properties.Settings.Default.StartRotation;
            stopRotation = Properties.Settings.Default.StopRotation;
            minimizeWindow = Properties.Settings.Default.MinimizeWindow;
        }
    }
}
