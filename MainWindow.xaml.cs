﻿using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace TextEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(RichTxBox.Document.ContentStart, RichTxBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(RichTxBox.Document.ContentStart, RichTxBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            if (new TextRange(RichTxBox.Document.ContentStart, RichTxBox.Document.ContentEnd).Text.Length > 1)
            {
                MessageBoxResult result = MessageBox.Show("Сохранить документ?", "Предупрежение", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                        if (sfd.ShowDialog() == true)
                        {
                            TextRange doc = new TextRange(RichTxBox.Document.ContentStart, RichTxBox.Document.ContentEnd);
                            using (FileStream fs = File.Create(sfd.FileName))
                            {
                                if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                                    doc.Save(fs, DataFormats.Rtf);
                                else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                                    doc.Save(fs, DataFormats.Text);
                                else
                                    doc.Save(fs, DataFormats.Xaml);
                            }
                        }
                        break;
                    case MessageBoxResult.No:
                        RichTxBox.Document.Blocks.Clear();
                        break;
                }

            }

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            RichTxBox.Undo();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            RichTxBox.Cut();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            RichTxBox.Copy();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            RichTxBox.Paste();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            RichTxBox.SelectAll();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RichTxBox.Cut();
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            RichTxBox.FontSize += 2;

        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            RichTxBox.Paste();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            RichTxBox.FontFamily = new FontFamily("Comic Sans MS");

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            RichTxBox.FontFamily = new FontFamily("Comic Sans Syastro");
        }
    }
}
