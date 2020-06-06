using System;
using System.Collections.Generic;
using System.Text;

namespace ContcatXamarin.Interfaces
{
    public interface INavigationAware
    {
        void OnNavigatedFrom(object parameters);

        void OnNavigatedTo(object parameters);
    }
}
