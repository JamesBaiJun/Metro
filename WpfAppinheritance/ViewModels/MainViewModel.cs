using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace WpfAppinheritance.ViewModels
{
    [POCOViewModel]
    public class MainViewModel
    {
        public ObservableCollection<BaseClass> Listsoure { get; set; }
        public MainViewModel()
        {
            Listsoure = new ObservableCollection<BaseClass>();
            Children chi = new Children()
            {
                First = "James",
                Last = "Lebron",
                State=1
            };
            Listsoure.Add(chi);
            Children chi2 = new Children()
            {
                First = "Cris",
                Last = "Paul"
            };
            Listsoure.Add(chi2);
        }
        public void Start()
        {
            foreach (var item in Listsoure)
            {
                item.State = 1;
            }
        }
        public void Stop()
        {
            foreach (var item in Listsoure)
            {
                item.State = 0;
            }
        }
    }
}