using ppedv.HalloSerien.Logic;
using ppedv.HalloSerien.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    class SeriesViewModel : ViewModelBase
    {
        public ObservableCollection<Series> SeriesList { get; set; }

        public ObservableCollection<Episode> EpisodesList { get; set; }

        Core core = new Core();
        public Episode SelectedEpisodes { get; set; }


        public SeriesViewModel()
        {
            SeriesList = new ObservableCollection<Series>(core.Repository.Query<Series>());
            EpisodesList = new ObservableCollection<Episode>(core.Repository.Query<Episode>());
        }
    }
}
