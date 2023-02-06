// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Amortisation
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Amortiasation Calculator";
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            String clientName;
            String financeCompany;
            String assetPurchased;

            double principal = Double.Parse(principalTxtBx.Text);
            double payment = Double.Parse(paymentTxtBx.Text);
            int term = Int16.Parse(termTxtBx.Text);
            int paymentFrequency = Int16.Parse(financeCompanyTxtBx.Text);


            double interest = Interest.calculateRate(principal, payment, term, paymentFrequency);
            lumpSumTxtBx.Text = interest.ToString();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
