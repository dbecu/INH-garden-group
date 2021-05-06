using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenGroupModel;

namespace GardenGroupUI
{
    public interface UserSelect
    {
        void SetUser(User user);

        void SelectCancelled();
    }
}
