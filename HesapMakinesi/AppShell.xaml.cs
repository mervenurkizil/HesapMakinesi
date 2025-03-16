using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Sayfa rotalarını kaydet
            Routing.RegisterRoute(nameof(Views.StandartSayfasi), typeof(Views.StandartSayfasi));
            Routing.RegisterRoute(nameof(Views.BilimselSayfasi), typeof(Views.BilimselSayfasi));
        }
    }
}