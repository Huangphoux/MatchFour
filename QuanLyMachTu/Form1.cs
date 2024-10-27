// DarkModeForms v1.8.12 by BlueMystical
using DarkModeForms;

namespace QuanLyMachTu
{
    public partial class MatchFour : Form
    {
        public MatchFour()
        {
            InitializeComponent();

            // Don't bother make it switchable
            _ = new DarkModeCS(this);
        }
    }
}
