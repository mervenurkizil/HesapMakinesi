using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace HesapMakinesi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Uygulama başlatıldığında çalışacak kod
        }

        protected override void OnSleep()
        {
            // Uygulama arka plana alındığında çalışacak kod
        }

        protected override void OnResume()
        {
            // Uygulama tekrar öne getirildiğinde çalışacak kod
        }
    }
}