﻿using System;
using System.IO;
using System.Text;

namespace CefSharp.MinimalExample.OffScreen.Notifications
{
    public class Notification
    {
        public string fileName { get; set; }
        public string pathToLogFile { get; set; }

        public Notification(string fileName)
        {
            this.fileName = fileName;
            this.pathToLogFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        }

        /// <summary>
        /// Уведомить пользователя о том, что фраза рабочая
        /// </summary>
        /// <param name="message"></param>
        public void ExecuteNotify(string message)
        {
            using (FileStream writer = new FileStream(pathToLogFile, FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(message + "\n");
                writer.Write(buffer);
            }

            Console.WriteLine(message);
        }
    }
}
