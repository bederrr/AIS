using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ClientWPF
{

    public class ViewModel
    {
        public ObservableCollection<Clinic> clinics { get; set; }
        public bool ischange { get; set; }

        public ViewModel()
        {
            clinics = new ObservableCollection<Clinic>();

            clinics.CollectionChanged += Clinic_CollectionChanged;
            ischange = false;
        }

        public void AddClinic(string datain)
        {
            try
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    string[] temp = datain.Split(';');
                    Clinic tempclinic = new Clinic();

                    int i = 1;
                    clinics.Add(new Clinic()
                    {
                        ID = Int32.Parse(temp[i++]),
                        city = temp[i++],
                        year = Int32.Parse(temp[i++]),
                        specialization = temp[i++],
                        cost = Int32.Parse(temp[i++]),
                        doctors_count = Int32.Parse(temp[i++]),
                        ready = temp[i].Equals("true") ? true : false
                    });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Clinic_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //switch (e.Action)
            //{
            //    case NotifyCollectionChangedAction.Add: // если добавление
            //        ischange = true;
            //        break;
            //    case NotifyCollectionChangedAction.Remove: // если удаление
            //        ischange = true;
            //        break;
            //    case NotifyCollectionChangedAction.Replace: // если замена
            //        ischange = true;
            //        break;
            //}
            ischange = true;
        }
    }
}