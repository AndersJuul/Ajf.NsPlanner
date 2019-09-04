using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;

namespace Ajf.NsPlanner.UI.Services
{
    public class WindowManager
    {
        private static readonly List<Window> Views = new List<Window>();
        public static void Register(Window window)
        {
            Views.Add(window);

            if (window.DataContext is IRememberWindowPosition model2)
            {
                var positionEtc = model2.Get(window.GetType().FullName);
                if (positionEtc != null)
                {
                    window.Left = positionEtc.Left;
                    window.Top = positionEtc.Top;
                    window.Width = positionEtc.Width;
                    window.Height = positionEtc.Height;
                }
            }
            if (window.DataContext is IShowAndHideWindows model)
            {
                model.PropertyChanged += Model_PropertyChanged;
                if (model.IsOpen)
                    window.Show();
            }

            window.SizeChanged += Window_SizeChanged;
            window.LocationChanged += Window_LocationChanged;
            window.Closing += Window_Closing;
        }

        private static void Window_Closing(object sender, CancelEventArgs e)
        {
            if (sender is Window window)
            {
                e.Cancel = true;
                if (window.DataContext is IShowAndHideWindows model) model.IsOpen = false;
            }
        }

        private static void Window_LocationChanged(object sender, EventArgs e)
        {
            if (sender is Window window)
            {
                var positionEtc = new PositionEtc { Left = window.Left, Top = window.Top, Width = window.Width, Height = window.Height };
                WindowPositionManager.Set(window.GetType().FullName, positionEtc);
            }
        }

        private static void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is Window window)
            {
                var positionEtc = new PositionEtc { Left =window. Left, Top = window.Top, Width = window.Width, Height = window.Height };
                WindowPositionManager.Set(window.GetType().FullName, positionEtc);
            }
        }

        private static void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IShowAndHideWindows.IsOpen))
            {
                foreach (var view in Views.Where(x => x.DataContext == sender))
                {
                    if (view.DataContext is IShowAndHideWindows m)
                    {
                        if (m.IsOpen)
                            view.Show();
                        else
                            view.Hide();

                        var positionEtc = WindowPositionManager.Get(view.GetType().FullName);
                        positionEtc.IsOpen = m.IsOpen;
                        WindowPositionManager.Set(view.GetType().FullName, positionEtc);
                    }
                }
            }
        }

        public static void OpenWindowsLastOpened()
        {
            foreach (var window in Views)
            {
                var positionEtc = WindowPositionManager.Get(window.GetType().FullName);
                if (positionEtc!=null)
                {
                    if (window.DataContext is IShowAndHideWindows model)
                    {
                        model.IsOpen = positionEtc.IsOpen;
                    }
                }
            }
        }
    }
}
