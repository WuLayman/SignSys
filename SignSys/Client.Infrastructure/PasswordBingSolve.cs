using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.Infrastructure
{
    public static class PasswordBingSolve
    {
        #region

        //    public static readonly DependencyProperty PasswordProperty =
        //        DependencyProperty.RegisterAttached("Password",
        //        typeof(string), typeof(PasswordBingSolve),
        //        new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        //    private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //    {
        //        PasswordBox passwordBox = sender as PasswordBox;

        //        string password = (string)e.NewValue;

        //        if (passwordBox != null && passwordBox.Password != password)
        //        {
        //            passwordBox.Password = password;
        //        }
        //    }

        //    public static string GetPassword(DependencyObject dp)
        //    {
        //        return (string)dp.GetValue(PasswordProperty);
        //    }

        //    public static void SetPassword(DependencyObject dp, string value)
        //    {
        //        dp.SetValue(PasswordProperty, value);
        //    }
        //}

        //public class PasswordBoxBehavior : Behavior<PasswordBox>
        //{
        //    protected override void OnAttached()
        //    {
        //        base.OnAttached();

        //        AssociatedObject.PasswordChanged += OnPasswordChanged;
        //    }

        //    private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        //    {
        //        PasswordBox passwordBox = sender as PasswordBox;

        //        string password = PasswordBingSolve.GetPassword(passwordBox);

        //        if (passwordBox != null && passwordBox.Password != password)
        //        {
        //            PasswordBingSolve.SetPassword(passwordBox, passwordBox.Password);
        //        }
        //    }

        //    protected override void OnDetaching()
        //    {
        //        base.OnDetaching();

        //        AssociatedObject.PasswordChanged -= OnPasswordChanged;
        //    }
        #endregion

        public static readonly DependencyProperty PasswordProperty =
               DependencyProperty.RegisterAttached("Password",
               typeof(string), typeof(PasswordBingSolve),
               new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(PasswordBingSolve), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
           DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
           typeof(PasswordBingSolve));


        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= PasswordChanged;

                if (!(bool)GetIsUpdating(passwordBox))
                {
                    passwordBox.Password = (string)e.NewValue;
                }
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                SetIsUpdating(passwordBox, true);
                SetPassword(passwordBox, passwordBox.Password);
                SetIsUpdating(passwordBox, false);
            }
        }
    }
}
