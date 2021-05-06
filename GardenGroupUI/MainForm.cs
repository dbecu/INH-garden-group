using GardenGroupUI.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GardenGroupModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace GardenGroupUI
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
            CurrentTickets currentTickets = new CurrentTickets();
            this.Controls.Add(currentTickets);
            this.Text = "Dashboard";
        }    
    }
}
