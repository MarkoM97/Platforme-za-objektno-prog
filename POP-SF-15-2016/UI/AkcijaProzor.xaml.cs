﻿using POP_SF_15_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF_15_2016.UI
{
    /// <summary>
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {
        CollectionViewSource cvs;
        ICollectionView view;
        public AkcijaProzor()
        {
            InitializeComponent();

            //Filtriranje zbog dummy akcije


            /*view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Akcije);
            dgAkcija.ItemsSource = view;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            */


            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instance.Akcije;

            cvs.Filter += new FilterEventHandler(filterFunckija);
            view = cvs.View;
            dgAkcija.ItemsSource = view;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string x = (string)e.Column.Header;
            if(x == "Id" || x == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Akcija novaAkcija = new Akcija(Aplikacija.Instance.Akcije.Last().Id + 1);
            AkcijaIzmenaProzor aip = new AkcijaIzmenaProzor(novaAkcija);
            aip.ShowDialog();
        }
        private void btnIzmeni_Clicked(object sender, RoutedEventArgs e)
        {
            Akcija selektovanaAkcija = view.CurrentItem as Akcija;
            if (selektovanaAkcija != null)
            {
                AkcijaIzmenaProzor aip = new AkcijaIzmenaProzor(selektovanaAkcija, AkcijaIzmenaProzor.Stanje.IZMENA);
                aip.ShowDialog();
            }
        }

        private void btnObrisi_Clicked(object sender, RoutedEventArgs e)
        {
            Akcija selektovanaAkcija = view.CurrentItem as Akcija;
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Ostaje da bi tokom izmene namestaja takodje prikazala nova lista sa izbrisanom akcijom
                Aplikacija.Instance.Akcije.Remove(selektovanaAkcija);
            }
        }

        private void filterFunckija(object sender, FilterEventArgs e)
        {
            //string s = tbPretraga.Text;
            Akcija akcija = e.Item as Akcija;
            if (akcija.Naziv == null)
            {
                //e.Accepted = akcija.Naziv.ToString().Contains(s);
                e.Accepted = false;
            }
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(pretraga);
        }

        private void pretraga(object sender, FilterEventArgs e)
        {
            string s = tbPretraga.Text;
            Akcija akcija = e.Item as Akcija;
            if(akcija != null && !akcija.Naziv.Equals(""))
            {
                e.Accepted = akcija.Naziv.ToString().Contains(s);
            } 
        }
    }
}